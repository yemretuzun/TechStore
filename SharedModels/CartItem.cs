using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
    public class CartItem
    {
        /// <summary>
        /// CartItem ID'si.
        /// </summary>
        [BsonId]
        [BsonRequired]
        public string Id { get; set; }

        /// <summary>
        /// Ürün Id'si.
        /// </summary>
        [BsonRequired]
        public string ProductId { get; set; }

        /// <summary>
        /// Ürün miktarı.
        /// </summary>
        [BsonRequired]
        public uint Quantity { get; set; }

        /// <summary>
        /// Quantity * Tax
        /// </summary>
        [BsonRequired]
        public float TotalTax { get; set; }

        /// <summary>
        /// Quantity * Discount
        /// </summary>
        [BsonRequired]
        public float TotalDiscount { get; set; }

        /// <summary>
        /// Quantity * TotalPrice
        /// </summary>
        [BsonRequired]
        public float SubTotal { get; set; }

    }
}