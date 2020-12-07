using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
    /// <summary>
    /// Ürün değerlendirmesi
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Yorum ID'si.
        /// </summary>
        [BsonId]
        [BsonRequired]
        public string Id { get; set; }

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
        /// Yorumu yapan kullanıcının adı. FirstName + LastName
        /// </summary>
        [BsonRequired]
        public string UserName { get; set; }

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