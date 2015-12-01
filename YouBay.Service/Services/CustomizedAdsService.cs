
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class CustomizedAdsService : ICustomizedAdsService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddCustomizedAds(CustomizedAds customizedAds)
        {
            unitofwork.CustomizedAdsRepository.Add(customizedAds);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<CustomizedAds, bool>> where)
        {
            unitofwork.CustomizedAdsRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteCustomizedAds(CustomizedAds id)
        {
            unitofwork.CustomizedAdsRepository.Delete(id);
            unitofwork.Commit();
        }

        public CustomizedAds Get(Expression<Func<CustomizedAds, bool>> where)
        {
            return unitofwork.CustomizedAdsRepository.Get(where);
        }

        public List<CustomizedAds> getAllCategories()
        {
            return unitofwork.CustomizedAdsRepository.GetAll().ToList();
        }

        public CustomizedAds GetById(long id)
        {
            return unitofwork.CustomizedAdsRepository.GetById(id);
        }

        public IEnumerable<CustomizedAds> GetMany(Expression<Func<CustomizedAds, bool>> where)
        {
            return unitofwork.CustomizedAdsRepository.GetMany(where).ToList();
        }

        public void UpdateCustomizedAds(CustomizedAds entity)
        {

            CustomizedAds oldEntity= Get(c => c.customizedAdsId == entity.customizedAdsId);

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

    public interface ICustomizedAdsService
    {
        void AddCustomizedAds(CustomizedAds customizedAds);
        List<CustomizedAds> getAllCategories();
        void UpdateCustomizedAds(CustomizedAds entity);
        void DeleteCustomizedAds(CustomizedAds id);
        CustomizedAds GetById(long id);
        void Delete(Expression<Func<CustomizedAds, bool>> where);
        CustomizedAds Get(Expression<Func<CustomizedAds, bool>> where);
        IEnumerable<CustomizedAds> GetMany(Expression<Func<CustomizedAds, bool>> where);
    }

}