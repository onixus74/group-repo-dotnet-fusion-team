
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class BuyerService : IBuyerService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddBuyer(Buyer buyer)
        {
            unitofwork.BuyerRepository.Add(buyer);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<Buyer, bool>> where)
        {
            unitofwork.BuyerRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteBuyer(Buyer id)
        {
            unitofwork.BuyerRepository.Delete(id);
            unitofwork.Commit();
        }

        public Buyer Get(Expression<Func<Buyer, bool>> where)
        {
            return unitofwork.BuyerRepository.Get(where);
        }

        public List<Buyer> getAllCategories()
        {
            return unitofwork.BuyerRepository.GetAll().ToList();
        }

        public Buyer GetById(long id)
        {
            return unitofwork.BuyerRepository.GetById(id);
        }

        public IEnumerable<Buyer> GetMany(Expression<Func<Buyer, bool>> where)
        {
            return unitofwork.BuyerRepository.GetMany(where).ToList();
        }

        public void UpdateBuyer(Buyer entity)
        {

            Buyer oldEntity= Get(c => c.youBayUserId == entity.youBayUserId);

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

    public interface IBuyerService
    {
        void AddBuyer(Buyer buyer);
        List<Buyer> getAllCategories();
        void UpdateBuyer(Buyer entity);
        void DeleteBuyer(Buyer id);
        Buyer GetById(long id);
        void Delete(Expression<Func<Buyer, bool>> where);
        Buyer Get(Expression<Func<Buyer, bool>> where);
        IEnumerable<Buyer> GetMany(Expression<Func<Buyer, bool>> where);
    }

}