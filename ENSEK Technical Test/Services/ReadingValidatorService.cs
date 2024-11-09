using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.Helpers;
using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Services.Repository;

namespace ENSEK_Technical_Test.Services
{
    public class ReadingValidatorService
    {
        private readonly EnergyReadingValidator energyReadingValidator;
        private readonly EnergyAccountContext erContext;
        private readonly AccountRepository accountRepository;
        private readonly ReadingRepository readingRepository;

        public ReadingValidatorService(EnergyAccountContext erContext,
            AccountRepository accountRepository,
            ReadingRepository readingRepository,
            EnergyReadingValidator energyReadingValidator)
        {
            this.energyReadingValidator = energyReadingValidator;
            this.erContext = erContext;
            this.accountRepository = accountRepository;
            this.readingRepository = readingRepository;
        }

        public IList<EnergyReading> ValidateReadings(IList<EnergyReading> readings, Dictionary<int, string> errorList)
        {
            IList<EnergyReading> validReadings = new List<EnergyReading>();
            foreach (EnergyReading reading in readings)
            {
                if(energyReadingValidator.Validate(reading, errorList))
                {
                    validReadings.Add(reading);
                }
            }
            energyReadingValidator.ValidateDuplicates(readings, errorList);

            return validReadings;
        }
    }
}
