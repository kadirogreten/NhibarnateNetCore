using NhibarnateNetCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NhibarnateNetCore.ContextSession
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Vehicle entity);
        Task Delete(Vehicle entity);

        IQueryable<Vehicle> Vehicle { get; }
    }
}
