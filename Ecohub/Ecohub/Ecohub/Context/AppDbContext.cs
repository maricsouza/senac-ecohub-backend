using Ecohub.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Ecohub.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext(){ }

        public DbSet<Material> Material { get; set; } 

        public DbSet<Usuario> Usuarios { get; set; }
         
    }
}
