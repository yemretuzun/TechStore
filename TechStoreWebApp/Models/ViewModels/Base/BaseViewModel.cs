using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace TechStoreWebApp.Models.ViewModels
{
    public class BaseViewModel 
    {
        public bool ShowMessage { get; set; }
        public string Message { get; set; }

        public BaseViewModel()
        {
        }

        
    }
}
