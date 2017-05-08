using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApplication.Models
{
    public class User
    {
        public Common.CommonPageObjects CommonObjects = new Common.CommonPageObjects();


        public NextPage.BankingApplication.Users.User UserDetails { get; set; }
    }
}