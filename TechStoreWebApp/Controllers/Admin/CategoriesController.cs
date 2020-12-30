using System;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SharedModels;
using TechStoreWebApp.Models.ViewModels.Admin;

namespace TechStoreWebApp.Controllers.Admin
{
    [Route("admin/categories/[action]")]
    public class CategoriesController : Controller
    {
        private readonly CategoriesViewModel _categoriesViewModel;

        public CategoriesController()
        {
            _categoriesViewModel = new CategoriesViewModel();
        }

        
        public IActionResult Index()
        {
            return View("~/Views/AdminPanel/Categories/Index.cshtml", _categoriesViewModel);
        }

        [HttpGet]
        [ActionName("create")]
        public IActionResult Create()
        {
            return View("~/Views/AdminPanel/Categories/Create.cshtml", new CategoryInput() { Image = "" });
        }

        [HttpPost]
        [ActionName("create")]
        public IActionResult Create(CategoryInput category)
        {
            var specs = JsonConvert.DeserializeObject<Dictionary<string, string>>(category.specStr);

            var newCategory = new Category()
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                Specs = specs.Values.ToList()
            };
       
            _categoriesViewModel.Service.Create(newCategory);

            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public IActionResult Edit(string id)
        {
            var categoryInput = new CategoryInput();
            var category = _categoriesViewModel.Service.GetById(id);
            categoryInput.Set(category);
            return View("~/Views/AdminPanel/Categories/Edit.cshtml", categoryInput);
        }

        [HttpPost]
        [ActionName("categories/edit")]
        public IActionResult Edit(CategoryInput category)
        {
            var specs = JsonConvert.DeserializeObject<Dictionary<string, string>>(category.specStr);

            var newCategory = new Category()
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                Specs = specs.Values.ToList()
            };


            _categoriesViewModel.Service.Update(newCategory);

            return View("~/Views/AdminPanel/Categories/Index.cshtml", _categoriesViewModel);
        }

        [HttpPost]
        [ActionName("delete/{id}")]
        public IActionResult Delete(string id)
        {

            _categoriesViewModel.Service.Delete(id);

            return View("~/Views/AdminPanel/Categories/Index.cshtml", _categoriesViewModel);
        }
       
    }

    public class CategoryInput : Category
    {
        public string specStr { get; set; }

        public CategoryInput()
        {

        }

        public void Set(Category category)
        {
            Id = category.Id;
            Image = category.Image;
            Name = category.Name;
            Specs = category.Specs;

            var dict = new Dictionary<string, string>();
            var i = 0;
            foreach (var spec in category.Specs)
            {
                dict.Add($"spec_{i}", spec);
                i++;
            }

            specStr = JsonConvert.SerializeObject(category.Specs);
        }
    }

}
