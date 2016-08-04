﻿using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.Common.Specs;
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
        private readonly IUserAccountRepository userRepository;
        private readonly IUserRoleRepository roleRepository;

        public AuthenticationAppService(IUserAccountRepository userRepository,
                                        IUserRoleRepository roleRepository)
        {
            Guard.IsNotNull(userRepository, nameof(userRepository));
            Guard.IsNotNull(roleRepository, nameof(roleRepository));

            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public AuthenticationDto Authenticate(string userName, string password)
        {
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), "Username or password are invalid.");
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(password), "Username or password are invalid.");

            var findByUsernameSpec = new IsEnabledSpec<UserAccount>() &
                                     new UsernameEqualsSpec(userName);

            var user = userRepository.Get(findByUsernameSpec);

            UserAccountValidator validator = new UserAccountValidator();

            var userValidation = validator.ValidateUserCredentials(user, password);

            if (!userValidation.IsValid)
            {
                user.HasInvalidAttemptsCount();
                userRepository.UnitOfWork.CommitChanges();
                throw new ApplicationErrorException(userValidation.Errors.Select(p => p.Message).ToArray());
            }

            user.HasValidAttemptsCount();
            userRepository.UnitOfWork.CommitChanges();

            var findUserAuthorizationsSpec = new IsEnabledSpec<UserAccount>() &
                                             new IdIsEqualsSpec<UserAccount>(user.Id) &
                                             new AllowedUserPermissionsSpec();

            user = userRepository.FindAuthorizations(findUserAuthorizationsSpec);

            return user.ProjectedAs<AuthenticationDto>();
        }

        public AuthenticationDto GetAuthorization(string userName)
        {
            Guard.Against<ApplicationErrorException>(string.IsNullOrEmpty(userName), "Username or password are invalid.");

            var findByUsernameSpec = new IsEnabledSpec<UserAccount>() &
                                     new UsernameEqualsSpec(userName);

            var user = userRepository.Find(findByUsernameSpec)
                                     .FirstOrDefault();

            UserAccountValidator validator = new UserAccountValidator();

            var userValidation = validator.ValidateUserAccount(user);

            if (!userValidation.IsValid)
            {
                throw new ApplicationErrorException(userValidation.Errors.Select(p => p.Message).ToArray());
            }

            var findUserAuthorizationsSpec = new IsEnabledSpec<UserAccount>() &
                                             new IdIsEqualsSpec<UserAccount>(user.Id) &
                                             new AllowedUserPermissionsSpec();

            user = userRepository.FindAuthorizations(findUserAuthorizationsSpec);

            return user.ProjectedAs<AuthenticationDto>();
        }
    }
}