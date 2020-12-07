using Microsoft.Extensions.Configuration;
using SharedModels;


namespace TechStoreAPI.Services
{
    public class RolePermissionService : BaseService<RolePermission>
    {

        public RolePermissionService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:RolePermissionsCollectionName"])
        {
        }
    }
}
