using PWTransfer.Core.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;
using System.Diagnostics;
using PWTransfer.Core.Helpers;

namespace PWTransfer.Core.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private static readonly List<User> AllKnownUsers = new List<User>
        {
            new User { UserName = "gillcleeren", Email="123456", UserId = 1}, //extremely secure, don't try this at home
            new User { UserName = "johnsmith", Email="789456", UserId = 2},
            new User { UserName = "annawhite", Email="100000", UserId = 3}
        };

        public async Task<User> Login(string userName, string email)
        {
            return await Task.FromResult(AllKnownUsers.FirstOrDefault(u => u.UserName == userName && u.Email == email));
        }


        public async Task<User> SearchUser(string userName)
        {
            return await Task.FromResult(AllKnownUsers.FirstOrDefault(u => u.UserName == userName));
        }
    }
}
