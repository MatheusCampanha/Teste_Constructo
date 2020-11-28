using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Ex_3.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Morador> Moradors { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Familia>()
                .HasOne<Condominio>(f => f.condominio)
                .WithMany(c => c.Familias)
                .HasForeignKey(f => f.Id_Condominio);

            modelBuilder.Entity<Morador>()
                .HasOne<Familia>(m => m.familia)
                .WithMany(f => f.Moradors)
                .HasForeignKey(m => m.Id_Familia);
        }

    }
}
