using  Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBay.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        ICategoryRepository CategoryRepository { get; }
    }
}
