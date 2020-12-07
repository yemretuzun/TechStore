using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;


namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : TechStoreBaseController<RolePermission>
    {
        public RolePermissionController(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
