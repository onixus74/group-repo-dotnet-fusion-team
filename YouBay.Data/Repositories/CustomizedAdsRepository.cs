
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class CustomizedAdsRepository : RepositoryBase<CustomizedAds>, ICustomizedAdsRepository
    {
        public CustomizedAdsRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface ICustomizedAdsRepository : IRepository<CustomizedAds>
    {

    }
}
