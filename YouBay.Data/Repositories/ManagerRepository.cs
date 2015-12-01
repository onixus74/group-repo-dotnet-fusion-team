
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
        public ManagerRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IManagerRepository : IRepository<Manager>
    {

    }
}

