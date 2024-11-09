using ENSEK_Technical_Test.Models.Interfaces;

namespace ENSEK_Technical_Test.Models
{
    public class EnergyAccount : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        private EnergyReading? lastReading { get; set; }

        public void SetReading(EnergyReading? reading)
        {
            this.lastReading = reading;
        }

        public DateTime GetLastReadingTime()
        {
            if (this.lastReading != null)
            {
                return lastReading.ReadingDateTime;
            }

            return DateTime.MinValue;
        }

        public long GetMeterReading()
        {
            if (this.lastReading != null)
            {
                return lastReading.Reading;
            }

            return 0;
        }
    }
}
