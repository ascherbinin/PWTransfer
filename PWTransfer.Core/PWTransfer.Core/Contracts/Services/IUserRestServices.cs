using System.Collections.Generic;
using System.Threading.Tasks;
using PWTransfer.Core.Models;

namespace PWTransfer.Core.Contracts.Services
{
	public interface IUserRestService
	{
		Task<User> SearchUser(string userName);

		Task<List<User>> GetAllUsers();

		Task<User> Login(string userName, string password);

        Task<User> Register(string userName, string email, string password);

        User GetActiveUser();
	}
}
