using System;
using System.Collections.Generic;

namespace CarRentalsApp_WEB.Models.Models
{
    public class Trip : BaseEntity
    {
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; }//has to be an enum
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
