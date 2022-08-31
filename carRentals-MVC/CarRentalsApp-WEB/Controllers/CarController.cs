using CarRentalsApp_WEB.Application.Contracts.IServices;
using CarRentalsApp_WEB.Models.Enums;
using CarRentalsApp_WEB.Models.Models;
using CarRentalsApp_WEB.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }



        public async Task<IActionResult> Index(int pageSize= 9, int pageNumber = 1)
        {
            var paginatedCars = await _carService.GetAllCarsListing(pageSize, pageNumber);

           
            return View(paginatedCars.Data);
        }

        [Route("Details/{Id}")]
        public async Task<IActionResult> Details(string Id)

        {
            var carDetails = await _carService.GetAllCarDetails(Id);
            return View(carDetails.Data);
        }


        public async Task<IActionResult> Offers(int pageSize = 9, int pageNumber = 1)

        {
            var offerCars = await _carService.GetAllCarsOffers(pageSize, pageNumber);
            return View(offerCars.Data);
        }

        public IActionResult Summary(CarBookTripViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentRequestViewModel model)
        {
            var result = await _carService.CarPayment(model);
            if (result.IsSuccessful)
                return Redirect(result.Data.AuthorizationUrl);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SearchCar(CarSearchViewModel model)
        {
           

            var search = await _carService.CarSearch(model);
            return View(search.Data);
        }


        [HttpPost]
        public async Task<IActionResult> BookCarTrip(CarBookTripViewModel model)
        {
            var loggedinUser = HttpContext.Session.GetString("User");

            if(string.IsNullOrWhiteSpace(loggedinUser))
            {
                HttpContext.Session.SetString("ReturnUrl", Request.Headers["Referer"].ToString());
                ModelState.AddModelError(string.Empty, "You need to login before booking!!!");
                return RedirectToAction("Login", "Auth");
            }

            var user = JsonConvert.DeserializeObject<UserResponseViewModel>(loggedinUser);

            var trip = new TripRequestViewModel()
            {
                CarId = model.CarId,
                UserId = user.Id,
                Pickupdate = model.Pickupdate,
                Returndate = model.Returndate
            };

            var search = await _carService.CarBookTrip(trip);
            model.UserId = user.Id;
            model.TripId = search.Data.Id;
            if(search.IsSuccessful)
                return RedirectToAction("Summary", model);

            return View();
        }
    }
}
