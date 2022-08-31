using System;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Comment :BaseEntity
    {
        public Guid CarId { get; set; }
        public string Comments { get; set; }
        public Guid UserId { get; set; }
    }
}
