
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class OrderAndReviewService : IOrderAndReviewService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddOrderAndReview(OrderAndReview orderAndReview)
        {
            unitofwork.OrderAndReviewRepository.Add(orderAndReview);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<OrderAndReview, bool>> where)
        {
            unitofwork.OrderAndReviewRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteOrderAndReview(OrderAndReview id)
        {
            unitofwork.OrderAndReviewRepository.Delete(id);
            unitofwork.Commit();
        }

        public OrderAndReview Get(Expression<Func<OrderAndReview, bool>> where)
        {
            return unitofwork.OrderAndReviewRepository.Get(where);
        }

        public List<OrderAndReview> getAllCategories()
        {
            return unitofwork.OrderAndReviewRepository.GetAll().ToList();
        }

        public OrderAndReview GetById(long id)
        {
            return unitofwork.OrderAndReviewRepository.GetById(id);
        }

        public IEnumerable<OrderAndReview> GetMany(Expression<Func<OrderAndReview, bool>> where)
        {
            return unitofwork.OrderAndReviewRepository.GetMany(where).ToList();
        }

        public void UpdateOrderAndReview(OrderAndReview entity)
        {

            OrderAndReview oldEntity= Get(c => c.orderAndReviewId == entity.orderAndReviewId);

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

    public interface IOrderAndReviewService
    {
        void AddOrderAndReview(OrderAndReview orderAndReview);
        List<OrderAndReview> getAllCategories();
        void UpdateOrderAndReview(OrderAndReview entity);
        void DeleteOrderAndReview(OrderAndReview id);
        OrderAndReview GetById(long id);
        void Delete(Expression<Func<OrderAndReview, bool>> where);
        OrderAndReview Get(Expression<Func<OrderAndReview, bool>> where);
        IEnumerable<OrderAndReview> GetMany(Expression<Func<OrderAndReview, bool>> where);
    }

}