using PWTransfer.Core.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;
using System.Diagnostics;
using PWTransfer.Core.Helpers;
using PWTransfer.Core.Models.Rest;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Exceptions;

namespace PWTransfer.Core.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public Task<User> GetInfo(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetSelfInfo()
        {
            try
            {
                return await GetAsync<User>(UrlConstants.UserInfoURL());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> Login(string pEmail, string pPassword)
        {
            try
            {
                var token = await PostAsync<Token>(UrlConstants.LoginURL(), new LoginUser { email = pEmail, password = pPassword });
                HttpClientFactory.AccessToken = token.ToString();
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
                HttpClientFactory.AccessToken = token.ToString();
                return token.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<IEnumerable<RemoteUser>> SearchUsers(string pFilter)
        {
            try
            {
                var users = await PostAsync<List<RemoteUser>>(UrlConstants.UsersURL(), new UserFilter { filter = pFilter });
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
