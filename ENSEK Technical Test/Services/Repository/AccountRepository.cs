using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.Models;

namespace ENSEK_Technical_Test.Services.Repository
{
    public class AccountRepository
    {
        private readonly ReadingRepository readingRepository;

        public AccountRepository(EnergyAccountContext erContext, ReadingRepository readingRepository)
        {
            this.readingRepository = readingRepository;
            this.erContext = erContext;
        }

        public EnergyAccountContext erContext { get; }

        public IQueryable<EnergyAccount> GetAll()
        {
            return erContext.EnergyAccounts.AsQueryable();
        }

        public EnergyAccount Get(int id)
        {
            EnergyAccount result = erContext.EnergyAccounts.FirstOrDefault(x => x.Id == id);
            result.SetReading(readingRepository.GetForAccountID(result.Id));
            return result;
        }
    }
}
