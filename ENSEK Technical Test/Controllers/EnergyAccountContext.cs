using ENSEK_Technical_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSEK_Technical_Test.Controllers
{
    public class EnergyAccountContext : DbContext
    {
        public EnergyAccountContext(DbContextOptions<EnergyAccountContext> options) : base(options)
        {
            PopulateFromSeedFile();
        }

        public DbSet<EnergyAccount> EnergyAccountList { get; set; }

        public void PopulateFromSeedFile()
        {
            string filePath = Path.GetFullPath("Test_AccountS.txt");

            if (filePath != null)
            {
                StreamReader sr = new StreamReader(filePath);
                IList<EnergyAccount> accounts = new List<EnergyAccount>();
                using (var reader = new StreamReader(filePath));

            }
            else
            {
                throw new FileNotFoundException("Seed file not found");
            }
        }
    }

}
