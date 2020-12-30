using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;
using TechStoreAPI.Extensions;

namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalSpecsController : TechStoreBaseController<TechnicalSpecs>
    {
        public TechnicalSpecsController(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Verilen kategoriye ait teknik özellikleri döner
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("byCategory/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByCategory(string categoryId)
        {
            try
            {
                var obj = Service.GetAllByFilter(ts => ts.CategoryId == categoryId);

                obj.ForEach(user => user.JsonSerialize());

                return Ok(obj.JsonSerialize());
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exc.JsonSerialize());
            }
        }
    }
}
