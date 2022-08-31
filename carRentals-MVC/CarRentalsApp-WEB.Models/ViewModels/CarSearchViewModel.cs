using System;
namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class CarSearchViewModel
    {
        public string Location{ get; set; }

        public DateTime Pickupdate { get; set; }

        public DateTime Returndate { get; set; }
    }
}
