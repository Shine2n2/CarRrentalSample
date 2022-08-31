using System;
using System.Collections;
using CarRentalsApp_WEB.Models.Models;

namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class CarOffersViewModel
    {
       
        public string Model { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }
        public string UnitOfPrice { get; set; }
        public int Rating { get; set; }
        public int Count { get; set; }
        public string ImageUrl { get; set; }
        public Offer Offer { get; set; }


    }
}
