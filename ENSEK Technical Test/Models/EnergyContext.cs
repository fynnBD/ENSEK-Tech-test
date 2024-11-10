using Microsoft.EntityFrameworkCore;

namespace ENSEK_Technical_Test.Models
{
    public class EnergyContext : DbContext
    {
        public EnergyContext(DbContextOptions<EnergyContext> options) : base(options)
        {
        }

        public DbSet<EnergyAccount> EnergyAccounts { get; set; }
        public DbSet<EnergyReading> EnergyReadings { get; set; }
    }
}
