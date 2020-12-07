using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedModels;

namespace TechStoreAPI.Services
{
    public class BrandService : BaseService<Brand>
    {
        public BrandService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:BrandCollectionName"])
        {
        }
    }
}
