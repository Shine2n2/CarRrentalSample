using System;
namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class PaymentRequestViewModel
    {
        public string TripId { get; set; }

        public string Email { get; set; }

        public string PaymentMethod { get; set; }

        public double Amount { get; set; }
    }
}
