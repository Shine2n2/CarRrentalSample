using System;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Image :BaseEntity
    {
        public Guid CarId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeature { get; set; }
    }
}
