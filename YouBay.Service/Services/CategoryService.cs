using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class CategoryService : ICategoryService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddCategory(Category category)
        {
            utwk.CategoryRepository.Add(category);
            utwk.Commit();
        }

        public void Delete(Expression<Func<Category, bool>> where)
        {
            utwk.CategoryRepository.Delete(where);
            utwk.Commit();
        }

        public void DeleteCategory(Category id)
        {
            utwk.CategoryRepository.Delete(id);
            utwk.Commit();
        }

        public Category Get(Expression<Func<Category, bool>> where)
        {
            return utwk.CategoryRepository.Get(where);
        }

        public List<Category> getAllCategories()
        {
            return utwk.CategoryRepository.GetAll().ToList();
        }

        public Category GetById(long id)
        {
            return utwk.CategoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetMany(Expression<Func<Category, bool>> where)
        {
            return utwk.CategoryRepository.GetMany(where).ToList();
        }

        public void UpdateCategory(Category entity)
        {

            Category oldEntity= Get(c => c.categoryId == entity.categoryId);

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

            utwk.Commit();
        }
    }

    public interface ICategoryService
    {
        void AddCategory(Category category);
        List<Category> getAllCategories();
        void UpdateCategory(Category entity);
        void DeleteCategory(Category id);
        Category GetById(long id);
        void Delete(Expression<Func<Category, bool>> where);
        Category Get(Expression<Func<Category, bool>> where);
        IEnumerable<Category> GetMany(Expression<Func<Category, bool>> where);
    }

}
