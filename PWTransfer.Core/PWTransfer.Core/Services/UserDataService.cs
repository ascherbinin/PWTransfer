using PWTransfer.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;
using PWTransfer.Core.Models.Rest;
using PWTransfer.Core.Contracts.Repositories;
using PWTransfer.Core.Helpers;
using PWTransfer.Core.Exceptions;

namespace PWTransfer.Core.Services
{
	public class UserDataService : BaseDataService, IUserDataService
	{
		public Task<List<User>> GetAllUsers()
		{
			throw new NotImplementedException();
		}

		public async Task<string> Login(string pEmail, string pPassword)
		{
			try
			{
				var token = await PostAsync<Token>(UrlConstants.LoginURL(), new LoginUser { email = pEmail, password = pPassword });
				return token.ToString();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		public async Task<string> Register(string pUserame, string pPassword, string pEmail)
		{
			try
			{
				var token = await PostAsync<Token>(UrlConstants.RegisterUserURL(), new RegUser { username = pUserame, password = pPassword, email = pEmail });
				return token.ToString();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		public Task<User> SearchUser(string userName)
		{
			throw new NotImplementedException();
		}
	}
}
