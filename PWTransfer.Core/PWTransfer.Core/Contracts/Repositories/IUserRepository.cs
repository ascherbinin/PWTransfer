using PWTransfer.Core.Models;
using PWTransfer.Core.Models.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Contracts.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<RemoteUser>> SearchUsers(string filter);

		Task<string> Login(string email, string password);

		Task<string> Register(string pUserame, string pPassword, string pEmail);

		Task<User> GetInfo(string userName, string password);

		Task<User> GetSelfInfo();
	}
}
