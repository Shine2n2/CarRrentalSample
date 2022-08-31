using System.Collections.Generic;

namespace CarRentalsApp_WEB.Models.Models
{
    public class User 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
