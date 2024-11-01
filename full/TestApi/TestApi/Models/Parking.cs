using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Models
{
    public class ResponseParking
    {
        public ResponseParking(Parking parking)
        {
            ParkingId = parking.ParkingId;
            Name = parking.Name;
            Address = parking.Address;
            HourRate = parking.HourRate;
        }

        public int ParkingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? HourRate { get; set; }
    }
}