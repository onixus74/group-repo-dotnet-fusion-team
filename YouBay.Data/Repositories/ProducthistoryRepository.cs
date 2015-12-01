
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class ProducthistoryRepository : RepositoryBase<Producthistory>, IProducthistoryRepository
    {
        public ProducthistoryRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IProducthistoryRepository : IRepository<Producthistory>
    {

    }
}

