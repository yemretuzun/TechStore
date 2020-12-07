using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;
using TechStoreAPI.Extensions;

using TechStoreAPI.Services;

namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : TechStoreBaseController<Credential>
    {
        public CredentialsController(IConfiguration configuration) : base(configuration)
        {
        }

    }
}
