
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class HistoryOfViewsRepository : RepositoryBase<HistoryOfViews>, IHistoryOfViewsRepository
    {
        public HistoryOfViewsRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IHistoryOfViewsRepository : IRepository<HistoryOfViews>
    {

    }
}
