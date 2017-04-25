using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Models.Rest
{
     public class TransToken
    {
        public int id { get; set; }
        public string date { get; set; }
        public string username { get; set; }
        public int amount { get; set; }
        public int balance { get; set; }
    }

    public class TransactionsList
    {
        public List<TransToken> trans_token { get; set; }
    }
}
