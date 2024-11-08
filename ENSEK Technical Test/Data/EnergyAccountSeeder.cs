using System.Globalization;
using CsvHelper;
using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.Data.Interfaces;
using ENSEK_Technical_Test.He;
using ENSEK_Technical_Test.Mappers;
using ENSEK_Technical_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSEK_Technical_Test.Data
{
    public class EnergyAccountSeeder : IEnergyAccountSeeder
    {
        public EnergyAccountContext AccountContext { get; }

        public EnergyAccountSeeder(EnergyAccountContext energyAccountContext)
        {
            this.AccountContext = energyAccountContext;
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            IList<EnergyAccount> accounts = GetData();
            foreach (EnergyAccount account in accounts)
            {
                if (EnergyAccountValidator.Validate(account))
                {
                }
            }

            
            modelBuilder.Entity<EnergyAccount>().HasData(accounts);
        }

        private IList<EnergyAccount> GetData()
        {
            IList<EnergyAccount> accounts = new List<EnergyAccount>();
            EnergyAccount energyAccount;
            string filePath = Path.GetFullPath("Test_Accounts.csv");

            StreamReader sr = new StreamReader(filePath);
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<EnergyAccountMapper>();
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
                        accounts.Add(csv.GetRecord<EnergyAccount>());
                    }
                }

            }

            return accounts;
        }
    }
}
