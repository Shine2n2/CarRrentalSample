using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Dealer :BaseEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string Type { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public bool IsActivated { get; set; }
        public string IdentityNumber { get; set; }
        public string SocailMedia { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
