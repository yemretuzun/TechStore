
using System.Net.Http;
using SharedModels;

namespace TechStoreWebApp.Services
{
    public class ProductsService : BaseService<Product>
    {
        public ProductsService() : base(@"/api/Products/")
        {
        }
    }
}
