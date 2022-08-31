using System;
using System.Collections.Generic;
using CarRentalsApp_WEB.Application.Contracts.IServices;
using CarRentalsApp_WEB.Models.Commons;
using CarRentalsApp_WEB.Models;
using CarRentalsApp_WEB.Models.ViewModels;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Application.Contracts.Services
{
    public class CarService : ICarService
    {
        private readonly IHttpCommandHandler _httpCommandHandler;

        public CarService(IHttpCommandHandler httpCommandHandler)
        {
            _httpCommandHandler = httpCommandHandler;
        }


        public async Task<BasicResponse<PaginationResponse<IEnumerable<CarListingViewModel>>>> GetAllCarsListing(int pageSize, int pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var carlisting = await _httpCommandHandler.GetRequest<BasicResponse<
                        PaginationResponse<IEnumerable<CarListingViewModel>>>>($"/api/v1/Cars?pageSize={pageSize}&pageNumber={pageNumber}");

            return carlisting;
        }


        public async Task<BasicResponse<List<FeaturedCarViewModel>>> GetFeaturedCars()
        {
            var carResult = await _httpCommandHandler.GetRequest<BasicResponse<List<FeaturedCarViewModel>>>($"/api/v1/Cars/GetFeaturedCars");
            return carResult;
        }

        public async Task<BasicResponse<CarDetailsViewModel>> GetAllCarDetails(string carId)
        {
            var carDetails = await _httpCommandHandler.GetRequest<BasicResponse<CarDetailsViewModel>>($"/api/v1/Cars/Id?Id={carId}");
            return carDetails;
        }



        public async Task<BasicResponse<PaginationResponse<IEnumerable<CarOffersViewModel>>>> GetAllCarsOffers(int pageSize, int pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var carlisting = await _httpCommandHandler.GetRequest<BasicResponse<
                        PaginationResponse<IEnumerable<CarOffersViewModel>>>>($"/api/v1/Cars/GetAllOfferedCars?pageSize={pageSize}&pageNumber={pageNumber}");

            return carlisting;
        }



        

        public async Task<BasicResponse<CarDetailsViewModel>> UploadImage(string carId)
        {
            var img = await _httpCommandHandler.UpdateRequest<BasicResponse<CarDetailsViewModel>, string>(carId, $"/api/v1/Users/Id/UploadImage");
            return img;
        }

        public async Task<BasicResponse<IEnumerable<CarSearchResponseViewModel>>> CarSearch(CarSearchViewModel model)
        {
            
            var carSearch = await _httpCommandHandler.GetRequest<BasicResponse<
                       IEnumerable<CarSearchResponseViewModel>>>($"/api/v1/Cars/SearchCars?state={model.Location}&pickupDate={model.Pickupdate}&returnDate={model.Returndate}");
            return carSearch;
        }

        public async Task<BasicResponse<CarBookTripResponseViewModel>> CarBookTrip(TripRequestViewModel model)
        {

            var carSearch = await _httpCommandHandler.PostRequest<BasicResponse<
                       CarBookTripResponseViewModel>, TripRequestViewModel>(model, $"/api/v1/Cars/BookTrip");
            return carSearch;
        }

        public async Task<BasicResponse<PaymentResponseViewModel>> CarPayment(PaymentRequestViewModel model)
        {

            var carSearch = await _httpCommandHandler.PostRequest<BasicResponse<
                       PaymentResponseViewModel>, PaymentRequestViewModel>(model, $"/api/v1/Cars/PaymentForCarTrip");
            return carSearch;
        }
    }
}
