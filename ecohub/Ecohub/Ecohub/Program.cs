using Ecohub._2___Service;
using Ecohub._3___Repository.Interfaces;
using Ecohub._3___Repository.Repositories;
using Ecohub.Repository.Interfaces;
using Ecohub.Repository.Repositories;
using Ecohub.Service;
using Ecohub.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static Ecohub.TokenConfiguration;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//string mysqlConnect = builder.Configuration.GetConnectionString("Connection");

//builder.Services.AddDbContextPool<AppDbContext>(options =>
//    options.UseMySql(mysqlConnect, ServerVersion.AutoDetect(mysqlConnect)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeção de dependência
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IMaterialRepository, MaterialRepository>();
builder.Services.AddTransient<IMaterialService, MaterialService>();
builder.Services.AddTransient<IPontoColetaRepository, PontoColetaRepository>();
builder.Services.AddTransient<IPontoColetaService, PontoColetaService>();
builder.Services.AddTransient<IMaterialPontoDeColetaRepository, MaterialPontoDeColetaRepository>();
builder.Services.AddTransient<TokenService>();

//JWTConfig
var key = Encoding.ASCII.GetBytes(JwtKey);
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false
        };
    });

//Configuração do Swagger para adicionar o Bearer Token na auth
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTAuthAuthentication", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
