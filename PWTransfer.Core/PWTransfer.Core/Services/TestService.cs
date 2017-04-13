using PWTransfer.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Services
{
    public class TestService : ITestService
    {
        public void ShowInfo(string msg)
        {
            Debug.WriteLine(msg);
        }

    }
}
