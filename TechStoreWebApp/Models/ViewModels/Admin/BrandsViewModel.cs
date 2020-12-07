using System.Collections.Generic;
using SharedModels;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Models.ViewModels.Admin
{
    public class BrandsViewModel
    {
        public readonly BrandService Service;
        public Brand CreateBrand;

        public BrandsViewModel()
        {
            Service = new BrandService();
            CreateBrand = new Brand();
        }

        public List<Brand> Brands => Service.GetAll() ?? new List<Brand>(){new Brand(){Id = "veri yok"}};
    }
}