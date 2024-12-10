using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Models
{
    public class ResponseParkingEvent
    {
        public ResponseParkingEvent(ParkingEvent parkingEvent)
        {
            ParkingEventId = parkingEvent.ParkingEventId;
            EntryTime = parkingEvent.EntryTime;
            DepartureTime = parkingEvent.DepartureTime;
            PaymentState = parkingEvent.PaymentState;
            UserId = parkingEvent.UserId;
            ParkingId = parkingEvent.ParkingId;
        }
        public int ParkingEventId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public int PaymentState { get; set; }
        public int UserId { get; set; }
        public int ParkingId { get; set; }
    }
}