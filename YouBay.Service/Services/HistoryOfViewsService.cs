
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class HistoryOfViewsService : IHistoryOfViewsService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddHistoryOfViews(HistoryOfViews historyOfViews)
        {
            unitofwork.HistoryOfViewsRepository.Add(historyOfViews);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<HistoryOfViews, bool>> where)
        {
            unitofwork.HistoryOfViewsRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteHistoryOfViews(HistoryOfViews id)
        {
            unitofwork.HistoryOfViewsRepository.Delete(id);
            unitofwork.Commit();
        }

        public HistoryOfViews Get(Expression<Func<HistoryOfViews, bool>> where)
        {
            return unitofwork.HistoryOfViewsRepository.Get(where);
        }

        public List<HistoryOfViews> getAllCategories()
        {
            return unitofwork.HistoryOfViewsRepository.GetAll().ToList();
        }

        public HistoryOfViews GetById(long id)
        {
            return unitofwork.HistoryOfViewsRepository.GetById(id);
        }

        public IEnumerable<HistoryOfViews> GetMany(Expression<Func<HistoryOfViews, bool>> where)
        {
            return unitofwork.HistoryOfViewsRepository.GetMany(where).ToList();
        }

        public void UpdateHistoryOfViews(HistoryOfViews entity)
        {

            HistoryOfViews oldEntity= Get(c => (c.buyerId == entity.buyerId) && (c.productId == entity.productId) && (c.theDate == entity.theDate));

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

    public interface IHistoryOfViewsService
    {
        void AddHistoryOfViews(HistoryOfViews historyOfViews);
        List<HistoryOfViews> getAllCategories();
        void UpdateHistoryOfViews(HistoryOfViews entity);
        void DeleteHistoryOfViews(HistoryOfViews id);
        HistoryOfViews GetById(long id);
        void Delete(Expression<Func<HistoryOfViews, bool>> where);
        HistoryOfViews Get(Expression<Func<HistoryOfViews, bool>> where);
        IEnumerable<HistoryOfViews> GetMany(Expression<Func<HistoryOfViews, bool>> where);
    }

}