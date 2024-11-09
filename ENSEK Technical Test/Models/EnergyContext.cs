using ENSEK_Technical_Test.Data;
using Microsoft.EntityFrameworkCore;

namespace ENSEK_Technical_Test.Models
{
    public class EnergyContext : DbContext
    {
        private EnergyAccountSeeder energyAccountSeeder { get; }
        public EnergyContext(DbContextOptions<EnergyContext> options) : base(options)
        {
            energyAccountSeeder = new EnergyAccountSeeder(this);
        }

        public DbSet<EnergyAccount> EnergyAccounts { get; set; }
        public DbSet<EnergyReading> EnergyReadings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            energyAccountSeeder.Seed(modelBuilder);
        }
    }

}
