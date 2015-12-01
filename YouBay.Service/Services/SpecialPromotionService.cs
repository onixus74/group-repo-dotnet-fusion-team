
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class SpecialPromotionService : ISpecialPromotionService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddSpecialPromotion(SpecialPromotion specialPromotion)
        {
            unitofwork.SpecialPromotionRepository.Add(specialPromotion);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<SpecialPromotion, bool>> where)
        {
            unitofwork.SpecialPromotionRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteSpecialPromotion(SpecialPromotion id)
        {
            unitofwork.SpecialPromotionRepository.Delete(id);
            unitofwork.Commit();
        }

        public SpecialPromotion Get(Expression<Func<SpecialPromotion, bool>> where)
        {
            return unitofwork.SpecialPromotionRepository.Get(where);
        }

        public List<SpecialPromotion> getAllCategories()
        {
            return unitofwork.SpecialPromotionRepository.GetAll().ToList();
        }

        public SpecialPromotion GetById(long id)
        {
            return unitofwork.SpecialPromotionRepository.GetById(id);
        }

        public IEnumerable<SpecialPromotion> GetMany(Expression<Func<SpecialPromotion, bool>> where)
        {
            return unitofwork.SpecialPromotionRepository.GetMany(where).ToList();
        }

        public void UpdateSpecialPromotion(SpecialPromotion entity)
        {

            SpecialPromotion oldEntity= Get(c => c.specialPromotionId == entity.specialPromotionId);

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

    public interface ISpecialPromotionService
    {
        void AddSpecialPromotion(SpecialPromotion specialPromotion);
        List<SpecialPromotion> getAllCategories();
        void UpdateSpecialPromotion(SpecialPromotion entity);
        void DeleteSpecialPromotion(SpecialPromotion id);
        SpecialPromotion GetById(long id);
        void Delete(Expression<Func<SpecialPromotion, bool>> where);
        SpecialPromotion Get(Expression<Func<SpecialPromotion, bool>> where);
        IEnumerable<SpecialPromotion> GetMany(Expression<Func<SpecialPromotion, bool>> where);
    }

}