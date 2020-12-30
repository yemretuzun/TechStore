using System;
using SharedModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TechStoreWebApp.Models.ViewModels;
using TechStoreWebApp.Models.ViewModels.Admin;
using Exception = System.Exception;

namespace TechStoreWebApp.Controllers
{
    [Route("admin/[action]")]
    public class AdminPanelController : Controller
    {
        private readonly AdminPanelViewModel _adminPanelViewModel;
        private readonly BrandsViewModel _brandsViewModel;
        private readonly UsersViewModel _usersViewModel;

        public AdminPanelController()
        {
            _adminPanelViewModel = new AdminPanelViewModel();
            _brandsViewModel = new BrandsViewModel();
            _usersViewModel = new UsersViewModel();
        }


        [Route("/admin")]
        [Route("/admin/Index")]
        public ActionResult Index()
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            return View(_adminPanelViewModel);
        }

        #region Users
        [ActionName("users")]
        public ActionResult Users()
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            return View(_usersViewModel);
        }

        [HttpGet]
        [ActionName("users/create")]
        public ActionResult Createuser()
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            return View("Users/Create");
        }


        [HttpPost]
        [ActionName("users/create")]
        public ActionResult CreateUser(SharedModels.User user)
        {
            if (!((ControllerBase) this).User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            try
            {
             
                _usersViewModel.Service.Create(user);
                return RedirectToAction("users");
            }
            catch (Exception exc)
            {
                return View("Error", new ErrorViewModel() { RequestId = exc.Message });
            }

        }

      

        [ActionName("users/details/{id}")]
        public ActionResult UserDetails(string id)
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            var user = _usersViewModel.Service.GetById(id);

            return View("Users/Details", user);
        }


        [HttpPost]
        [ActionName("users/edit")]
        public ActionResult EditUser(SharedModels.User user)
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            try
            {

                _usersViewModel.Service.Update(user);

                return RedirectToAction("users");
            }
            catch (Exception exc)
            {
                return View("Error", new ErrorViewModel() { Message = exc.Message });
            }
        }

        [ActionName("users/edit/{id}")]
        public ActionResult EditUser(string id)
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            var user = _usersViewModel.Service.GetById(id);
            return View("Users/Edit", user);
        }

        [ActionName("users/delete/{id}")]
        public ActionResult DeleteUser(string id)
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            try
            {
                _usersViewModel.Service.Delete(id);
            }
            catch (Exception exc)
            {
                return View("Error", new ErrorViewModel() { Message = exc.Message });
            }


            return RedirectToActionPreserveMethod("Users", "AdminPanel");

        }
        #endregion

        #region Brands
        [ActionName("brands")]
        public ActionResult Brands()
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            return View("Brands", _brandsViewModel);
        }

        [ActionName("brands/create")]
        public ActionResult BrandsCreate()
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            return View("Brand/Create", new Brand());
        }

        [ActionName("brands/create/")]
        [HttpPost]
        public ActionResult BrandsCreate(Brand brand)
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            try
            {
                _brandsViewModel.Service.Create(brand);

                return RedirectToAction("brands");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [ActionName("brands/details/{id}")]
        public ActionResult BrandsDetails(string id)
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            try
            {
                var brand = _brandsViewModel.Service.GetById(id);

                return View("Brand/Details", brand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        public IActionResult Roles()
        {
            if (!User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Permissions()
        {
            return View();
        }

        public IActionResult Credentials()
        {
            return View();
        }

        public IActionResult CredentialTypes()
        {
            return View();
        }



       
    }
}
