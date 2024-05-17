using Ecohub.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Specialized;
using System;

namespace Ecohub.Context
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        string mysqlConnect = "Server = localhost; Port=3306;Database=ECOHUB;Uid=root;Pwd=MySqlFacul;Persist Security Info=False; Connect Timeout = 300";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(mysqlConnect, ServerVersion.AutoDetect(mysqlConnect));
        

        public DbSet<MaterialModel> Material { get; set; } 

        public DbSet<UsuarioModel> Usuarios { get; set; }
         
    }
}
