
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class ProductHistoryService : IProductHistoryService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddProductHistory(ProductHistory ProductHistory)
        {
            unitofwork.ProductHistoryRepository.Add(ProductHistory);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<ProductHistory, bool>> where)
        {
            unitofwork.ProductHistoryRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteProductHistory(ProductHistory id)
        {
            unitofwork.ProductHistoryRepository.Delete(id);
            unitofwork.Commit();
        }

        public ProductHistory Get(Expression<Func<ProductHistory, bool>> where)
        {
            return unitofwork.ProductHistoryRepository.Get(where);
        }

        public List<ProductHistory> getAllCategories()
        {
            return unitofwork.ProductHistoryRepository.GetAll().ToList();
        }

        public ProductHistory GetById(long id)
        {
            return unitofwork.ProductHistoryRepository.GetById(id);
        }

        public IEnumerable<ProductHistory> GetMany(Expression<Func<ProductHistory, bool>> where)
        {
            return unitofwork.ProductHistoryRepository.GetMany(where).ToList();
        }

        public void UpdateProductHistory(ProductHistory entity)
        {

            ProductHistory oldEntity= Get(c => c.productHistoryId == entity.productHistoryId);

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

    public interface IProductHistoryService
    {
        void AddProductHistory(ProductHistory ProductHistory);
        List<ProductHistory> getAllCategories();
        void UpdateProductHistory(ProductHistory entity);
        void DeleteProductHistory(ProductHistory id);
        ProductHistory GetById(long id);
        void Delete(Expression<Func<ProductHistory, bool>> where);
        ProductHistory Get(Expression<Func<ProductHistory, bool>> where);
        IEnumerable<ProductHistory> GetMany(Expression<Func<ProductHistory, bool>> where);
    }

}