using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace Data.Repositories
{
    public class SubcategoryRepository : RepositoryBase<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {

    }
}
