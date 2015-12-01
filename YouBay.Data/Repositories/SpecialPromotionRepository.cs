
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class SpecialPromotionRepository : RepositoryBase<SpecialPromotion>, ISpecialPromotionRepository
    {
        public SpecialPromotionRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface ISpecialPromotionRepository : IRepository<SpecialPromotion>
    {

    }
}

