using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSEK_Technical_Test.Services.Repository
{

    public class ReadingRepository
    {
        private EnergyAccountContext erContext { get; set; }

        public ReadingRepository(EnergyAccountContext dbContext)
        {
            erContext = dbContext;
        }

        public EnergyReading? GetForAccountID(int accountID)
        {
            return erContext.EnergyReadings.FirstOrDefault(e => e.AccountID == accountID);
        }

        public IQueryable<EnergyReading> GetAll()
        {
            return erContext.EnergyReadings.AsQueryable();
        }

        public void SaveReading(EnergyReading energyReading)
        {
            erContext.EnergyReadings.Add(energyReading);
            erContext.SaveChanges();
        }
    }
}
