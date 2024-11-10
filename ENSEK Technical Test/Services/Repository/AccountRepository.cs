using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Models.Interfaces;
using ENSEK_Technical_Test.Services.Repository.Interfaces;

namespace ENSEK_Technical_Test.Services.Repository
{
    public class AccountRepository : IRepository
    {
        private readonly ReadingRepository readingRepository;

        public AccountRepository(EnergyContext erContext, ReadingRepository readingRepository)
        {
            this.readingRepository = readingRepository;
            this.erContext = erContext;
        }

        public EnergyContext erContext { get; }

        public IEntity? Get(int id)
        {
            EnergyAccount? result = erContext.EnergyAccounts.FirstOrDefault(x => x.Id == id);
            
            if (result != null)
            {
                result.SetReading(readingRepository.GetForAccountId(result.Id));
            }

            return result;
        }

        public void Save(IEntity account)
        {
            erContext.EnergyAccounts.Add((EnergyAccount)account);
        }

        public IEnumerable<IEntity> GetAll(int id)
        {
            return erContext.EnergyAccounts.AsQueryable();
        }

        public IQueryable<EnergyAccount> GetAll()
        {
            return erContext.EnergyAccounts.AsQueryable();
        }
    }
}
