using System;
namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class CarBookTripViewModel
    {
        public string CarId { get; set; }

        public string UserId { get; set; }

        public string TripId { get; set; }
        public string CarName { get; set; }

        public DateTime Pickupdate { get; set; }

        public DateTime Returndate { get; set; }

        public int TimeSpend { get; set; }

        public double Amount { get; set; }

        public string Location { get; set; }
    }
}
