using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;


namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : TechStoreBaseController<Product>
    {
        public ProductsController(IConfiguration configuration) : base(configuration)
        {
        }
    }

}
