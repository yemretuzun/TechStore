using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// ReSharper disable once CheckNamespace
namespace SharedModels
{
    /// <summary>
    /// Database işlemlerinde kullanılan nesnelerin temel ve ortak özelliklerini içeren sınıf.
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Id 
        /// </summary>
        [BsonId]
        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public BaseModel()
        {
        }
    }
}
