using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.BDLvl
{
    public class UserRepository
    {
        private ParkingEntities db = new ParkingEntities();

        public List<User> GetAllUsers()
        {
            return db.User.ToList();
        }
        public User GetUserById(int id)
        {
            return db.User.Find(id);
        }
        public User GetUserByCarNumber(string carNumber)
        {
            return db.User.FirstOrDefault(u => u.CarNumber == carNumber);
        }

        public void AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            var user = db.User.Find(id);
            if (user != null)
            {
                db.User.Remove(user);
                db.SaveChanges();
            }
        }
    }
}