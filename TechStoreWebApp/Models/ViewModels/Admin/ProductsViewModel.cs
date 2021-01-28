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
        private IEnumerable<Product> _products;

        public ProductsViewModel()
        {
            Service = new ProductsService();
            CategoryService = new CategoriesService();
            BrandService = new BrandService();
            CreateProduct = new Product();
            TechnicalSpecsService = new TechnicalSpecsService();

            _products = Service.GetAll() ?? new List<Product>() { new Product() { Id = "veri yok" } };
            Sort(SortType.Default);
        }

        public IEnumerable<Product> Products 
        {
            get { return _products; }
            set { _products = value; }
        }

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

        /// <summary>
        /// Ürün sıralama türleri.
        /// </summary>
        public enum SortType 
        {
            /// <summary>
            /// Id'ye göre 
            /// </summary>
            Default,
            /// <summary>
            /// Fiyat artan
            /// </summary>
            Price,
            /// <summary>
            /// Fiyat azalan
            /// </summary>
            PriceDesc, 
            /// <summary>
            /// Puana göre
            /// </summary>
            Ratings,
            /// <summary>
            /// Yorum sayısına göre
            /// </summary>
            Reviews,
        }

        public string SelectedSortType { get; set; }

        /// <summary>
        /// Ürünleri sırala.
        /// </summary>
        public void Sort(SortType sortType) 
        {

            if (sortType == SortType.Price)
            {
                Products = Products.OrderBy(p => p.Price).ToList();
                SelectedSortType = SortType.Price.ToString();
            }
            else if (sortType == SortType.PriceDesc)
            {
                Products = Products.OrderByDescending(p => p.Price).ToList();
                SelectedSortType = SortType.PriceDesc.ToString();

            }
            else if (sortType == SortType.Ratings)
            {
                Products = Products.OrderByDescending(p => p.Ratings).ToList();
                SelectedSortType = SortType.Ratings.ToString();

            }
            else if (sortType == SortType.Reviews)
            {
                Products = Products.OrderByDescending(p => p.Reviews.Count()).ToList();
                SelectedSortType = SortType.Reviews.ToString();
            }
            else
            {
                Products = Products.OrderBy(p => p.Id).ToList();
                SelectedSortType = SortType.Default.ToString();
            }
        }

        public void Sort(string sortType)
        {
            var type = SortType.Default;
            try
            {
                type = Enum.Parse<SortType>(sortType);
            }
            catch (Exception) 
            {
            }

            Sort(type);
        }


    }
}
