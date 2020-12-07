using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SharedModels;


namespace TechStoreAPI.Services
{
    public class ProductService : BaseService<Product>
    {

        public ProductService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:ProductsCollectionName"])
        {
        }

    }
}