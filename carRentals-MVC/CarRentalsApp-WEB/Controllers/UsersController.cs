using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalsApp_WEB.Application.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalsApp_WEB.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> TripHistory()
        {
            var userTrips = await _userService.GetUserTripsAsync();

            if (userTrips.IsSuccessful)
            {
                return View(userTrips.Data);
            }

            return View();
        }

        public IActionResult PaymentHistory()
        {
            return View();
        }
    }
}