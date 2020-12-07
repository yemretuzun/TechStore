using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
   
    /// <summary>
    /// Sepet.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Sepet ID'si.
        /// </summary>
        [BsonId]
        [BsonRequired]
        public string Id { get; set; }

        /// <summary>
        /// Sepetteki ürünler.
        /// </summary>
        [BsonRequired]
        public IEnumerable<CartItem> Items { get; set; }

        /// <summary>
        /// KDV hariç tutar.
        /// </summary>
        [BsonRequired]
        public float SubTotal { get; set; }

        /// <summary>
        /// Toplam KDV tutarı.
        /// </summary>
        [BsonRequired]
        public float TotalTax { get; set; }

        /// <summary>
        /// Toplam indirim miktarı.
        /// </summary>
        [BsonRequired]
        public float TotalDiscount { get; set; }

        /// <summary>
        /// Sepet toplam tutarı. 
        /// </summary>
        [BsonRequired]
        public float TotalPrice { get; set; }

        
    }
}