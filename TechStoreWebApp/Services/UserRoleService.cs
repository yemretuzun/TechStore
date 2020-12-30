using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SharedModels;
using TechStoreWebApp.Models;

namespace TechStoreWebApp.Services
{
    public class UserRoleService : BaseService<UserRole>
    {
        public UserRoleService() : base(@"/api/UserRoles/")
        {
        }

        public async Task<UserRole> Add(UserRole userRole)
        {
           return Create(userRole);
        }
        
        public bool Remove(UserRole userRole)
        {
           return Delete(@$"/delete?userId={userRole.UserId}&roleId={userRole.RoleId}"); ;
        }
    }
}
