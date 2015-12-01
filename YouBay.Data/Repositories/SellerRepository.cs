
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public SellerRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface ISellerRepository : IRepository<Seller>
    {

    }
}

