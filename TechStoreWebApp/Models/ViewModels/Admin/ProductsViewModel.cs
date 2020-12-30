using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SharedModels;
using TechStoreWebApp.Services;


namespace TechStoreWebApp.Models.ViewModels.Admin
{
    public class ProductsViewModel
    {
        public readonly ProductsService Service;
        public readonly CategoriesService CategoryService;
        public readonly BrandService BrandService;
        public readonly TechnicalSpecsService TechnicalSpecsService;
        public Product CreateProduct;

        public ProductsViewModel()
        {
            Service = new ProductsService();
            CategoryService = new CategoriesService();
            BrandService = new BrandService();
            CreateProduct = new Product();
            TechnicalSpecsService = new TechnicalSpecsService();
        }


        public IEnumerable<Product> Products =>  Service.GetAll() ?? new List<Product>(){new Product(){Id = "veri yok"}};

        public Category ProductCategory(string id) => CategoryService.GetById(id);

        public IEnumerable<SelectListItem> Brands
        {
            get
            {
                var items = new List<SelectListItem>();
                var brands = BrandService.GetAll();
                
                foreach (var brand in brands)
                {
                    items.Add(new SelectListItem(brand.Name, brand.Id));
                }

                return items;

            }
        }

        public IEnumerable<SelectListItem> Categories
        {
            get
            {
                var items = new List<SelectListItem>();
                var categories = CategoryService.GetAll();

                foreach (var category in categories)
                {
                    items.Add(new SelectListItem(category.Name, category.Id));
                }

                return items;

            }
        }

        public IEnumerable<SelectListItem> TechnicalSpecsListItems(string categoryId)
        {
            
            var items = new List<SelectListItem>();
            var specs =  TechnicalSpecsService.GetByCategory(categoryId);

            foreach (var spec in specs)
            {
                items.Add(new SelectListItem(spec.Name, spec.Id));
            }

            return items;

            
        }


    }
}
