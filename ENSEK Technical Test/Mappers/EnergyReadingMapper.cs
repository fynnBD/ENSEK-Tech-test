using System.Globalization;
using CsvHelper.Configuration;
using ENSEK_Technical_Test.Models;
using Microsoft.SqlServer.Server;

namespace ENSEK_Technical_Test.Mappers
{
    public sealed class EnergyReadingMapper : ClassMap<EnergyReading>
    {
        public EnergyReadingMapper()
        {
            Map(m => m.AccountID).Name("AccountId");
            Map(m => m.ReadingDateTime).Name("MeterReadingDateTime");
            Map(m => m.Reading).Name("MeterReadValue");
          
        }
    }
}