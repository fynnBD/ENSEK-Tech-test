
using ENSEK_Technical_Test.Helpers;
using ENSEK_Technical_Test.Models;

namespace ENSEK_Technical_Test.Services
{
    public class ReadingValidatorService
    {
        private readonly EnergyReadingValidator _energyReadingValidator;

        public ReadingValidatorService(
            EnergyReadingValidator energyReadingValidator)
        {
            this._energyReadingValidator = energyReadingValidator;
        }

        public IList<EnergyReading> ValidateReadings(IList<EnergyReading> readings, Dictionary<int, string> errorList)
        {
            IList<EnergyReading> validReadings = new List<EnergyReading>();
            foreach (EnergyReading reading in readings)
            {
                if(_energyReadingValidator.Validate(reading, errorList))
                {
                    validReadings.Add(reading);
                }
            }
            validReadings = _energyReadingValidator.ValidateDuplicates(validReadings, errorList);

            return validReadings;
        }
    }
}
