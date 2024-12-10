using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Models
{
    public class ResponseUser
    {
        public ResponseUser(User user)
        {
            UserId = user.UserId;
            Name = user.Name;
            Surname = user.Surname;
            Secondname = user.Secondname;
            CarNumber = user.CarNumber;
            Password = user.Password;
            BalanceId = user.BalanceId;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Secondname { get; set; }
        public string CarNumber { get; set; }
        public string Password { get; set; }
        public int BalanceId { get; set; }
    }
}