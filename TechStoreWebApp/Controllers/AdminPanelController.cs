using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SharedModels;
using TechStoreWebApp.Models.ViewModels;
using TechStoreWebApp.Models.ViewModels.Admin;
using TechStoreWebApp.Services;
using Exception = System.Exception;

namespace TechStoreWebApp.Controllers
{
    [Route("admin/[action]")]
    public class AdminPanelController : Controller
    {
        private readonly AdminPanelViewModel _adminPanelViewModel;
        private readonly ProductsViewModel _productsViewModel;
        private readonly BrandsViewModel _brandsViewModel;

        public AdminPanelController()
        {
            _adminPanelViewModel = new AdminPanelViewModel();
            _productsViewModel = new ProductsViewModel();
            _brandsViewModel = new BrandsViewModel();
        }

        [Route("/admin")]
        [Route("/admin/Index")]
        public ActionResult Index()
        {
            return View(_adminPanelViewModel);
        }


        #region Products
        [ActionName("products")]
        public ActionResult Products()
        {
            return View(_productsViewModel);
        }

        [HttpGet]
        [ActionName("products/create")]
        public ActionResult ProductCreate()
        {
            return View("Products/Create");
        }


        [HttpPost]
        [ActionName("products/create")]
        public ActionResult ProductCreate(Product product)
        {
            try
            {
                var newProduct = new Product()
                {
                    Title = product.Title ?? "Title",
                    Description = product.Description ?? "Description",
                    Price = product.Price,
                    Images = product.Images ?? new List<string>(),
                    Tax = product.Tax,
                    Stock = product.Stock,
                    Discount = product.Discount,
                    BrandId = product.BrandId ?? "",
                    CategoryId = product.CategoryId ?? "",
                    Color = product.Color ?? "black",
                    Ratings = product.Ratings,
                    Warranty = product.Warranty,
                    Reviews = product.Reviews ?? new List<Review>(),
                    TechnicalSpecs = new Dictionary<string, string>()
                };

                _productsViewModel.Service.Create(product);
                return RedirectToAction("products");
            }
            catch (Exception exc)
            {
                return View("Error", new ErrorViewModel(){RequestId = exc.Message});
            }

        }

        [ActionName("products/details/{id}")]
        public ActionResult ProductDetails(string id)
        {
            var product = _productsViewModel.Service.GetById(id);

            return View("Products/Details", product);
        }

        [ActionName("products/edit/{id}")]
        public ActionResult ProductEdit(Product product)
        {
            try
            {
                var newProduct = new Product()
                {
                    Title = product.Title ?? "Title",
                    Description = product.Description ?? "Description",
                    Price = product.Price,
                    Images = product.Images ?? new List<string>(),
                    Tax = product.Tax,
                    Stock = product.Stock,
                    Discount = product.Discount,
                    BrandId = product.BrandId ?? "",
                    CategoryId = product.CategoryId ?? "",
                    Color = product.Color ?? "black",
                    Ratings = product.Ratings,
                    Warranty = product.Warranty,
                    Reviews = product.Reviews ?? new List<Review>(),
                    TechnicalSpecs = new Dictionary<string, string>()
                };

                _productsViewModel.Service.Update(new Product());

                return RedirectToAction("products");
            }
            catch (Exception exc)
            {
                return View("Error", new ErrorViewModel() { Message = exc.Message });
            }
        }

        [ActionName("products/delete/{id}")]
        public ActionResult DeleteProduct(string id)
        {
            try
            {
                _productsViewModel.Service.Delete(id);
            }
            catch (Exception exc)
            {
                return View("Error", new ErrorViewModel() { Message = exc.Message });
            }


            return RedirectToActionPreserveMethod("Products", "AdminPanel");

        }
        #endregion


        #region Users
        public ActionResult Users()
        {
            return View();
        }
        #endregion

        #region Brands
        [ActionName("brands")]
        public ActionResult Brands()
        {
            return View("Brands", _brandsViewModel);
        }

        [ActionName("brands/create")]
        public ActionResult BrandsCreate()
        {
            return View("Brand/Create", new Brand());
        }

        [ActionName("brands/create/")]
        [HttpPost]
        public ActionResult BrandsCreate(Brand brand)
        {
            try
            {
                _brandsViewModel.Service.Create(brand);

                return RedirectToAction("brands");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [ActionName("brands/details/{id}")]
        public ActionResult BrandsDetails(string id)
        {
            try
            {
                var brand = _brandsViewModel.Service.GetById(id);

                return View("Brand/Details", brand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Permissions()
        {
            return View();
        }

        public IActionResult Credentials()
        {
            return View();
        }

        #region CredentialTypes

        public IActionResult CredentialTypes()
        {
            return View();
        }

        #endregion


       
    }
}
