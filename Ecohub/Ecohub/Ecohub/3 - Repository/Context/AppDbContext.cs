using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Specialized;
using System;
using Ecohub.Repository.Entidades;

namespace Ecohub.Infra.Context
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        string mysqlConnect = "Server = localhost; Port=3306;Database=ECOHUB;Uid=root;Pwd=MySqlFacul;Persist Security Info=False; Connect Timeout = 300";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(mysqlConnect, ServerVersion.AutoDetect(mysqlConnect));


        public DbSet<MaterialEntidade> Material { get; set; }

        // public DbSet<MaterialPontoDeColetaEntidade> PontosMateriais { get; set; }
        public DbSet<UsuarioEntidade> Usuarios { get; set; }
        public DbSet<PontoDeColetaEntidade> PontoColeta { get; set; }

        public DbSet<MaterialPontoDeColetaEntidade> MateriaisPontoDeColeta { get; set; }
    }
}
