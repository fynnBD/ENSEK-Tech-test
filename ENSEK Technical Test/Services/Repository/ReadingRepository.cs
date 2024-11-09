using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Models.Interfaces;

namespace ENSEK_Technical_Test.Services.Repository
{

    public class ReadingRepository(EnergyContext dbContext)
    {
        private EnergyContext ErContext { get; set; } = dbContext;

        public EnergyReading? GetForAccountId(int accountId)
        {
            return ErContext.EnergyReadings.FirstOrDefault(e => e.AccountID == accountId);
        }

        public void Save(IEntity energyReading)
        {
            ErContext.EnergyReadings.Add((EnergyReading)energyReading);
            ErContext.SaveChanges();
        }

        public IEntity Get(int Id)
        {
            EnergyReading? result = ErContext.EnergyReadings.First(x => x.Id == Id);

            return result;
        }
    }
}
