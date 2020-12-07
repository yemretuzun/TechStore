using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SharedModels;
using TechStoreWebApp.Models;

// ReSharper disable once CheckNamespace
namespace TechStoreWebApp.Services
{
    /// <summary>
    /// Request oluştururken kolaylık sağlayan methodlar.
    /// </summary>
    public  static class Extensions
    {
        /// <summary>
        /// HttpResponseMessage'dan istenilen tipte nesneye dönüştür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        public static async Task<T> GetResponse<T>(this HttpResponseMessage httpResponseMessage)
        {
            var apiResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(apiResponse);
        }

        /// <summary>
        /// HttpResponseMessage'dan istenilen tipte nesne listesine dönüştür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetResponses<T>(this HttpResponseMessage httpResponseMessage)
        {
            try
            {
                var apiResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }
            catch (Exception)
            {
                return new List<T>();
            }

        }

        /// <summary>
        /// HttpClient'a Get requesti gönderir ve dönen sonucu verilen tipte nesne olarak döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public static async Task<T> Get_Async<T>(this HttpClient client, string requestUri = "")
        {
            var response = await client.GetAsync(requestUri).ConfigureAwait(false);
            return await response.GetResponse<T>();
        }

        /// <summary>
        /// HttpClient'a Get requesti gönderir ve dönen sonucu verilen tipte nesne listesi olarak döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetAll_Async<T>(this HttpClient client, string requestUri = "")
        {
            var response = await client.GetAsync(requestUri).ConfigureAwait(false);
            return await response.GetResponses<T>();
        }

        public static List<T> GetAll<T>(this HttpClient client, string requestUri = "")
        {
            return GetAll_Async<T>(client, requestUri).GetAwaiter().GetResult();
        }

        /// <summary>
        /// <see cref="HttpClient"/>'a verilen nesneyi Json'a çevirerek Post requesti gönderir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="obj"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Post_Async<T>(this HttpClient client, T obj,string requestUri = "")
        {
            try
            {
                var res = await client.PostAsync(requestUri,
                    new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).ConfigureAwait(false);
                
                return res;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static async Task<HttpResponseMessage> Delete_Async(this HttpClient client, string requestUri = "")
        {
            try
            {
                var res = await client.DeleteAsync(requestUri).ConfigureAwait(false);

                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static async Task<HttpResponseMessage> Update_Async<T>(this HttpClient client, T obj, string requestUri = "")
        {
            try
            {
                var res = await client.PatchAsync(requestUri,
                    new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"))
                    .ConfigureAwait(false);

                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
