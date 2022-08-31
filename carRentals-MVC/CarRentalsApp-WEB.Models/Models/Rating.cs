using System;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Rating : BaseEntity
    {
        public Guid CarId { get; set; }
        public int UserRating { get; set; }
        public Guid UserId { get; set; }
    }
}
