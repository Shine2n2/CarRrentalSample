
using System.Linq;
using System.Threading.Tasks;
using CarRentalsApp_WEB.Application.Contracts.IServices;
using CarRentalsApp_WEB.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRentalsApp_WEB.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuth _auth;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AuthController(IAuth auth, IHttpContextAccessor httpContextAccessor)
        {
            _auth = auth;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginResquestViewModel model)
        {
            var  response = await _auth.Login(model);

            var result = response.Data;


            if (result == null || !response.IsSuccessful)
            {
                ModelState.AddModelError(string.Empty, "Invalid Credentials");
                return View();
            }


            var user = new UserResponseViewModel()
            {
                Id = result.Claims.ElementAt(0).Value,
                Firstname = result.Claims.ElementAt(2).Value,
                Lastname = result.Claims.ElementAt(3).Value,
                Avatar = result.Claims.ElementAt(4).Value
            };

            var Role = result.Claims.ElementAt(5).Value;
            HttpContext.Session.SetString("role", Role);
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));

            if(Role == null)
            {
                ModelState.AddModelError(string.Empty, "Unable to log you in at this time.");
                return View();
            }

            var returnUrl = HttpContext.Session.GetString("ReturnUrl");
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");


        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult EmailNotification()
        {
            return View();
        }

        
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpResquestViewModel model)
        {
            var result = await _auth.Register(model);

            if(!result.IsSuccessful)
            {
                ModelState.AddModelError(string.Empty, "Registration Failed");
                return View();
            }
            return RedirectToAction("EmailNotification");
        }

        [HttpPost]
        public IActionResult SendForgotPassword(string email1)
        {
            //var forgotPasswordSend = await _auth.ForgotPasswordEmailAsync(email1);

            //if (forgotPasswordSend.IsSuccessful)
            //{
            //    return View("SuccessResponseMail");
            //}
            return View();
        }
    }
}
