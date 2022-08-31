using System;
namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class CarListingViewModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public string YearOfMan { get; set; }
        public double Price { get; set; }
        public string UnitOfPrice { get; set; }
        public int Rating { get; set; }
        public int NoOfPeople { get; set; }
        public string ImageUrl { get; set; }
    }
}
