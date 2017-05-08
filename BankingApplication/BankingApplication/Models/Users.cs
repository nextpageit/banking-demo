using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApplication.Models
{
    public class Users
    {
        public Common.CommonPageObjects CommonObjects = new Common.CommonPageObjects();

        public IEnumerable<NextPage.BankingApplication.Users.User> UserList { get; set; }
    }
}