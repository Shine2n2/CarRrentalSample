﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Dtos.Request
{
    public class TripBookingRequestDTO
    {
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CarId { get; set; }
        public string UserId { get; set; }
    }
}
