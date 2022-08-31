using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalsApp_WEB.Models.Models
{
    public class CarDetail : BaseEntity
    {
        [Key]
        public Guid CarId { get; set; }
        public string TypeOfSeat { get; set; }
        public bool Sunroof { get; set; }
        public bool Bluetooth { get; set; }
        public bool NavigationSystem { get; set; }
        public bool AirCondition { get; set; }
        public bool RemoteStart { get; set; }
        public bool BackUpcamera { get; set; }
        public bool ThirdRowSeating { get; set; }
        public bool Driver { get; set; }
        public bool CarPlay { get; set; }
        public bool IsTrack { get; set; }
    }
}
