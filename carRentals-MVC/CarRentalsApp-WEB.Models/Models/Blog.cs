using System;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Blog: BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Thumbnail { get; set; }
        public bool IsActive { get; set; }
    }
        
}
