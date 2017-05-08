using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Users()
        {
            try
            {

                var data = new BankingApplication.Models.Users();

                var userList = Common.Users.GetUsers(null);
                if (userList.Any())
                {
                    data.UserList = userList;
                    Trace.TraceInformation("Loaded User list");

                }
                data.CommonObjects.PageTitle = "Users List";
                data.CommonObjects.MetaDescription = "Users List";

                return View(data);

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return null;
        }

        public ActionResult SaveUser(int? userId)
        {
            try
            {
                var data = new BankingApplication.Models.User();
                var _userId = Convert.ToInt32(userId);
                data.UserDetails = new NextPage.BankingApplication.Users.User();
                data.CommonObjects.PageTitle = "Add User Detail";
                data.CommonObjects.MetaDescription = "Add User Detail";
                if (_userId > 0)
                {
                    var user = Common.Users.GetUser(_userId);
                    if (user == null || user.UserId <= 0)
                        return RedirectToAction("Cities", new { m = "User not found or deleted" });
                    data.UserDetails = user;
                    data.CommonObjects.PageTitle = "Edit User Detail";
                    data.CommonObjects.MetaDescription = "Edit User Detail";

                }


                return View(data);

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveUser(BankingApplication.Models.User user)
        {
            try
            {

                
                Common.Users.SaveUser(user.UserDetails);
                if (user.UserDetails.UserId > 0)
                    return Redirect(Common.MyRoot + "Users/Users");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return Redirect(Common.MyRoot + "Users/Users");
        }

    }
}