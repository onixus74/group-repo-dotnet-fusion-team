
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class BuyerRepository : RepositoryBase<Buyer>, IBuyerRepository
    {
        public BuyerRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IBuyerRepository : IRepository<Buyer>
    {

    }
}

