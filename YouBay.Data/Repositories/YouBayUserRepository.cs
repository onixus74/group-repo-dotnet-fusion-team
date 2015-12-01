
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class YouBayUserRepository : RepositoryBase<YouBayUser>, IYouBayUserRepository
    {
        public YouBayUserRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IYouBayUserRepository : IRepository<YouBayUser>
    {

    }
}

