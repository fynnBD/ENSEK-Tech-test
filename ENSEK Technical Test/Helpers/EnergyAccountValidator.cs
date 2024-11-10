using ENSEK_Technical_Test.Models;

namespace ENSEK_Technical_Test.Helpers
{
    public static class EnergyAccountValidator
    {
        /// <summary>
        /// Validate a single energyAccount object
        /// </summary>
        /// <param name="energyAccount">object to be validated</param>
        /// <returns>1 if Valid, 0 if Invalid</returns>
        public static bool Validate(EnergyAccount energyAccount)
        {
            if (energyAccount.Id <= 0)
            {
                return false;
            }

            if (energyAccount.FirstName.Length == 0 || energyAccount.LastName.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
