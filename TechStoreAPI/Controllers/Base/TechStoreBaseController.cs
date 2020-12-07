using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Services;
using TechStoreAPI.Exceptions;
using TechStoreAPI.Extensions;

namespace TechStoreAPI.Controllers.Base
{
    /* TModel tipinde bir service oluşturur ve temel CRUD işlemlerini yapar
     * 
     */


    /// <summary>
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class TechStoreBaseController<TModel> : ControllerBase
        where TModel: BaseModel
    {
        public readonly BaseService<TModel> Service;

        public TechStoreBaseController(IConfiguration configuration)
        {
            Service = new BaseService<TModel>(configuration, configuration[$"MongoDb:{typeof(TModel).Name}sCollectionName"]);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var users = Service.GetAll();

                users.ForEach(user => user.JsonSerialize());

                return Ok(users);
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exc.JsonSerialize());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string id)
        {
            try
            {
                var user = Service.GetById(id);

                return Ok(user.JsonSerialize());
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exc.JsonSerialize());
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] TModel obj)
        {
            try
            {
                var newObj = Service.Create(obj);

                return StatusCode(StatusCodes.Status201Created, newObj.JsonSerialize());
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

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Patch([FromBody] TModel obj)
        {
            try
            {
                Service.UpdateById(obj.Id, obj);

                return StatusCode(StatusCodes.Status200OK, "Updated successfully.");
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", exc.JsonSerialize());
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(string id)
        {
            try
            {
                Service.DeleteById(id);

                return StatusCode(StatusCodes.Status200OK, "Deleted successfully.");
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", exc.JsonSerialize());
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

        }
    }
}
