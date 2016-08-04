﻿using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.DTO.SecurityModule.Users;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
    public interface IUserAppService : IAppService
    {
        UserAccountDto AddUserAccount(AddUserAccountDto user);
    }
}
