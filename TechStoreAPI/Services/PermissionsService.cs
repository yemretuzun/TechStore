using Microsoft.Extensions.Configuration;
using SharedModels;


namespace TechStoreAPI.Services
{
    public class PermissionsService : BaseService<Permission>
    {

        public PermissionsService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:PermissionsCollectionName"]) 
        {
        }

    }
}
