using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using TechStoreAPI.Extensions;
using MongoDB.Driver;
using SharedModels;

// ReSharper disable once CheckNamespace
namespace TechStoreAPI.Services
{
    /// <summary>
    /// CRUD işlemlerine sahip temel servis.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class BaseService<TModel> where TModel : BaseModel
    {
        public MongoClient MongoClient;
        public IMongoDatabase Database;
        public IMongoCollection<TModel> Collection;

        public BaseService()
        {
            
        }

        public BaseService(IConfiguration configuration)
        {
            MongoClient = new MongoClient(configuration["MongoDb:ConnectionString"]);
            Database = MongoClient.GetDatabase(configuration["MongoDb:DatabaseName"]);
        }

        public BaseService(IConfiguration configuration, string collectionName)
        {
            MongoClient = new MongoClient(configuration["MongoDb:ConnectionString"]);
            Database = MongoClient.GetDatabase(configuration["MongoDb:DatabaseName"]);
            Collection = Database.GetCollection<TModel>(collectionName);
        }

        /// <summary>
        /// Collection'daki tüm nesneleri getirir.
        /// </summary>
        /// <returns></returns>
        public List<TModel> GetAll()
        {
            return Collection.GetAll();
        }

        public TModel GetById( string id)
        {
            return Collection.GetById(id);
        }

        public TModel GetByFilter(Expression<Func<TModel, bool>> filter)
        {
            return Collection.GetByFilter(filter);
        }

        public List<TModel> GetAllByFilter(Expression<Func<TModel, bool>> filter)
        {
            return Collection.GetAllByFilter(filter);
        }

        public TModel Create(TModel obj)
        {
            Collection.Create(obj);
            return obj;
        }


        public void UpdateById(string id, TModel obj) 
        {
            Collection.UpdateById(id, obj);
        }

        public void UpdateByFilter(Expression<Func<TModel, bool>> filter, TModel obj)
        {
            Collection.UpdateByFilter(filter, obj);
        }

      
        public void DeleteById(string id)
        {
            Collection.DeleteById(id);
        }

        public void DeleteByFilter(Expression<Func<TModel, bool>> filter)
        {
            Collection.DeleteByFilter(filter);
        }
    }
}
