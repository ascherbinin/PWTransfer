using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Models.Rest
{
    public class TransactionsList
    {
        public Trans_Token[] trans_token { get; set; }
    }

    public class Trans_Token
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string username { get; set; }
        public int amount { get; set; }
        public int balance { get; set; }
    }

}
