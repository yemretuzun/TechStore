using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using MongoDB.Driver;
using SharedModels;


namespace TechStoreAPI.Extensions
{
    /// <summary>
    /// MongoDb Collection üzerindeki CRUD işlemlerini daha kolay ve anlamlı bir şekilde yapmaya yarayan methodlar.
    /// </summary>
    public static class MongoCollectionExtensions
    {
        // Get işlemleri
        #region Get

        public static List<T> GetAll<T>(this IMongoCollection<T> collection)
        {
            return collection.Find(x => true).ToList();
        }

        public static T GetById<T>(this IMongoCollection<T> collection, string id) where T : BaseModel
        {
            return collection.Find(x => x.Id == id).ToList().FirstOrDefault();
        }

        public static T GetByFilter<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            return collection.Find(filter).ToList().FirstOrDefault();
        }

        #endregion

        // Create işlemleri
        #region Create

        public static void Create<T>(this IMongoCollection<T> collection, T obj) where T : BaseModel
        {
            obj.Id = null; // null olmazsa db ye kaydetmez, dolu olmasına önlem olarak null yap

            collection.InsertOne(obj);
        }

        #endregion

        // Update işlemleri
        #region Update

        public static void UpdateById<T>(this IMongoCollection<T> collection, string id, T obj) where T : BaseModel
        {
            collection.ReplaceOne(x => x.Id == id, obj);
        }

        public static void UpdateByFilter<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter, T obj)
        {
            collection.ReplaceOne(filter, obj);
        }
        
        #endregion

        // Remove işlemleri
        #region Remove

        public static void DeleteById<T>(this IMongoCollection<T> collection, string id) where T : BaseModel
        {
            collection.DeleteOne(x => x.Id == id);
        }

        public static void DeleteByFilter<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            collection.DeleteOne(filter);
        }

        #endregion

    }
}
