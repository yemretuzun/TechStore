using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using TechStoreWebApp.Models.ViewModels.Admin;

namespace TechStoreWebApp.Controllers.Admin
{
    [Route("admin/products/[action]")]
    public class ProductsController : Controller
    {
        private readonly ProductsViewModel _productsViewModel;

        public ProductsController()
        {
            _productsViewModel = new ProductsViewModel();
        }

        [ActionName("index")]
        public IActionResult Index()
        {
            return View("~/Views/AdminPanel/Product/Index.cshtml", _productsViewModel);
        }

        [HttpGet]
        [ActionName("create")]
        public IActionResult CreateGet()
        {
            return View("~/Views/AdminPanel/Product/Create.cshtml", new Product());
        }


        [HttpPost]
        [ActionName("create")]
        public IActionResult Create(Product product)
        {
            product.Images = product.Images.ElementAtOrDefault(0)?.Split(',');
            
            product.TechnicalSpecs = _productsViewModel.TechnicalSpecsService.GetByCategory(product.CategoryId);
            

            _productsViewModel.Service.Create(product);
            return View("~/Views/AdminPanel/Product/Index.cshtml", _productsViewModel);
        }

        [HttpGet]
        [ActionName("edit/{productId}")]
        public IActionResult EditGet(string productId)
        {
            return View("~/Views/AdminPanel/Product/Edit.cshtml", _productsViewModel.Service.GetById(productId));
        }


        [HttpPost]
        [ActionName("edit")]
        public IActionResult Edit(IFormCollection formCollection)
        {
            var product = new Product()
            {
                Id = formCollection["Id"],
                Title = formCollection["Title"],
                Description = formCollection["Description"],
                BrandId = formCollection["BrandId"],
                CategoryId = formCollection["CategoryId"],
                Color = formCollection["Color"],
                Discount = Convert.ToSingle(formCollection["Discount"]),
                Price = Convert.ToSingle(formCollection["Price"]),
                Ratings = Convert.ToSingle(formCollection["Ratings"]),
                Stock = Convert.ToUInt32(formCollection["Stock"]),
                Tax = Convert.ToUInt32(formCollection["Tax"]),
                Warranty = Convert.ToByte(formCollection["Warranty"]),
                Tags = new List<string>(),
                TechnicalSpecs = new List<TechnicalSpecs>(),
                Images = formCollection["images[]"].ToList()
            };

            var values = formCollection["specValues[]"].ToList();
            var keys = formCollection["specKeys[]"].ToList();
            for (var i = 0; i < keys.Count; i++)
            {
                product.TechnicalSpecs.Add(new TechnicalSpecs()
                {
                    CategoryId = product.CategoryId,
                    Name = keys[i],
                    Value = values[i],
                    DefaultValue = "-"
                });
            }



            _productsViewModel.Service.Update(product);

            return View("~/Views/AdminPanel/Product/Index.cshtml", _productsViewModel);
        }


        [ActionName("delete/{productId}")]
        public IActionResult Delete(string productId)
        {
            _productsViewModel.Service.Delete(productId);

            return View("~/Views/AdminPanel/Product/Index.cshtml", _productsViewModel);
        }
    }
}