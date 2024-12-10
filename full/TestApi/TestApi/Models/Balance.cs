using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Models
{
    public class ResponseBalance
    {
        public ResponseBalance(Balance balance) 
        {
            BalanceId = balance.BalanceId;
            Balance = balance.Balance1;
        }

        public int BalanceId { get; set; }
        public decimal Balance { get; set; }
    }
}