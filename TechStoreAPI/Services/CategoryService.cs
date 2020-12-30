using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedModels;

namespace TechStoreAPI.Services
{
    public class CategoryService : BaseService<Category>
    {
        public CategoryService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:CategoriessCollectionName"])
        {
        }
    }

}
