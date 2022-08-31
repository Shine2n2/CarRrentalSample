using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalsApp_WEB.Models.Commons;
using CarRentalsApp_WEB.Models.ViewModels;


namespace CarRentalsApp_WEB.Application.Contracts.IServices
{
    public interface ICarService
    {
        Task<BasicResponse<PaginationResponse<IEnumerable<CarListingViewModel>>>> GetAllCarsListing(int pageSize, int pageNumber);


        Task<BasicResponse<PaginationResponse<IEnumerable<CarOffersViewModel>>>> GetAllCarsOffers(int pageSize, int pageNumber);

        Task<BasicResponse<CarDetailsViewModel>> GetAllCarDetails(string carId);
        Task<BasicResponse<CarDetailsViewModel>> UploadImage(string carId);

        Task <BasicResponse<List<FeaturedCarViewModel>>> GetFeaturedCars();

        Task<BasicResponse<IEnumerable<CarSearchResponseViewModel>>> CarSearch(CarSearchViewModel model);

        Task<BasicResponse<CarBookTripResponseViewModel>> CarBookTrip(TripRequestViewModel model);

        Task<BasicResponse<PaymentResponseViewModel>> CarPayment(PaymentRequestViewModel model);


    }
}
