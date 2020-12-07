using MongoDB.Bson.Serialization.Attributes;


namespace SharedModels
{
    /// <summary>
    /// Marka
    /// </summary>
    public class Brand : BaseModel
    {
        /// <summary>
        /// Marka adı.
        /// </summary>
        [BsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Marka logosu.
        /// </summary>
        [BsonRequired]
        public string LogoImage { get; set; }
    }
}
