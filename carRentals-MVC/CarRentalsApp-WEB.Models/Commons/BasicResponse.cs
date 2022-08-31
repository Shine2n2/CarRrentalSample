using System;
using System.Security.Claims;

namespace CarRentalsApp_WEB.Models.Commons
{
    public class BasicResponse<TRes>
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public int ResponseCode { get; set; }
        public TRes Data { get; set; }
       
    }
}
