namespace ENSEK_Technical_Test.Models
{
    public class EnergyAccount
    {
        public int Id { get; set; }

        private string firstName { get; set; }

        private string lastName { get; set; }

        private DateTime? lastReading { get; set; }

        private long? meterReading { get; set; }

        public EnergyAccount(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void SetReading(DateTime readingDateTime, long reading)
        {
            if (this.lastReading == null || readingDateTime > this.lastReading)
            {
                this.lastReading = readingDateTime;
                this.meterReading = reading;
            }
        }

        public DateTime GetLastReadingTime()
        {
            if (!this.lastReading.HasValue)
            {
                return (DateTime)lastReading;
            }

            return DateTime.MinValue;
        }

        public long GetMeterReading()
        {
            if (!this.meterReading.HasValue)
            {
                return (long)meterReading!;
            }

            return 0;
        }
    }
}
