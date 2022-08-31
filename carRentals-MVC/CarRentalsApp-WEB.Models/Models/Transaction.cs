using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Transaction:BaseEntity
    {
        [Key]
        public Guid TripId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionRef { get; set; }
        public string Status { get; set; }//status has to be an enum
    }
}
