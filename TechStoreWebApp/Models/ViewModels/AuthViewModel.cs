using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace TechStoreWebApp.Models.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        public string TermsOfConditions { get; private set; }

        public AuthViewModel()
        {
            try
            {
                TermsOfConditions = File.ReadAllText("TechStore_TermsOfConditions.txt");
            }
            catch (Exception exc)
            {
                TermsOfConditions = exc.Message;
            }
        }



    }
}
