
namespace TechStoreWebApp.Services
{
    public class CredentialService : BaseService<SharedModels.Credential>
    {
        public CredentialService() : base(@"/api/Credentials/")
        {
           
        }

    }
}
