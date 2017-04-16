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

namespace PWTransfer.Core.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        //public async Task<User> Login(string userName, string email)
        //{
        //    return await Task.FromResult(AllKnownUsers.FirstOrDefault(u => u.UserName == userName && u.Email == email));
        //}


        //public async Task<User> SearchUser(string userName)
        //{
        //    return await Task.FromResult(AllKnownUsers.FirstOrDefault(u => u.UserName == userName));
        //}

        public Task<User> GetInfo(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string Register(string pUserame, string pPassword, string pEmail)
        {
            //await Task.Run(() => PrintMessage());
            string token = Task.Run(async () => await PostAsync<Token>(UrlConstants.RegisterUserURL(), new RegUser { username = pUserame, password = pPassword, email = pEmail })).Result.ToString();
            return token;
            //return Task.Run(async () => await PostAsync<Token>(UrlConstants.RegisterUserURL(), new RegUser { username = pUserame, password = pPassword, email = pEmail }));
        }

        public Task<User> SearchUsers(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
