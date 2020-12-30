using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{

    /// <summary>
    /// Ürün kategorisi
    /// </summary>
    public class Category : BaseModel
    {

        /// <summary>
        /// Kategori adı.
        /// </summary>
        [BsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Kategori görseli.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Kategoriye ait teknik özellikler
        /// </summary>
        [BsonRequired]
        public List<string> Specs { get; set; }

    }
}