using System.Collections.Generic;
using System.Threading.Tasks;
using PWTransfer.Core.Models;
using PWTransfer.Core.Models.Rest;

namespace PWTransfer.Core.Services
{
    public interface IUserRestService
    {
        Task<User> SearchUser(string userName);

        Task<List<User>> GetAllUsers();

        Task<User> Login(string userName, string password);

        Task<Token> Register(string userName, string email, string password);

        User GetActiveUser();
    }
}