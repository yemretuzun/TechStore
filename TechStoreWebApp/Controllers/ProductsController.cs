using Microsoft.AspNetCore.Mvc;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStoreWebApp.Models.ViewModels.Admin;
using TechStoreWebApp.Services;
using static TechStoreWebApp.Models.ViewModels.Admin.ProductsViewModel;

namespace TechStoreWebApp.Controllers
{
    [Route("products")]
    public class AllProductsController : Controller
    {
        public ProductsViewModel _productsViewModel;

        public AllProductsController()
        {
            _productsViewModel = new ProductsViewModel();
        }

        public IActionResult Index()
        {
            try
            {
                //Todo: api'de mongodb filtereleriyle yap
                var query = HttpContext.Request.Query;

                var brandId = query["brandId"];
                var categoryId = query["categoryId"];
                var orderBy = query["orderBy"];
                var search = query["search"];
                try {
                    search = HttpContext.Request.Form["searchInput"];
                }
                catch (Exception) { search = ""; }

                // Ara
                if (!string.IsNullOrEmpty(search)) {
                    var list = _productsViewModel.Products.TakeWhile(p => p.Title.Contains(search, StringComparison.InvariantCultureIgnoreCase)).ToList();

                    if (list.Any())
                        _productsViewModel.Products = list;
                }

                // Markaya göre Filtrele
                if (!string.IsNullOrEmpty(brandId))
                    _productsViewModel.Products = _productsViewModel.Products.Where(p => p.BrandId == brandId).ToList();

                // Kategoriye göre Filtrele
                if (!string.IsNullOrEmpty(categoryId))
                    _productsViewModel.Products = _productsViewModel.Products.Where(p => p.CategoryId == categoryId).ToList();

                // Sırala
                if (!string.IsNullOrEmpty(orderBy))
                    _productsViewModel.Sort(orderBy);


                return View("~/Views/AllProducts.cshtml", _productsViewModel);

            }
            catch (Exception exc) 
            {
                return View("~/Views/AllProducts.cshtml", new ProductsViewModel());
            }
           

        }
    }
}
