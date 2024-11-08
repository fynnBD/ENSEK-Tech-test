using Microsoft.EntityFrameworkCore;

namespace ENSEK_Technical_Test.Data.Interfaces
{
    public interface IEnergyAccountSeeder
    {
        void Seed(ModelBuilder modelBuilder);
    }
}
