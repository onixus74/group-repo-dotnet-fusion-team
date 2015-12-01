
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class AssistantItemsRepository : RepositoryBase<AssistantItems>, IAssistantItemsRepository
    {
        public AssistantItemsRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface IAssistantItemsRepository : IRepository<AssistantItems>
    {

    }
}
