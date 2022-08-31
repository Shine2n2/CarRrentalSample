using System;
using System.Threading.Tasks;
using CarRentalsApp_WEB.Application.Contracts.IServices;
using CarRentalsApp_WEB.Models;
using CarRentalsApp_WEB.Models.Commons;
using CarRentalsApp_WEB.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;




namespace CarRentalsApp_WEB.Application.Contracts.Services
{
    public class AuthService : IAuth
    {
        private readonly IHttpCommandHandler _httpCommandHandler;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AuthService(IHttpCommandHandler httpCommandHandler, IHttpContextAccessor httpContextAccessor)
        {
            _httpCommandHandler = httpCommandHandler;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BasicResponse<LoginResponseViewModel>> Login(LoginResquestViewModel model)
        {
            var handler = new JwtSecurityTokenHandler();


            var result = await _httpCommandHandler.PostRequest<BasicResponse<LoginResponseViewModel>, LoginResquestViewModel>(
                model, "/api/v1/Authentication/login");

            if (result.IsSuccessful)
            {
                _session.SetString("token", result.Data.Token);
                _session.SetString("refreshtoken", result.Data.RefreshToken);

                JwtSecurityToken decodedValue = handler.ReadJwtToken(result.Data.Token);

                result.Data.Claims = decodedValue.Claims;

                return result;
            }

            return result;

        }


        public async Task<BasicResponse<string>> Register(SignUpResquestViewModel model)
        {
            var result = await _httpCommandHandler.PostRequest<BasicResponse<string>, SignUpResquestViewModel>(
                model, "/api/v1/Authentication/register");


            return result;

        }

    }
}
