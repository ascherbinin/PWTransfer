﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Exceptions
{
    class ApiCallFailedException : Exception
    {
        public ApiCallFailedException()
        {
        }

        public ApiCallFailedException(string message)
        : base(message)
        {

        }

        public ApiCallFailedException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
