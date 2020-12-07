using System;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;

using TechStoreAPI.Services;
using TechStoreAPI.Exceptions;
using TechStoreAPI.Extensions;


namespace TechStoreAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : TechStoreBaseController<User>
    {
        private readonly UserService _userService;

        public UsersController(IConfiguration configuration) : base(configuration)
        {
            _userService = new UserService(configuration);
        }


        /// <summary>
        /// Yeni kullanıcı ekler.
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                var createdUser = _userService.Create(user);

                return StatusCode(StatusCodes.Status201Created, createdUser.JsonSerialize());
            }
            catch (UserExistException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", exc.JsonSerialize());
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

        }

    }
}
