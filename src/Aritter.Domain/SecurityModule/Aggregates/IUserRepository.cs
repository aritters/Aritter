﻿using Aritter.Domain.Contracts;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsernameAndPassword(string userName, string password);
    }
}