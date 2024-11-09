using ENSEK_Technical_Test.Models.Interfaces;

namespace ENSEK_Technical_Test.Models
{
    public class EnergyReading : IEntity
    {
        public int Id { get; set; }

        public DateTime ReadingDateTime { get; set; }

        public long Reading { get; set; }

        public int AccountID { get; set; }
    }
}
