using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextPage.DatabaseUtil.PetaPoco;
using System.Diagnostics;

namespace NextPage.BankingApplication
{
    public class Users
    {
        [TableNameAttribute("Users"), PrimaryKeyAttribute("UserId")]
        public class User
        {
            public int UserId { get; set; }
            public string UserName { get; set; }


        }

        public  User GetUser(int userId)
        {
            var cmd = Sql.Builder.Select("*").From("Users");
            cmd.Where("UserId=@0", userId);

            Trace.TraceInformation(cmd.SQL);
            using (var db = Common.Database)
            {
                var result = db.FirstOrDefault<User>(cmd);
                Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }

        public void SaveUser(User user)
        {
            using (var db = Common.Database)
            {
                if (string.IsNullOrWhiteSpace(user.UserName))
                    throw new Exception("UserName can't be empty.");              
                db.Save(user);

            }
        }

        public IEnumerable<User> GetUsers(string q)
        {
            var cmd = NextPage.DatabaseUtil.PetaPoco.Sql.Builder.Select("u.*").From("Users As u");
            if (!String.IsNullOrWhiteSpace(q))
            {
                cmd.Where("U.UserName LIKE @0", "%" + q + "%");

            }

            Trace.TraceInformation(cmd.SQL);
            using (var db = Common.Database)
            {
                var result = db.Fetch<User>(cmd);
                Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }


    }
}
