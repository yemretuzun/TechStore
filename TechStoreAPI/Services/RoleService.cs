using Microsoft.Extensions.Configuration;
using SharedModels;


namespace TechStoreAPI.Services
{
    public class RoleService : BaseService<Role>
    {
        public RoleService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:RolesCollectionName"])
        {
        }

        
    }
}
