﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Controllers.Base;
using TechStoreAPI.Extensions;

using TechStoreAPI.Services;

namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialTypesController : TechStoreBaseController<CredentialType>
    {
        public CredentialTypesController(IConfiguration configuration) : base(configuration)
        {
        }
        
    }
}
