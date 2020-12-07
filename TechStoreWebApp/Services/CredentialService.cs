
namespace TechStoreWebApp.Services
{
    public class CredentialService : BaseService<SharedModels.Credential>
    {
        public CredentialService() : base(@"http://localhost:8235/api/Credentials/")
        {
           
        }

    }
}
