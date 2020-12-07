using Newtonsoft.Json;

namespace TechStoreAPI.Extensions
{
    /// <summary>
    /// JsonConvert işlemlerini uzun uzun yazmaktansa daha kolay bir kullanım sağlar.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// JsonConvert.SerializeObject(obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonSerialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// JsonConvert.DeserializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

    }
}
