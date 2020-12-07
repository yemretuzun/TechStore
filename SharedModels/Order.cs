using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
    /// <summary>
    /// Sipariş.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Sipariş ID'si.
        /// </summary>
        [BsonId]
        [BsonRequired]
        public string Id { get; set; }

        /// <summary>
        /// Sipariş verilen ürünler. Sipariş detayı.
        /// </summary>
        [BsonRequired]
        public Cart Cart { get; set; }

        /// <summary>
        /// Sipariş verilme tarihi.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Siparişin gönderildiği adres.
        /// </summary>
        public Address ShippingAddress { get; set; }


    }
}