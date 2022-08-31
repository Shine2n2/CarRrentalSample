using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class LoginResponseViewModel
    {
        public string Id { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public IEnumerable<Claim> Claims { get; set; }

    }
}
