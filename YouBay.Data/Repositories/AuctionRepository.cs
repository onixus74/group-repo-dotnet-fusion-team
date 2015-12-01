
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class AuctionRepository : RepositoryBase<Auction>, IAuctionRepository
    {
        public AuctionRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IAuctionRepository : IRepository<Auction>
    {

    }
}
