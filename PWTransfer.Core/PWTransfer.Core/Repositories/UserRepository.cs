using PWTransfer.Core.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;

namespace PWTransfer.Core.Repositories
{
    public class UserRepository : BaseRepository//, IUserRepositories
    {
        //private static readonly List<User> AllKnownUsers = new List<User>
        //{
        //    new User { UserName = "gillcleeren", Password="123456", UserId = 1}, //extremely secure, don't try this at home
        //    new User { UserName = "johnsmith", Password="789456", UserId = 2},
        //    new User { UserName = "annawhite", Password="100000", UserId = 3}
        //};

        //public async Task<User> Login(string userName, string password)
        //{
        //    return await Task.FromResult(AllKnownUsers.FirstOrDefault(u => u.UserName == userName && u.Password == password));
        //}
    }
}
