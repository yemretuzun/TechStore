
using System.Net.Http;
using SharedModels;

namespace TechStoreWebApp.Services
{
    public class ProductsService : BaseService<Product>
    {
        public ProductsService() : base(@"http://localhost:8235/api/Products/")
        {
        }
    }
}
