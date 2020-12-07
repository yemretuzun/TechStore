using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;

namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : TechStoreBaseController<Category>
    {
        public CategoriesController(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
