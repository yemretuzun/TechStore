using Microsoft.AspNetCore.Mvc;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly UserService _userService;
        private readonly CartService _cartService;

        public PaymentController()
        {
            _userService = new UserService();
            _cartService = new CartService();
        }

        public IActionResult Index()
        {
            return View("~/Views/User/Payment.cshtml");
        }

        public IActionResult Tamamla(PaymentForm form)
        {
            try
            {
                var user = _userService.GetById(form.UserId);
                var order = new Order { 
                    Cart = _cartService.GetUserCart(user.Id).Result,
                    OrderDate = DateTime.Now,
                    ShippingAddress = form.GetAddress()
                };

                // sipariş geçmişine ekle
                user.Orders.Add(order);
                _userService.Update(user);

                // sepeti boşalt
                order.Cart.Items = new List<CartItem>();
                order.Cart.SubTotal = 0;
                order.Cart.TotalDiscount = 0;
                order.Cart.TotalTax = 0;
                order.Cart.TotalPrice = 0;
                _cartService.Update(order.Cart);

                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                return View("Error");
            }

        }

        public class PaymentForm {
            public string UserId { get; set; }
            
            //address
            public string City { get; set; }
            public string Town { get; set; }
            public string District { get; set; }
            public string ZipCode { get; set; }
            public string AddressLine1 { get; set; }
            //card
            public string Name { get; set; }
            public string Surname { get; set; }
            public string CardName { get; set; }
            public string CardNumber { get; set; }
            public string ExpirationDate { get; set; }
            public string CVC { get; set; }

            public Address GetAddress() {
                return new Address()
                {
                    AddressLine1 = AddressLine1,
                    City = City,
                    District = District,
                    ZipCode = ZipCode,
                    Town = Town
                };
            }
        }
    }
}
