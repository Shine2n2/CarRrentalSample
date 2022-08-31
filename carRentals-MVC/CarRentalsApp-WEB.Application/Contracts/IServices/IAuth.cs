
﻿using System;
using System.Threading.Tasks;
using CarRentalsApp_WEB.Models.Commons;
using CarRentalsApp_WEB.Models.ViewModels;

namespace CarRentalsApp_WEB.Application.Contracts.IServices
{
    public interface IAuth
    {

        Task<BasicResponse<LoginResponseViewModel>> Login(LoginResquestViewModel model);
        Task<BasicResponse<string>> Register(SignUpResquestViewModel model);
    }
}
