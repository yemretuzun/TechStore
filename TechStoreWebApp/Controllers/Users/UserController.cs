using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TechStoreWebApp.Controllers.User
{
    public class UserController : Controller
    {
        [ActionName("hesabim")]
        public IActionResult Index()
        {
            return View("~/Views/User/Profile.cshtml");
        }

    }
}
