using CarRentalsApp_WEB.Application.Contracts.IServices;
using CarRentalsApp_WEB.Models;
using CarRentalsApp_WEB.Models.Commons;
using CarRentalsApp_WEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Application.Contracts.Services
{
   
        public class UserService : IUserService
        {
            private readonly IHttpCommandHandler _httpCommandHandler;
            public UserService(IHttpCommandHandler httpCommandHandler)
            {
                _httpCommandHandler = httpCommandHandler;
            }

            public async Task<BasicResponse<List<UserTripViewModel>>> GetUserTripsAsync()
            {
                var userTrips = await _httpCommandHandler.GetRequest<BasicResponse<List<UserTripViewModel>>>
                    ("/api/v1/Users/Id/GetUserTrips?Id=7dfa1ecc-2230-444e-9c7e-955119e42ff5");
                return userTrips;
            }

        }
    
}
