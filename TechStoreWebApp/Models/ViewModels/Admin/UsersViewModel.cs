using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using TechStoreWebApp.Services;

namespace TechStoreWebApp.Models.ViewModels.Admin
{
    public class UsersViewModel
    {
        public readonly UserService Service;

        public UsersViewModel()
        {
            Service = new UserService();
        }


        public List<User> Users => Service.GetAll() ?? new List<User>() { new User() { Id = "veri yok" } };
    }
}
