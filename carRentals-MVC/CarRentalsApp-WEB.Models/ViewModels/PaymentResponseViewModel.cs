using System;
namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class PaymentResponseViewModel
    {
        public string TripId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionRef { get; set; }
        public string Status { get; set; }
        public string AuthorizationUrl { get; set; }
    }
}
