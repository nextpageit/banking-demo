using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingApplication.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Banking
        public ActionResult Index(int userId)
        {
            try
            {
                var data = new BankingApplication.Models.Transactions();
                using (var db = Common.Database)
                {
                    var transList = Common.Transactions.GetTransactions(userId);
                    if (transList.Any())
                    {
                        data.TransactionList = transList;
                        Trace.TraceInformation("Loaded Transactions list");

                    }
                    data.CommonObjects.PageTitle = "Transactions Dashboard";
                    data.CommonObjects.MetaDescription = "Transactions Dashboard";
                }
                return View(data);

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return null;
        }


        public ActionResult TransactionTypes(int? userId, string type)
        {
            try
            {
                var data = new BankingApplication.Models.Transactions();
                var _userId = Convert.ToInt32(userId);
                data.TransDetail = new NextPage.BankingApplication.Transactions.Transaction();
                if (_userId > 0)
                {
                    //var city = Common.Cities.GetCity(_userId);
                    //if (city == null || city.Id <= 0)
                    //    return RedirectToAction("Cities", new { m = "City not found or deleted" });
                    //data.CityDetails = city;
                   // data.CommonObjects.PageTitle = "Edit City Detail";
                    //data.CommonObjects.MetaDescription = "Edit City Detail";

                }
                data.Type = type;
                data.UserId = _userId;
                data.UserList = new SelectList(Common.Users.GetUsers(null), "UserId", "UserName");
                return View(data);

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return null;
        }
        
        [HttpPost]
        public ActionResult SaveTransaction(BankingApplication.Models.Transactions trans)
        {
            try
            {
                var detail = new NextPage.BankingApplication.Transactions.Transaction
                {
                    Type =  trans.Type,
                    Amount =  trans.Amount,
                    //UserId = trans.WithdrawUserId
                    UserId=(trans.WithdrawUserId > 0 ? trans.WithdrawUserId  : trans.UserId)


                };              
               // trans.Type = trans.Type;
                //trans.UserId = trans.UserId;
                //trans.UserId = trans.UserId;
                Common.Transactions.SaveTransaction(detail);
                if (detail.TransactionId > 0)
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