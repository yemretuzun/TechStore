using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;
using TechStoreAPI.Extensions;
using TechStoreAPI.Services;

namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : TechStoreBaseController<Cart>
    {
        private readonly ProductService _productService;

        public CartController(IConfiguration configuration) : base(configuration)
        {
            _productService = new ProductService(configuration);
        }

        [HttpGet("GetUserCart")]
        public ActionResult GetUserCart(string userId)
        {
            try
            {
                return Ok(Service.GetByFilter(x => x.UserId == userId).JsonSerialize());
            }
            catch (Exception)
            {
                return StatusCode(500, "");
            }

        }

        /// <summary>
        /// Kullanıcının sepetine yeni ürün ekle.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPatch("AddProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddProduct(string cartId, string productId, uint quantity = 1)
        {
            var cart = Service.GetById(cartId);
            var product = _productService.GetById(productId);

            try // varsa quantity güncelle
            {
                cart.Items.First(i => i.ProductId == productId).Quantity += quantity;
            }
            catch (Exception) // yoksa ekle
            {
                var cartItems = cart.Items.ToList();
                cartItems.Add(new CartItem()
                {
                    ProductId = productId,
                    Quantity = quantity,
                });
                cart.Items = cartItems;
            }

            var tax = (product.Price * product.Tax) / 100f;
            cart.TotalTax += tax * quantity;
            cart.TotalPrice += product.Price * quantity;
            cart.SubTotal = cart.TotalPrice - cart.TotalTax;

            Service.UpdateById(cartId, cart);

            return Ok("Product added to cart.");
        }


        [HttpPatch("RemoveProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult RemoveProduct(string cartId, string productId, uint quantity = 1)
        {
            var cart = Service.GetById(cartId);
            var product = _productService.GetById(productId);

            try // ürün varsa
            {
                var cartItems = cart.Items.ToList();
                var q = Convert.ToInt32(cartItems.First(i => i.ProductId == productId).Quantity);
                q -= Convert.ToInt32(quantity);

                if (q <= 0)
                {
                    cartItems.Remove(cartItems.First(i => i.ProductId == productId));
                }
                else
                {
                    cartItems.First(i => i.ProductId == productId).Quantity -= quantity;
                }

                var tax = (product.Price * product.Tax) / 100f;
                cart.TotalTax -= tax * quantity;
                cart.TotalPrice -= product.Price * quantity;
                cart.SubTotal = cart.TotalPrice - cart.TotalTax;


                cart.Items = cartItems;

                Service.UpdateById(cartId, cart);

                return Ok("Product removed from cart.");
            }
            catch (Exception) // ürün yoksa 
            {
                return BadRequest("Product not found in cart.");
            }

        }
    }
}
