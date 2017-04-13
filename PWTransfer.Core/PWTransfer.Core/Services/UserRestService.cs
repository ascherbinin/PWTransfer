using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.Repositories;
using PWTransfer.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using PWTransfer.Core.Helpers;
using ModernHttpClient;
using MvvmCross.Platform.Platform;
using PWTransfer.Core.Models.Rest;
using PWTransfer.Core.Utility;

namespace PWTransfer.Core.Services
{
    public class UserRestService : IUserRestService
    {
        private readonly IUserRepository _userRepository;

        public UserRestService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetActiveUser()
        {
            return new User();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchUser(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> Register(string userName, string email, string password)
        {
            string data = JsonConvert.SerializeObject(new { username = userName, password = password, email = email });
            //var response = await PostAsync(UrlConstants.RegisterUserURL(), data);

            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(UrlConstants.RegisterUserURL(), content);
                if (response.IsSuccessStatusCode)
                {
                    var responseText = response.Content.ReadAsStringAsync().Result;
                    var token = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result);
                    Settings.AccessToken = token.id_token;
                    return token;
                }
                else
                {
                    var responseText = response.Content.ReadAsStringAsync().Result;
                    MvxTrace.Trace(MvxTraceLevel.Diagnostic, "Error code: {0}-{1}", response.StatusCode, responseText);
                    return new Token();
                }
                
            }
        }
    }
}
