using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SharedModels;
using TechStoreWebApp.Models;

namespace TechStoreWebApp.Services
{
    public class PermissionService : BaseService<Permission>
    {
        public PermissionService() : base(@"http://localhost:8235/api/Permissions/")
        {
            
        }

      
    }
}
