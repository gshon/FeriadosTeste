using Microsoft.EntityFrameworkCore;
using FeriadosNacionais.Infra.Data.Map;
using FeriadosNacionais.Infra.Entities;

namespace FeriadosNacionais.Infra.Data
{
    public class FeriadosDbContext : DbContext
    {
        public FeriadosDbContext(DbContextOptions<FeriadosDbContext> contextOptions):base(contextOptions){        
        }

        public DbSet<FeriadosDatasEntity> FeriadosDatas { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FeriadosDatasMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
