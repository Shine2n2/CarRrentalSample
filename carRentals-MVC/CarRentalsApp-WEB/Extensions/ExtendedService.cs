using CarRentalsApp_WEB.Application.Contracts.IServices;
using CarRentalsApp_WEB.Application.Contracts.Services;
using CarRentalsApp_WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalsApp_WEB.Extensions
{
    public static class ExtendedService
    {
        public static void RegisterAllServices(this IServiceCollection services)
        {
            services.AddTransient<IHttpCommandHandler, HttpCommandHandler>();
            services.AddScoped<IAuth, AuthService>();
            services.AddScoped<ICarService, CarService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
