using Data.Repositories;
using System;

namespace YouBay.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        /* ---------------------------------------------------------------------- */
        ICategoryRepository CategoryRepository { get; }
        ISubcategoryRepository SubcategoryRepository { get; }
        /* ---------------------------------------------------------------------- */

    }
}
