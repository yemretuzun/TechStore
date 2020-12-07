using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedModels;
using SharedModels.FormInputs;

namespace TechStoreWebApp.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(): base(@"http://localhost:8235/api/Users/")
        {

        }

        public async Task<User> Register(RegisterInput user)
        {
            var newUser = new User(user);

            var response = await Client.Post_Async(newUser, "register");

            if (response.StatusCode == HttpStatusCode.OK) // Registiration successful
            {
                
                return await response.GetResponse<User>();

            }
            else // Hata! Kullanıcı kayıtlı
            {
                return new User();
            }

        }

    }
}
