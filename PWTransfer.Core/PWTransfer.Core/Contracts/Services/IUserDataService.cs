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
		Task<IEnumerable<RemoteUser>> GetUsers(string filter);

		Task<User> GetSelfInfo();

        Task<string> Login(string email, string password);

        Task<string> Register(string userName, string password, string email);
    }
}
