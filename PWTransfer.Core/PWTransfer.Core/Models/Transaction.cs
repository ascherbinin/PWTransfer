﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Models.Rest
{

    public class Transaction
    {
        public Info trans_token { get; set; }
    }

    public class Info
    {
        public int id { get; set; }
        public string date { get; set; }
        public string username { get; set; }
        public int amount { get; set; }
        public int balance { get; set; }
    }

}
