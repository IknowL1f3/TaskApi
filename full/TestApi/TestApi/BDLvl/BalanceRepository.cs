using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.BDLvl
{
    public class BalanceRepository
    {
        private ParkingEntities db = new ParkingEntities();

        public List<Balance> GetAllBalances()
        {
            return db.Balance.ToList();
        }
        public Balance GetBalanceById(int id)
        {
            return db.Balance.Find(id);
        }

        public void AddBalance(Balance balance)
        {
            db.Balance.Add(balance);
            db.SaveChanges();
        }

        public void UpdateBalance(Balance balance)
        {
            db.Entry(balance).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveBalance(int id)
        {
            var balance = db.Balance.Find(id);
            if (balance != null)
            {
                db.Balance.Remove(balance);
                db.SaveChanges();
            }
        }
    }
}