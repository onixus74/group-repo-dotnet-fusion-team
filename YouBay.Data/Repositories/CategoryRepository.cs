using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }
    public interface ICategoryRepository : IRepository<Category>
    {

    }
}
