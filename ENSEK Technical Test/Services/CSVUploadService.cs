using ENSEK_Technical_Test.Models;
using System.Globalization;
using CsvHelper;
using ENSEK_Technical_Test.Exceptions;
using ENSEK_Technical_Test.Mappers;

namespace ENSEK_Technical_Test.Services
{
    /// <summary>
    /// Class <c>CsvUploadService</c> reads a CSV file and returns
    /// a list of EnergyReading Objects
    /// </summary>
    public class CsvUploadService
    {
        /// <summary>
        /// reads a CSV file and returns
        /// a list of EnergyReading Objects
        /// </summary>
        public IList<EnergyReading> GetReadingsFromCsv(IFormFile file)
        {
            IList<EnergyReading> readings = new List<EnergyReading>();

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
                catch
                {
                    throw new CsvFileParseException("An error occured while loading the CSV file at row " + csv.CurrentIndex);
                }
            }

            return readings;
        }


    }
}
