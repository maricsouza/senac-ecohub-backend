using Ecohub._3___Repository.Interfaces;
using Ecohub._3___Repository.Repositories;
using Ecohub.Repository.Interfaces;
using Ecohub.Repository.Repositories;
using Ecohub.Service;
using Ecohub.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//string mysqlConnect = builder.Configuration.GetConnectionString("Connection");

//builder.Services.AddDbContextPool<AppDbContext>(options =>
//    options.UseMySql(mysqlConnect, ServerVersion.AutoDetect(mysqlConnect)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IMaterialRepository, MaterialRepository>();
builder.Services.AddTransient<IMaterialService, MaterialService>();
builder.Services.AddTransient<IPontoColetaRepository, PontoColetaRepository>();
builder.Services.AddTransient<IPontoColetaService, PontoColetaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
