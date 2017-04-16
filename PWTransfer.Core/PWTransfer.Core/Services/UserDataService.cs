using PWTransfer.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;
using PWTransfer.Core.Models.Rest;
using PWTransfer.Core.Contracts.Repositories;

namespace PWTransfer.Core.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;

        public UserDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string Register(string userName, string password, string email)
        {
            return _userRepository.Register(userName, password, email);
        }

        public Task<User> SearchUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
