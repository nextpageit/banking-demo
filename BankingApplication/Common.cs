using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BankingApplication
{
    public class Common
    {

        public static NextPage.BankingApplication.Users Users = new NextPage.BankingApplication.Users();
        public static NextPage.BankingApplication.Transactions Transactions = new NextPage.BankingApplication.Transactions();


        public static NextPage.DatabaseUtil.PetaPoco.Database Database
        {
            get { return new NextPage.DatabaseUtil.PetaPoco.Database(ConfigurationManager.AppSettings["ConnectionStringName"]); }
        }



        public static string MyRoot
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                       HttpContext.Current.Request.ApplicationPath.TrimEnd('/') +
                       "/";
            }

            
        }
        public class CommonPageObjects
        {
            public string MetaDescription;

            public string MyRoot
            {
                get { return Common.MyRoot; }
                set { }
            }
            public string PageTitle { get; set; }

        }

        public static string BaseUrl()
        {
            var url = string.Format("{0}://{1}/", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority);
            return url;
        }

    }
}