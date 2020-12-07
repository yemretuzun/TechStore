using Microsoft.Extensions.Configuration;
using SharedModels;


namespace TechStoreAPI.Services
{
    public class CredentialTypesService : BaseService<CredentialType>
    {
        public CredentialTypesService(IConfiguration configuration) : 
            base(configuration, configuration["MongoDb:CredentialTypesCollectionName"])
        {
        }
        
    }
}
