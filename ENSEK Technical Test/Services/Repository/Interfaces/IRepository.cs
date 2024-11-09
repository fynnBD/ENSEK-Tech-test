using ENSEK_Technical_Test.Models.Interfaces;

namespace ENSEK_Technical_Test.Services.Repository.Interfaces
{
    public interface IRepository
    {
        IEnumerable<IEntity> GetAll(int id);

        void Save(IEntity entity);
    }
}
