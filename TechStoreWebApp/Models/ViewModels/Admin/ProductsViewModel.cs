using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using TechStoreWebApp.Services;


namespace TechStoreWebApp.Models.ViewModels.Admin
{
    public class ProductsViewModel
    {
        public readonly ProductsService Service;

        public ProductsViewModel()
        {
            Service = new ProductsService();
        }


        public List<Product> Products =>  Service.GetAll() ?? new List<Product>(){new Product(){Id = "veri yok"}};


    }
}
