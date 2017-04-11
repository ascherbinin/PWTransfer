using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using PWTransfer.Core.Utility;

namespace PWTransfer.Core.Services
{
    public class UserRestService : BaseRestService, IUserRestService
    {
        private readonly IUserRestService _userRestService;

        public UserRestService(IUserRestService userRestService)
        {
            _userRestService = userRestService;
        }

        public User GetActiveUser()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> Register(string userName, string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchUser(string userName)
        {
            throw new NotImplementedException();
        }

 
        private async Task<string> RegisterRequest(string pUserName, string pPassword, string pEmail)
        {

            string data = JsonConvert.SerializeObject(new { username = pUserName, password = pPassword, email = pEmail});
            var response = await PostAsync(UrlConstants.RegisterUserURL(), data);
            return JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
