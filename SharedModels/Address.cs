using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
    /// <summary>
    /// Teslimat adresi.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address ID'si.
        /// </summary>
        [BsonId]
        [BsonRequired]
        public string Id { get; set; }

        /// <summary>
        /// Şehir / İl
        /// </summary>
        [BsonRequired]
        public string City { get; set; }

        /// <summary>
        /// İlçe
        /// </summary>
        [BsonRequired]
        public string Town { get; set; }

        /// <summary>
        /// Mahalle, Köy, Semt
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Posta kodu.
        /// </summary>
        [BsonRequired]
        public string ZipCode { get; set; }

        /// <summary>
        /// Mahalle, sokak, cadde ve diğer bilgiler
        /// </summary>
        [BsonRequired]
        public string AddressLine1 { get; set; }

        
    }
}
