using CarRentalsApp_WEB.Models.Commons;
using CarRentalsApp_WEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Application.Contracts.IServices
{
    public interface IUserService
    {
        Task<BasicResponse<List<UserTripViewModel>>> GetUserTripsAsync();
    }
}

