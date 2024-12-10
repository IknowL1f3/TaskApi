using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.BDLvl
{
    public class ParkingEventRepository
    {
        private ParkingEntities db = new ParkingEntities();

        public List<ParkingEvent> GetAllParkingEvents()
        {
            return db.ParkingEvent.ToList();
        }
        public ParkingEvent GetParkingEventById(int id)
        {
            return db.ParkingEvent.Find(id);
        }
        public List<ParkingEvent> GetParkingEventsByUserId(int userId)
        {
            return db.ParkingEvent.Where(pe => pe.UserId == userId).ToList();
        }

        public void AddParkingEvent(ParkingEvent parkingEvent)
        {
            db.ParkingEvent.Add(parkingEvent);
            db.SaveChanges();
        }

        public void UpdateParkingEvent(ParkingEvent parkingEvent)
        {
            db.Entry(parkingEvent).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveParkingEvent(int id)
        {
            var parkingEvent = db.ParkingEvent.Find(id);
            if (parkingEvent != null)
            {
                db.ParkingEvent.Remove(parkingEvent);
                db.SaveChanges();
            }
        }

        public bool ParkingEventExists(int id)
        {
            return db.ParkingEvent.Count(e => e.ParkingEventId == id) > 0;
        }
    }
}