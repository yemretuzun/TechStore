using System.Text;
using Microsoft.AspNetCore.Mvc;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Controllers.Base
{
    
    public class TechStoreBaseController : Controller
    {
        public Services.Services Service { get; set; }

        public TechStoreBaseController()
        {
            Service = new Services.Services();

        }

    }
}
