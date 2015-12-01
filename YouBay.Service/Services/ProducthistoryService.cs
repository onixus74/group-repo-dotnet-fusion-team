
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class ProducthistoryService : IProducthistoryService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddProducthistory(Producthistory producthistory)
        {
            unitofwork.ProducthistoryRepository.Add(producthistory);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<Producthistory, bool>> where)
        {
            unitofwork.ProducthistoryRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteProducthistory(Producthistory id)
        {
            unitofwork.ProducthistoryRepository.Delete(id);
            unitofwork.Commit();
        }

        public Producthistory Get(Expression<Func<Producthistory, bool>> where)
        {
            return unitofwork.ProducthistoryRepository.Get(where);
        }

        public List<Producthistory> getAllCategories()
        {
            return unitofwork.ProducthistoryRepository.GetAll().ToList();
        }

        public Producthistory GetById(long id)
        {
            return unitofwork.ProducthistoryRepository.GetById(id);
        }

        public IEnumerable<Producthistory> GetMany(Expression<Func<Producthistory, bool>> where)
        {
            return unitofwork.ProducthistoryRepository.GetMany(where).ToList();
        }

        public void UpdateProducthistory(Producthistory entity)
        {

            Producthistory oldEntity= Get(c => c.producthistoryId == entity.producthistoryId);

            /*
                Sabbegh & Latiri : On utilise les reflections pour parcourir TOUTES les propriétés d'un objet facilement
                On ne s'intéresse qu'au propriété non virtuelle =)
            */

            Type type = oldEntity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (!property.GetGetMethod().IsVirtual)
                { 
                    property.SetValue(oldEntity, property.GetValue(entity, null));
                }
            }

            unitofwork.Commit();
        }
    }

    public interface IProducthistoryService
    {
        void AddProducthistory(Producthistory producthistory);
        List<Producthistory> getAllCategories();
        void UpdateProducthistory(Producthistory entity);
        void DeleteProducthistory(Producthistory id);
        Producthistory GetById(long id);
        void Delete(Expression<Func<Producthistory, bool>> where);
        Producthistory Get(Expression<Func<Producthistory, bool>> where);
        IEnumerable<Producthistory> GetMany(Expression<Func<Producthistory, bool>> where);
    }

}