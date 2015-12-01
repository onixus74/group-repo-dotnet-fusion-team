
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using YouBay.Data.Infrastructure;
using YouBay.Domain.Entities;

namespace YouBay.Service.Services
{
    public class AssistantItemsService : IAssistantItemsService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork unitofwork = new UnitOfWork(dbFactory);
        public void AddAssistantItems(AssistantItems assistantItems)
        {
            unitofwork.AssistantItemsRepository.Add(assistantItems);
            unitofwork.Commit();
        }

        public void Delete(Expression<Func<AssistantItems, bool>> where)
        {
            unitofwork.AssistantItemsRepository.Delete(where);
            unitofwork.Commit();
        }

        public void DeleteAssistantItems(AssistantItems id)
        {
            unitofwork.AssistantItemsRepository.Delete(id);
            unitofwork.Commit();
        }

        public AssistantItems Get(Expression<Func<AssistantItems, bool>> where)
        {
            return unitofwork.AssistantItemsRepository.Get(where);
        }

        public List<AssistantItems> getAllCategories()
        {
            return unitofwork.AssistantItemsRepository.GetAll().ToList();
        }

        public AssistantItems GetById(long id)
        {
            return unitofwork.AssistantItemsRepository.GetById(id);
        }

        public IEnumerable<AssistantItems> GetMany(Expression<Func<AssistantItems, bool>> where)
        {
            return unitofwork.AssistantItemsRepository.GetMany(where).ToList();
        }

        public void UpdateAssistantItems(AssistantItems entity)
        {

            AssistantItems oldEntity= Get(c => c.assistantItemsId == entity.assistantItemsId);

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

    public interface IAssistantItemsService
    {
        void AddAssistantItems(AssistantItems assistantItems);
        List<AssistantItems> getAllCategories();
        void UpdateAssistantItems(AssistantItems entity);
        void DeleteAssistantItems(AssistantItems id);
        AssistantItems GetById(long id);
        void Delete(Expression<Func<AssistantItems, bool>> where);
        AssistantItems Get(Expression<Func<AssistantItems, bool>> where);
        IEnumerable<AssistantItems> GetMany(Expression<Func<AssistantItems, bool>> where);
    }

}