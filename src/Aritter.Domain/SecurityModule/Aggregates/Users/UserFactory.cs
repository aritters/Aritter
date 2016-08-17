﻿namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public static class UserFactory
    {
        public static UserAccount CreateAccount(string username, string email, string password)
        {
            var user = new UserAccount(username, email);
            user.ChangePassword(password);
            user.HasValidLoginAttempt();

            return user;
        }

        public static UserAccount CreateAccount(string username, string email, string password, UserProfile userProfile)
        {
            var user = CreateAccount(username, email, password);
            user.SetProfile(userProfile);

            return user;
        }
    }
}
