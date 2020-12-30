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
        [BsonDefaultValue("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Ürüne ait görseller.
        /// </summary>
        public IEnumerable<string> Images { get; set; }

        /// <summary>
        /// Ürün kategorisi
        /// <seealso cref="Category"/>
        /// </summary>
        [BsonDefaultValue("")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Ürün birim fiyatı.
        /// </summary>
        [BsonDefaultValue(0)]
        public float Price { get; set; }

        /// <summary>
        /// Ürüne ait indirim miktarı. 
        /// <para></para>
        /// Default: 0
        /// </summary>
        [BsonDefaultValue(0)]
        public float Discount { get; set; }

        /// <summary>
        /// Ürünün vergi miktarı.
        /// </summary>
        [BsonDefaultValue(0)]
        public uint Tax { get; set; }

        /// <summary>
        /// Ürünün stokta olan miktarı.
        /// </summary>
        [BsonDefaultValue(0)]
        public uint Stock { get; set; }

        /// <summary>
        /// Ürünün markası.
        /// </summary>
        [BsonDefaultValue("")]
        public string BrandId { get; set; }

        /// <summary>
        /// Ürünün rengi.
        /// </summary>
        [BsonDefaultValue(default(string))]
        public string Color { get; set; }

        /// <summary>
        /// Ürünün garanti süresi. (Ay)
        /// </summary>
        [BsonDefaultValue(24)]
        public byte Warranty { get; set; }

        /// <summary>
        /// Ürünün ortalama yıldızı. 0 ile 5 arasında.
        /// </summary>
        [BsonDefaultValue(default(float))]
        public float Ratings { get; set; }

        /// <summary>
        /// Ürüne ait yorumlar.
        /// </summary>
        public IEnumerable<Review> Reviews { get; set; }

        /// <summary>
        /// Ürünün teknik özellikler.
        /// <para></para>
        /// </summary>
        public List<TechnicalSpecs> TechnicalSpecs { get; set; }

        /// <summary>
        /// Ürünü tanımlayan diğer etiketler
        /// </summary>
        public List<string> Tags { get; set; }

    }
}