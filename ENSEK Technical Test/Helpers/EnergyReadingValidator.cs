using ENSEK_Technical_Test.Models;
using System.Linq;
using ENSEK_Technical_Test.Services.Repository;

namespace ENSEK_Technical_Test.Helpers
{
    public class EnergyReadingValidator
    {
        private readonly AccountRepository accountRepository;

        public EnergyReadingValidator(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public bool Validate(EnergyReading reading, Dictionary<int, string> errorList)
        {
            if (reading.Reading > 99999 || reading.Reading < 0)
            {
                errorList.Add(reading.AccountID, "Reading value (" + reading.Reading + ") outside of range");
                return false;
            }

            if (!accountRepository.GetAll().Any(t => t.Id == reading.AccountID))
            {
                errorList.Add(reading.AccountID, "AccountID (" + reading.AccountID + ") does not exist");
                return false;
            }
            EnergyAccount energyAccount = accountRepository.Get(reading.AccountID);

            if (energyAccount.GetMeterReading() >= reading.Reading)
            {
                errorList.Add(reading.AccountID, "Reading value is less that reading value in database");
                return false;
            }

            if (energyAccount.GetLastReadingTime() >= reading.ReadingDateTime)
            {
                errorList.Add(reading.AccountID, "Reading date is less than reading in database");
                return false;
            }

            return true;
        }

        public IList<EnergyReading> ValidateDuplicates(IList<EnergyReading> readings, Dictionary<int, string> errorList)
        {
            IList<EnergyReading> validreading = new List<EnergyReading>();
            var duplicates = readings.GroupBy(x => x.AccountID).Where(g => g.Count() > 1);
            foreach (var duplicate in duplicates)
            {
                //TODO: FINISH THIS UP
            }

            return readings;
        }
    }
}
