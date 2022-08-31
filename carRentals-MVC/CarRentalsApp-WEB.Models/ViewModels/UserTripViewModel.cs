using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Models.ViewModels
{
    public class UserTripViewModel
    {
        public string Id { get; set; }
        public string CarId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string PickUpDate { get; set; }
        public string ReturnDate { get; set; }


    }
}
