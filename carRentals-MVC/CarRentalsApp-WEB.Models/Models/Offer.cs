using System;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Offer:BaseEntity
    {
        public Guid CarId { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public string TypeOfOffer { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
