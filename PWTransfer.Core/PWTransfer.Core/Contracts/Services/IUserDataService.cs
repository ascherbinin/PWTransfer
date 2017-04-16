using PWTransfer.Core.Models;
using PWTransfer.Core.Models.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Contracts.Services
{
    public interface IUserDataService
    {
        Task<User> SearchUser(string userName);

        Task<List<User>> GetAllUsers();

        Task<string> Login(string userName, string password);

        string Register(string userName, string password, string email);
    }
}
