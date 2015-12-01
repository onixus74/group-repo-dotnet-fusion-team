
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class SellerService : ISellerService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddSeller(Seller seller)
        {
            unitofwork.SellerRepository.Add(seller);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<Seller, bool>> where)
        {
            unitofwork.SellerRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteSeller(Seller id)
        {
            unitofwork.SellerRepository.Delete(id);
            unitofwork.Commit();
        }

        public Seller Get(Expression<Func<Seller, bool>> where)
        {
            return unitofwork.SellerRepository.Get(where);
        }

        public List<Seller> getAllCategories()
        {
            return unitofwork.SellerRepository.GetAll().ToList();
        }

        public Seller GetById(long id)
        {
            return unitofwork.SellerRepository.GetById(id);
        }

        public IEnumerable<Seller> GetMany(Expression<Func<Seller, bool>> where)
        {
            return unitofwork.SellerRepository.GetMany(where).ToList();
        }

        public void UpdateSeller(Seller entity)
        {

            Seller oldEntity= Get(c => c.youBayUserId == entity.youBayUserId);

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

    public interface ISellerService
    {
        void AddSeller(Seller seller);
        List<Seller> getAllCategories();
        void UpdateSeller(Seller entity);
        void DeleteSeller(Seller id);
        Seller GetById(long id);
        void Delete(Expression<Func<Seller, bool>> where);
        Seller Get(Expression<Func<Seller, bool>> where);
        IEnumerable<Seller> GetMany(Expression<Func<Seller, bool>> where);
    }

}