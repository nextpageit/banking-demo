using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextPage.DatabaseUtil.PetaPoco;
using System.Diagnostics;


namespace NextPage.BankingApplication
{

    public class Transactions
    {
        [TableNameAttribute("Transactions"), PrimaryKeyAttribute("TransactionId")]
        public class Transaction
        {
            public int TransactionId { get; set; }
            public string Type { get; set; }
            public int Amount { get; set; }
            public int UserId { get; set; }

        }

        public Transaction GetTransaction(int userId)
        {
            var cmd = Sql.Builder.Select("*").From("Transactions");
            cmd.Where("TransactionId=@0", userId);

            Trace.TraceInformation(cmd.SQL);
            using (var db = Common.Database)
            {
                var result = db.FirstOrDefault<Transaction>(cmd);
                Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }

        public void SaveTransaction(Transaction trans)
        {
            using (var db = Common.Database)
            {
                //if (string.IsNullOrWhiteSpace(trans))
                //    throw new Exception("Question can't be empty.");
                db.Save(trans);

            }
        }

        public IEnumerable<Transaction> GetTransactions(int userId)
        {
            var cmd = NextPage.DatabaseUtil.PetaPoco.Sql.Builder.Select("u.*").From("Transactions As u");
            if (userId > 0)
            {
                cmd.Where("UserId=@0", userId);

            }
            Trace.TraceInformation(cmd.SQL);
            using (var db = Common.Database)
            {
                var result = db.Fetch<Transaction>(cmd);
                Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }
    }



}
