
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class OrderAndReviewRepository : RepositoryBase<OrderAndReview>, IOrderAndReviewRepository
    {
        public OrderAndReviewRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IOrderAndReviewRepository : IRepository<OrderAndReview>
    {

    }
}
