using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TechStoreAPI.Controllers.Base;
using SharedModels;

namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : TechStoreBaseController<UserRole>
    {
        public UserRolesController(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
