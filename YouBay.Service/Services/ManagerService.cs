
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class ManagerService : IManagerService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddManager(Manager manager)
        {
            unitofwork.ManagerRepository.Add(manager);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<Manager, bool>> where)
        {
            unitofwork.ManagerRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteManager(Manager id)
        {
            unitofwork.ManagerRepository.Delete(id);
            unitofwork.Commit();
        }

        public Manager Get(Expression<Func<Manager, bool>> where)
        {
            return unitofwork.ManagerRepository.Get(where);
        }

        public List<Manager> getAllCategories()
        {
            return unitofwork.ManagerRepository.GetAll().ToList();
        }

        public Manager GetById(long id)
        {
            return unitofwork.ManagerRepository.GetById(id);
        }

        public IEnumerable<Manager> GetMany(Expression<Func<Manager, bool>> where)
        {
            return unitofwork.ManagerRepository.GetMany(where).ToList();
        }

        public void UpdateManager(Manager entity)
        {

            Manager oldEntity= Get(c => c.managerId == entity.managerId);

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

    public interface IManagerService
    {
        void AddManager(Manager manager);
        List<Manager> getAllCategories();
        void UpdateManager(Manager entity);
        void DeleteManager(Manager id);
        Manager GetById(long id);
        void Delete(Expression<Func<Manager, bool>> where);
        Manager Get(Expression<Func<Manager, bool>> where);
        IEnumerable<Manager> GetMany(Expression<Func<Manager, bool>> where);
    }

}