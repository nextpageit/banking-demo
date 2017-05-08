using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NextPage.BankingApplication
{
   public class Common
    {

        public static NextPage.DatabaseUtil.PetaPoco.Database Database
        {
            get { return new NextPage.DatabaseUtil.PetaPoco.Database(ConfigurationManager.AppSettings["ConnectionStringName"]); }
        }
    }
}
