
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IProductRepository : IRepository<Product>
    {

    }
}
