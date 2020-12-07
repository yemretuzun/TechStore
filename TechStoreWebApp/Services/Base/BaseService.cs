using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedModels;
using Exception = System.Exception;

// ReSharper disable once CheckNamespace
namespace TechStoreWebApp.Services
{
    public class BaseService<TModel> where TModel : BaseModel
    {
        public readonly HttpClient Client;

        public BaseService(string baseAddress)
        {
            Client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public List<TModel> GetAll(string requestUrl = "")
        {
            return Client.GetAll_Async<TModel>(requestUrl).Result;
        }

        public TModel GetById(string id)
        {
            return Client.Get_Async<TModel>(id).Result;
        }

        public TModel Create(TModel obj, string requestUrl = "")
        {
            try
            {
                var response = Client.Post_Async(obj, requestUrl).Result;
                
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return response.GetResponse<TModel>().Result;
                }

                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var responseMessage = Client.Delete_Async(id).Result;
                return responseMessage.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(TModel obj)
        {
            try
            {
                _ = Client.Update_Async(obj);
            }
            catch (Exception)
            {
            }
        }

    }
}
