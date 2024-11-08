using CsvHelper.Configuration;
using ENSEK_Technical_Test.Models;

namespace ENSEK_Technical_Test.Mappers
{
    public sealed class EnergyAccountMapper : ClassMap<EnergyAccount>
    {
        public EnergyAccountMapper()
        {
            Map(m => m.Id).Name("AccountId");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
        }
    }
}
