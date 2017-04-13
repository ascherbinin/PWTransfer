using PWTransfer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> Login(string userName, string password);
        void ShowMsg(string msg);
    }
}
