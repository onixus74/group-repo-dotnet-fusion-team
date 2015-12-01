using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouBay.Data.Models;

namespace YouBay.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private fusiondbContext dataContext;
        protected fusiondbContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }

        private ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get { return categoryRepository = new CategoryRepository(dbFactory); ; }
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
        
    }
}
