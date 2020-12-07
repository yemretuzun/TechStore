using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SharedModels;
using TechStoreAPI.Exceptions;
using TechStoreAPI.Extensions;


namespace TechStoreAPI.Services
{
   
    public class UserService : BaseService<User>
    {
        public UserService(IConfiguration configuration) : base(configuration,
            configuration["MongoDb:UsersCollectionName"])
        {
            
        }
        
        // new ile BaseService teki Create methodunu eziyoruz
        /// <summary>
        /// Database'e yeni kullanıcı ekle.
        /// </summary>
        /// <param name="user">Eklenecek kullanıcı</param>
        /// <returns><see cref="User"/>: Yeni eklenen kullanıcı (id verilmiş hali)</returns>
        public new User Create(User user)
        {
            // Bu mail ile kullanıcı kayıtlı mı
            var userExist =  Collection.Find(usr => usr.Email == user.Email).ToList().FirstOrDefault();
            
            if (userExist == null) // değil, kayıt yapılabilir
            {
                user.Orders = new List<Order>();
                user.Addresses = new List<Address>(); // addressi daha sonra kaydet, bilgilerimden ve/veya siparişte
                user.CreateTime = DateTime.Now;

                Collection.Create(user);

                return user;
            }
            else // kayıtlı
            {
                throw new UserExistException();
            }
        }
    }
}
