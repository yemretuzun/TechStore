using Microsoft.AspNetCore.Mvc;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStoreWebApp.Models.ViewModels;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Controllers
{
    public class ProductDetailsController : Controller
    {
        public ProductDetailsViewModel _productDetailsViewModel;
        public ProductsService _productService;
        public ProductDetailsController()
        {
            _productService = new ProductsService();
            _productDetailsViewModel = new ProductDetailsViewModel();
        }


        [HttpGet("p/{productId}")]
        public IActionResult Index(string productId)
        {
            _productDetailsViewModel.ProductId = productId;
            try
            {
                _productDetailsViewModel.Product = _productService.GetById(productId) ?? new Product() { Title = "error" };
            }
            catch (Exception exc) 
            {
                _productDetailsViewModel.Product = null;
            }

            return View("~/Views/ProductDetails.cshtml", _productDetailsViewModel);
        }
    }
}
