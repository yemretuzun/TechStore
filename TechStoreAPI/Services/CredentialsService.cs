using Microsoft.Extensions.Configuration;
using SharedModels;


namespace TechStoreAPI.Services
{
    public class CredentialsService : BaseService<Credential>
    {
        public CredentialsService(IConfiguration configuration) :
            base(configuration, configuration["MongoDb:CredentialsCollectionName"])
        {
        }

    }
}
