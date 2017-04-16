﻿using PWTransfer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> SearchUsers(string searchString);

        Task<string> Login(string userName, string password);

        Task<string> Register(string userName, string password, string email);

        Task<User> GetInfo(string userName, string password);
    }
}
