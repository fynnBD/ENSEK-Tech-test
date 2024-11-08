using ENSEK_Technical_Test.Data;
using ENSEK_Technical_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSEK_Technical_Test.Controllers
{
    public class EnergyAccountContext : DbContext
    {
        private EnergyAccountSeeder energyAccountSeeder { get; }
        public EnergyAccountContext(DbContextOptions<EnergyAccountContext> options) : base(options)
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
