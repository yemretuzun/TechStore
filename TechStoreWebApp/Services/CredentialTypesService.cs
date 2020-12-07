using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace TechStoreWebApp.Services
{
    public class CredentialTypesService : BaseService<SharedModels.CredentialType>
    {
        public CredentialTypesService() : base(@"http://localhost:8235/api/CredentialTypes/")
        {
           

        }
    }
}
