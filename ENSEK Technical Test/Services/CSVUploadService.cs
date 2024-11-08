using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.Models;
using System.Globalization;
using CsvHelper;
using ENSEK_Technical_Test.Exceptions;
using ENSEK_Technical_Test.Mappers;

namespace ENSEK_Technical_Test.Services
{
    public class CSVUploadService
    {
        private readonly AccountRepository accountRepository;
        private readonly ReadingRepository readingRepository;
        public CSVUploadService(AccountRepository accountRepository, ReadingRepository readingRepository)
        {
            this.accountRepository = accountRepository;
            this.readingRepository = readingRepository;
        }

        public IList<EnergyReading> GetReadingsFromCSV(IFormFile file)
        {
            IList<EnergyReading> readings = new List<EnergyReading>();
            EnergyAccount energyReading;

            StreamReader sr = new StreamReader(file.OpenReadStream());
            using (var csv = new CsvReader(sr, CultureInfo.GetCultureInfo("en-GB")))
            {
                csv.Context.RegisterClassMap<EnergyReadingMapper>();
                try
                {

                    var isHeader = true;
                    while (csv.Read())
                    {
                        if (isHeader)
                        {
                            csv.ReadHeader();
                            isHeader = false;
                        }
                        else
                        {
                            readings.Add(csv.GetRecord<EnergyReading>());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new CSVFileParseException("An error occured while loading the CSV file");
                }

                foreach (EnergyReading reading in readings)
                {
                    readingRepository.SaveReading(reading);
                }
            }

            return null;
        }


    }
}
