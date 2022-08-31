
using CarRentalsApp_WEB.Application.Contracts.IServices;
using CarRentalsApp_WEB.Models;
using CarRentalsApp_WEB.Models.Commons;
using CarRentalsApp_WEB.Models.Models;
using CarRentalsApp_WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _carService = carService;
            _logger = logger;
            
        }

        public async Task<IActionResult> Index()
        {
            var carDetails = await _carService.GetFeaturedCars();

            if (!carDetails.IsSuccessful)
            {
                return NotFound();
            }

            return View(carDetails.Data);
        }

        

        public IActionResult Location()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}