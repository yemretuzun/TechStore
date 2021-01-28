using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public ProductDetailsViewModel()
        {
        }

       
    }
}
