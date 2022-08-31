using System;
namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class TripRequestViewModel
    {
        public string CarId { get; set; }

        public string UserId { get; set; }

        public DateTime Pickupdate { get; set; }

        public DateTime Returndate { get; set; }
    }
}
