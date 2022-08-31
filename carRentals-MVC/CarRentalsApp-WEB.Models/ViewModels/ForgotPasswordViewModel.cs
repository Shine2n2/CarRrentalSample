using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Email]
        public string Email { get; set; }
    }
}
