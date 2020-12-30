using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Models.ViewModels.Admin
{
    public class CategoriesViewModel
    {
        /// <summary>
        /// <inheritdoc cref="CategoriesService"/>
        /// </summary>
        public CategoriesService Service;

        public CategoriesViewModel()
        {
            Service = new CategoriesService();
        }

        /// <summary>
        /// Tüm kategorileri getirir
        /// </summary>
        public List<Category> Categories => Service.GetAll();

        /// <summary>
        /// ID si verilen kategori detaylarını getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetCategory(string id) => Service.GetById(id);
    }
}
