using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedModels;

namespace TechStoreAPI.Services
{
    public class TechnicalSpecsService : BaseService<TechnicalSpecs>
    {
        public TechnicalSpecsService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:TechnicalSpecssCollectionName"])
        {
            
        }
    }
}
