using System;
using Microsoft.AspNetCore.Mvc;
using TechStoreWebApp.Controllers.Base;
using SharedModels.FormInputs;
using TechStoreWebApp.Models.ViewModels;

namespace TechStoreWebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly AuthViewModel _viewModel;
        public AuthenticationController(IUserManager userManager)
        {
            _userManager = userManager;
            _viewModel = new AuthViewModel();
        }

        public ActionResult Index()
        {
            return View(_viewModel);
        }


        [HttpPost]
        public ActionResult Login(LoginInput input)
        {
            // Giriş yap
            _userManager.SignIn(this.HttpContext, input);
            
            // Anasayfa'ya yönlendir
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Logout()
        {
            _userManager.SignOut(HttpContext);
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register(RegisterInput input)
        {
            var guid = new Guid();
            // Kullanıcıyı kaydet
            _userManager.SignUp(input, "Email", input.Email, guid.ToString());

            // Anasayfa'ya yönlendir
            return RedirectToAction("Index", "Home");
        }

        
    }
}
