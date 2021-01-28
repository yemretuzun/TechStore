using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager _userManager;
        private readonly CartService _cartService;

        public CartController()
        {
            
            _userManager = new UserManager();
            _cartService = new CartService();
        }

        public IActionResult Index()
        {
            return View("~/Views/User/Cart.cshtml");
        }

        public class MvcCartItem
        {
            public string ProductId { get; set; }
            public string UserId { get; set; }
            public uint Quantity { get; set; }
        }

        public async Task<IActionResult> AddToCart(MvcCartItem cartItem)
        {
            try
            {
                _ = await _cartService.AddProduct(_cartService.GetUserCart(cartItem.UserId).Result.Id, 
                    cartItem.ProductId, 
                    cartItem.Quantity);

                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                // ignored
                Debug.Write(exc);
                return View("Error");
            }

        }

        public async Task<IActionResult> RemoveFromCart(MvcCartItem cartItem)
        {
            try
            {
                _ = await _cartService.RemoveProduct(_cartService.GetUserCart(cartItem.UserId).Result.Id,
                    cartItem.ProductId, 
                    cartItem.Quantity);

                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                // ignored
                Debug.Write(exc);
                return View("Error");
            }

        }
    }
}
