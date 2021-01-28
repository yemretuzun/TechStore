using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
    /// <summary>
    /// Ürün değerlendirmesi
    /// </summary>
    public class Review : BaseModel
    {
        /// <summary>
        /// Yorumu yapan kullanıcının ID'si
        /// </summary>
        [BsonRequired]
        public string UserId { get; set; }

        /// <summary>
        /// Değerlendirme başlığı.
        /// </summary>
        [BsonRequired]
        public string Title { get; set; }

        /// <summary>
        /// Ürün yorumu.
        /// </summary>
        [BsonRequired]
        public string Content { get; set; }

        /// <summary>
        /// Ürüne verilen puan. 0-5
        /// </summary>
        [BsonRequired]
        public byte Rating { get; set; }

        /// <summary>
        /// Yorumun yayınlanma tarihi.
        /// </summary>
        [BsonRequired]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Yorumun güncellenme tarihi.
        /// </summary>
        public DateTime UpdateTime { get; set; }

    }
}