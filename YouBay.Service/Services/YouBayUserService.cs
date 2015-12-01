using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class YouBayUserService : IYouBayUserService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddYouBayUser(YouBayUser youBayUser)
        {
            unitofwork.YouBayUserRepository.Add(youBayUser);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<YouBayUser, bool>> where)
        {
            unitofwork.YouBayUserRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteYouBayUser(YouBayUser id)
        {
            unitofwork.YouBayUserRepository.Delete(id);
            unitofwork.Commit();
        }

        public YouBayUser Get(Expression<Func<YouBayUser, bool>> where)
        {
            return unitofwork.YouBayUserRepository.Get(where);
        }

        public List<YouBayUser> getAllCategories()
        {
            return unitofwork.YouBayUserRepository.GetAll().ToList();
        }

        public YouBayUser GetById(long id)
        {
            return unitofwork.YouBayUserRepository.GetById(id);
        }

        public IEnumerable<YouBayUser> GetMany(Expression<Func<YouBayUser, bool>> where)
        {
            return unitofwork.YouBayUserRepository.GetMany(where).ToList();
        }

        public void UpdateYouBayUser(YouBayUser entity)
        {

            YouBayUser oldEntity= Get(c => c.youBayUserId == entity.youBayUserId);

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

    public interface IYouBayUserService
    {
        void AddYouBayUser(YouBayUser youBayUser);
        List<YouBayUser> getAllCategories();
        void UpdateYouBayUser(YouBayUser entity);
        void DeleteYouBayUser(YouBayUser id);
        YouBayUser GetById(long id);
        void Delete(Expression<Func<YouBayUser, bool>> where);
        YouBayUser Get(Expression<Func<YouBayUser, bool>> where);
        IEnumerable<YouBayUser> GetMany(Expression<Func<YouBayUser, bool>> where);
    }

}
