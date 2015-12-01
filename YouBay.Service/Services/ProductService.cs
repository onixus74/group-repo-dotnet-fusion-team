
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class ProductService : IProductService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddProduct(Product product)
        {
            unitofwork.ProductRepository.Add(product);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<Product, bool>> where)
        {
            unitofwork.ProductRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteProduct(Product id)
        {
            unitofwork.ProductRepository.Delete(id);
            unitofwork.Commit();
        }

        public Product Get(Expression<Func<Product, bool>> where)
        {
            return unitofwork.ProductRepository.Get(where);
        }

        public List<Product> getAllCategories()
        {
            return unitofwork.ProductRepository.GetAll().ToList();
        }

        public Product GetById(long id)
        {
            return unitofwork.ProductRepository.GetById(id);
        }

        public IEnumerable<Product> GetMany(Expression<Func<Product, bool>> where)
        {
            return unitofwork.ProductRepository.GetMany(where).ToList();
        }

        public void UpdateProduct(Product entity)
        {

            Product oldEntity= Get(c => c.productId == entity.productId);

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

    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> getAllCategories();
        void UpdateProduct(Product entity);
        void DeleteProduct(Product id);
        Product GetById(long id);
        void Delete(Expression<Func<Product, bool>> where);
        Product Get(Expression<Func<Product, bool>> where);
        IEnumerable<Product> GetMany(Expression<Func<Product, bool>> where);
    }

}