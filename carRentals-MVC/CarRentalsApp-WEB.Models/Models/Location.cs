using System;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Location :BaseEntity
    {
        public string Address { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid DealerId { get; set; }
    }
}
