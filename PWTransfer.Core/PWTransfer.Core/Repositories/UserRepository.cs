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
    public class UserRepository : IUserRepository
    {
        private readonly IUserDataService _userDataService;

        public UserRepository(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public Task<User> GetInfo(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string email, string password)
        {
            return await _userDataService.Login(email, password);
        }

        public string Register(string pUserame, string pPassword, string pEmail)
        {
            //await Task.Run(() => PrintMessage());
            return _userDataService.Register(pUserame, pPassword, pEmail);

            //return Task.Run(async () => await PostAsync<Token>(UrlConstants.RegisterUserURL(), new RegUser { username = pUserame, password = pPassword, email = pEmail }));
        }

        public Task<User> SearchUsers(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
