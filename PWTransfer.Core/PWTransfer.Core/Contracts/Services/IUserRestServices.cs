using System.Collections.Generic;
using System.Threading.Tasks;
using PWTransfer.Core.Models;

namespace PWTransfer.Core.Contracts.Services
{
	public interface IUserRestServices
	{
		Task<User> SearchUser(string userName);

		Task<List<User>> GetAllUsers();

		Task<User> Login(string userName, string password);

		User GetActiveUser();
	}
}
