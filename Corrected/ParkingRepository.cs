using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.BDLvl
{
    public class ParkingRepository
    {
        private ParkingEntities5 db = new ParkingEntities5();

        public List<Parking> GetAllParkings()
        {
            return db.Parking.ToList();
        }
        public Parking GetParkingById(int id)
        {
            return db.Parking.Find(id);
        }

        public void AddParking(Parking parking)
        {
            db.Parking.Add(parking);
            db.SaveChanges();
        }

        public void UpdateParking(Parking parking)
        {
            db.Entry(parking).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveParking(int id)
        {
            var parking = db.Parking.Find(id);
            if (parking != null)
            {
                db.Parking.Remove(parking);
                db.SaveChanges();
            }
        }

        public bool ParkingExists(int id)
        {
            return db.Parking.Count(e => e.ParkingId == id) > 0;
        }
    }
}