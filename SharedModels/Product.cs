using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;


namespace SharedModels
{
    public class Product : BaseModel
    {
        public Product()
        {
            Images = new List<string>();
            Reviews = new List<Review>();
            TechnicalSpecs = new Dictionary<string, string>();
        }

        /// <summary>
        /// Ürün adı.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Ürün açıklaması. HTML destekler.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Ürüne ait görseller.
        /// </summary>
        [BsonRequired]
        public IEnumerable<string> Images { get; set; }

        /// <summary>
        /// Ürün kategorisi
        /// <seealso cref="Category"/>
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue("")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Ürün birim fiyatı.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue(0)]
        public float Price { get; set; }

        /// <summary>
        /// Ürüne ait indirim miktarı. 
        /// <para></para>
        /// Default: 0
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue(0)]
        public float Discount { get; set; }

        /// <summary>
        /// Ürünün vergi miktarı.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue(0)]
        public uint Tax { get; set; }

        /// <summary>
        /// Ürünün stokta olan miktarı.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue(0)]
        public uint Stock { get; set; }

        /// <summary>
        /// Ürünün markası.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue("")]
        public string BrandId { get; set; }

        /// <summary>
        /// Ürünün rengi.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue("siyah")]
        public string Color { get; set; }

        /// <summary>
        /// Ürünün garanti süresi. (Ay)
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue(24)]
        public byte Warranty { get; set; }

        /// <summary>
        ///  Ürünün ortalama yıldızı. 0 ile 5 arasında.
        /// </summary>
        [BsonRequired]
        [BsonDefaultValue(0)]
        public float Ratings { get; set; }

        /// <summary>
        /// Ürüne ait yorumlar.
        /// </summary>
        [BsonRequired]
        public IEnumerable<Review> Reviews { get; set; }

        /// <summary>
        /// Ürünün teknik özellikler.
        /// <para></para>
        /// <example>{"Ram","32 GB"}, {"CPU","Intel Core i9 9900HQ"}, ... </example>
        /// </summary>
        [BsonRequired]
        public Dictionary<string,string> TechnicalSpecs { get; set; }

    }
}