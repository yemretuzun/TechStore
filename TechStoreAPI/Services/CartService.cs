using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedModels;
using TechStoreAPI.Extensions;

namespace TechStoreAPI.Services
{
    public class CartService : BaseService<Cart>
    {
        public CartService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:CartsCollectionName"])
        {
        }

    }
}
