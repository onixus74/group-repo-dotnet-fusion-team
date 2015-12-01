
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class AuctionService : IAuctionService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddAuction(Auction auction)
        {
            unitofwork.AuctionRepository.Add(auction);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<Auction, bool>> where)
        {
            unitofwork.AuctionRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteAuction(Auction id)
        {
            unitofwork.AuctionRepository.Delete(id);
            unitofwork.Commit();
        }

        public Auction Get(Expression<Func<Auction, bool>> where)
        {
            return unitofwork.AuctionRepository.Get(where);
        }

        public List<Auction> getAllCategories()
        {
            return unitofwork.AuctionRepository.GetAll().ToList();
        }

        public Auction GetById(long id)
        {
            return unitofwork.AuctionRepository.GetById(id);
        }

        public IEnumerable<Auction> GetMany(Expression<Func<Auction, bool>> where)
        {
            return unitofwork.AuctionRepository.GetMany(where).ToList();
        }

        public void UpdateAuction(Auction entity)
        {

            Auction oldEntity= Get(c => c.auctionId == entity.auctionId);

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

    public interface IAuctionService
    {
        void AddAuction(Auction auction);
        List<Auction> getAllCategories();
        void UpdateAuction(Auction entity);
        void DeleteAuction(Auction id);
        Auction GetById(long id);
        void Delete(Expression<Func<Auction, bool>> where);
        Auction Get(Expression<Func<Auction, bool>> where);
        IEnumerable<Auction> GetMany(Expression<Func<Auction, bool>> where);
    }

}