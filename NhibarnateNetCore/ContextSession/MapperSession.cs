using NhibarnateNetCore.Models;
using NHibernate;
using System.Linq;
using System.Threading.Tasks;

namespace NhibarnateNetCore.ContextSession
{
    public class MapperSession : IMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public MapperSession(ISession session)
        {
            _session = session;
        }

        public IQueryable<Vehicle> Vehicle => _session.Query<Vehicle> ();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(Vehicle entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(Vehicle entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
