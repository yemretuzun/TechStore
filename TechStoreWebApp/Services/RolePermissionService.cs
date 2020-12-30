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
    public class RolePermissionService : BaseService<RolePermission>
    {
        public RolePermissionService() : base(@"/api/RolePermission/")
        {
        }
       
    }
}
