using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Models.Heroi> Herois { get; set; }

        public DbSet<Models.Batalha> Batalhas { get; set; }

        public DbSet<Models.Arma> Armas { get; set; }

        public DbSet<Models.HeroiBatalha> HeroisBatalhas { get; set; }

        public DbSet<Models.IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;User ID=root;Initial Catalog=heroi;Data Source=LEGIONY720-BRUN\SQLEXPRESS");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.HeroiBatalha>(entity => {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }
    }
}
