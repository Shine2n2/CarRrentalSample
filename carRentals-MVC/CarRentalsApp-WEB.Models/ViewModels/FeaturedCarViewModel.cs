using System;
using System.Collections.Generic;
using CarRentalsApp_WEB.Models.Models;

namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class FeaturedCarViewModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public string TypeOfCar  {  get; set; }
        public bool Sunroof { get; set; }
        public bool Bluetooth { get; set; }
        public bool NavigationSystem { get; set; }    
        public bool AirCondition { get; set; }
        public bool RemoteStart { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
