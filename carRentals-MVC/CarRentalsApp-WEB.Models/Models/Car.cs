using System;
using System.Collections.Generic;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string YearOfMan { get; set; }
        public string PlateNumber { get; set; }
        public string ChasisNumber { get; set; }
        public string Color { get; set; }
        public string TypeOfCar { get; set; }
        public int Mileage { get; set; }
        public double Price { get; set; }
        public string UnitOfPrice { get; set; }
        public bool IsVerify { get; set; }
        public Guid DealerId { get; set; }
        public CarDetail CarDetail { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
