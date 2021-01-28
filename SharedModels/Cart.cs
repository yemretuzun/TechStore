using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
   
    /// <summary>
    /// Sepet.
    /// </summary>
    public class Cart : BaseModel
    {
        /// <summary>
        /// Sepetin hangi kullanıcıya ait olduğunu gösterir.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Sepetteki ürünler.
        /// </summary>
        public IEnumerable<CartItem> Items { get; set; }

        /// <summary>
        /// KDV hariç tutar.
        /// </summary>
        public float SubTotal { get; set; }

        /// <summary>
        /// Toplam KDV tutarı.
        /// </summary>
        public float TotalTax { get; set; }

        /// <summary>
        /// Toplam indirim miktarı.
        /// </summary>
        public float TotalDiscount { get; set; }

        /// <summary>
        /// Sepet toplam tutarı. 
        /// </summary>
        public float TotalPrice { get; set; }

        
    }
}