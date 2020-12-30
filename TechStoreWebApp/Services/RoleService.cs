using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedModels;
using TechStoreWebApp.Models;

namespace TechStoreWebApp.Services
{
    /// <summary>
    /// TechStoreApi kullanarak Role Collection ile ilgili işlemleri gerçekleştirir.
    /// </summary>
    public class RoleService : BaseService<Role>
    {
        public RoleService() : base(@"/api/Role/")
        {
        }
    }
}
