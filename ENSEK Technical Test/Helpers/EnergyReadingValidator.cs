using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Services.Repository;
using Microsoft.Build.Framework;

namespace ENSEK_Technical_Test.Helpers
{
    public class EnergyReadingValidator(AccountRepository accountRepository)
    {

        /// <summary>
        /// Validates single readings, logs any error to a dictionary
        /// Returns 1 if valid, 0 if invalid
        /// </summary>
        /// <param name="reading">validated reading</param>
        /// <param name="errorList"> key value dictionary of failure reasons </param>
        /// <returns>0 if Invalid, 1 if Valid</returns>
        public bool Validate(EnergyReading reading, Dictionary<int, string> errorList)
        {
            if (reading.Reading > 99999 || reading.Reading < 0)
            {
                errorList.TryAdd(reading.AccountID, "Reading value (" + reading.Reading + ") outside of range");
                return false;
            }

            if (!accountRepository.GetAll().Any(t => t.Id == reading.AccountID))
            {
                errorList.TryAdd(reading.AccountID, "AccountID (" + reading.AccountID + ") does not exist");
                return false;
            }
            EnergyAccount? energyAccount = (EnergyAccount?)(accountRepository.Get(reading.AccountID)); //Need to grab the associated account to validate from here

            if (energyAccount == null)
            {
                return false;
            }

            if (energyAccount.GetMeterReading() >= reading.Reading)
            {
                errorList.TryAdd(reading.AccountID, "Reading value is less that reading value in database");
                return false;
            }

            if (energyAccount.GetLastReadingTime() >= reading.ReadingDateTime)
            {
                errorList.TryAdd(reading.AccountID, "Reading date is less than reading in database");
                return false;
            }

            return true;
        }

        /// <summary>
        /// remove duplicates from the list of valid readings leaving only the value
        /// with the highest read date
        /// </summary>
        /// <param name="readings"> list of validated readings </param>
        /// <param name="errorList"> key value dictionary of failure reasons </param>
        /// <returns>0 if Invalid, 1 if Valid</returns>
        public IList<EnergyReading> ValidateDuplicates(IList<EnergyReading> readings, Dictionary<int, string> errorList)
        {
            var validReadings = new List<EnergyReading>();
            var groupings = readings.GroupBy(x => x.AccountID);

            foreach (var v in groupings)
            {
                var biggestOne = v.OrderByDescending(i => i.ReadingDateTime).First();
                validReadings.Add(biggestOne);
                if (v.AsEnumerable().Count() > 1)
                {
                    errorList.TryAdd(biggestOne.AccountID, "Duplicate entry, using most recent reading (" + biggestOne.ReadingDateTime + ")");
                }
            }

            return validReadings;
        }
    }
}
