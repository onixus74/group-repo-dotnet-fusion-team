using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddSubcategory(Subcategory subcategory)
        {
            unitofwork.SubcategoryRepository.Add(subcategory);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<Subcategory, bool>> where)
        {
            unitofwork.SubcategoryRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteSubcategory(Subcategory id)
        {
            unitofwork.SubcategoryRepository.Delete(id);
            unitofwork.Commit();
        }

        public Subcategory Get(Expression<Func<Subcategory, bool>> where)
        {
            return unitofwork.SubcategoryRepository.Get(where);
        }

        public List<Subcategory> getAllCategories()
        {
            return unitofwork.SubcategoryRepository.GetAll().ToList();
        }

        public Subcategory GetById(long id)
        {
            return unitofwork.SubcategoryRepository.GetById(id);
        }

        public IEnumerable<Subcategory> GetMany(Expression<Func<Subcategory, bool>> where)
        {
            return unitofwork.SubcategoryRepository.GetMany(where).ToList();
        }

        public void UpdateSubcategory(Subcategory entity)
        {

            Subcategory oldEntity = Get(c => c.subcategoryId == entity.subcategoryId);

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

    public interface ISubcategoryService
    {
        void AddSubcategory(Subcategory subcategory);
        List<Subcategory> getAllCategories();
        void UpdateSubcategory(Subcategory entity);
        void DeleteSubcategory(Subcategory id);
        Subcategory GetById(long id);
        void Delete(Expression<Func<Subcategory, bool>> where);
        Subcategory Get(Expression<Func<Subcategory, bool>> where);
        IEnumerable<Subcategory> GetMany(Expression<Func<Subcategory, bool>> where);
    }

}