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
        private readonly IUserRepository _userRepository;

        public UserDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<RemoteUser>> GetUsers(string filter)
        {
            return await _userRepository.SearchUsers(filter);
        }

        public async Task<User> GetSelfInfo()
        {
            return await _userRepository.GetSelfInfo();
        }

        public async Task<string> Login(string email, string password)
        {
            return await _userRepository.Login(email, password);
        }

        public async Task<string> Register(string pUserame, string pPassword, string pEmail)
        {
            return await _userRepository.Register(pUserame, pPassword, pEmail);
        }

	}
}
