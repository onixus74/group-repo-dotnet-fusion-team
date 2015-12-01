
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class ProductHistoryRepository : RepositoryBase<ProductHistory>, IProductHistoryRepository
    {
        public ProductHistoryRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IProductHistoryRepository : IRepository<ProductHistory>
    {

    }
}

