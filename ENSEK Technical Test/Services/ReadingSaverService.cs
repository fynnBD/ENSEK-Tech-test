using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Services.Repository;

namespace ENSEK_Technical_Test.Services
{
    public class ReadingSaverService
    {
        private readonly ReadingRepository _readingRepository;

        public ReadingSaverService(ReadingRepository readingRepository)
        {
            this._readingRepository = readingRepository;
        }

        public IList<EnergyReading> SaveReadings(IList<EnergyReading> readings,
            Dictionary<int, string> errorDictionary)
        {
            IList<EnergyReading> validReadings = new List<EnergyReading>();
            foreach (EnergyReading reading in readings)
            {
                try
                {
                    _readingRepository.SaveReading(reading);
                    validReadings.Add(reading);
                }
                catch (Exception ex)
                {
                    errorDictionary.Add(reading.Id, ex.Message);
                }
            }

            return validReadings;
        }
    }
}
