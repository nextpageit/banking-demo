using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApplication.Models
{
    public class Transactions
    {
        public Common.CommonPageObjects CommonObjects = new Common.CommonPageObjects();


        public IEnumerable<NextPage.BankingApplication.Transactions.Transaction> TransactionList { get; set; }

        public System.Web.Mvc.SelectList UserList { get; set; }

        public NextPage.BankingApplication.Transactions.Transaction TransDetail { get; set; }

        public string Type { get; set; }

        public int UserId { get; set; }

        public int Amount { get; set; }
        public int WithdrawUserId { get; set; }




    }
}