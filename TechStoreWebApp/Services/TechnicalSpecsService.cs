using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using SharedModels;

namespace TechStoreWebApp.Services
{
    public class TechnicalSpecsService : BaseService<TechnicalSpecs>
    {
        public TechnicalSpecsService() : base("/api/TechnicalSpecs/")
        {   
        }

        /// <summary>
        /// Kategoriye ait tüm özellikleri getirir.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<TechnicalSpecs> GetByCategory(string categoryId)
        {
            var res = Client.GetAll_Async<TechnicalSpecs>($"byCategory/{categoryId}").Result;;
            return res;
        }

    }
}
