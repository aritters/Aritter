﻿using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Users.Validators;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.SecurityModule
{
    public class AuthenticationAppService : AppService, IAuthenticationAppService
    {
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IUserRoleRepository userRoleRepository;

        public AuthenticationAppService(IUserAccountRepository userAccountRepository,
                                        IUserRoleRepository userRoleRepository)
        {
            Check.IsNotNull(userAccountRepository, nameof(userAccountRepository));
            Check.IsNotNull(userRoleRepository, nameof(userRoleRepository));

            this.userAccountRepository = userAccountRepository;
            this.userRoleRepository = userRoleRepository;
        }

        public AuthenticationDto AuthenticateUser(AuthenticationUserDto userDto)
        {
            AuthenticationDto authentication = new AuthenticationDto();

            if (userDto == null || string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Password))
            {
                authentication.IsAuthenticated = false;
                authentication.Errors.Add("Invalid username or password");
            }

            var user = userAccountRepository.Get(userDto.Username);

            if (user == null)
            {
                authentication.IsAuthenticated = false;
                authentication.Errors.Add("Invalid username or password");
            }

            var validator = new UserAccountValidator();
            var validation = validator.ValidateCredentials(user, userDto.Password);

            if (!validation.IsValid)
            {
                user.HasInvalidAttemptsCount();
                userAccountRepository.UnitOfWork.Commit();

                authentication.IsAuthenticated = false;
                authentication.Errors = validation.Errors.Select(p => p.Message).ToList();
            }

            user.HasValidAttemptsCount();
            userAccountRepository.UnitOfWork.Commit();

            authentication.IsAuthenticated = true;
            authentication.User = user.ProjectedAs<UserAccountDto>();
            authentication.Errors.Clear();

            return authentication;
        }

        public AuthorizationDto GetUserAuthorization(UserAccountDto userAccountDto)
        {
            if (userAccountDto == null || string.IsNullOrEmpty(userAccountDto.Username))
            {
                ThrowHelper.ThrowApplicationException("The user is invalid");
            }

            var user = userAccountRepository.FindUserAuthorizations(UserAccountSpecs.HasUsername(userAccountDto.Username) & UserAccountSpecs.HasAllowedPermissions());

            return user.ProjectedAs<AuthorizationDto>();
        }
    }
}