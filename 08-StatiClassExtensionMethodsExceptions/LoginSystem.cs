using _08_StatiClassExtensionMethodsExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions
{
    public class LoginSystem
    {
        private User[] users;
        private const int MaxAttempts = 3;

        public LoginSystem()
        {
            users = new User[]
            {
            new User("admin", "admin123"),
            new User("student", "student123"),
            new User("teacher", "teacher123")
            };
        }

        public void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new InvalidUsernameException("Username cannot be empty!");

            if (username.Length < 3)
                throw new InvalidUsernameException("Username must be at least 3 characters!");
        }

        public void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidPasswordException("Password cannot be empty!");

            if (password.Length < 6)
                throw new InvalidPasswordException("Password must be at least 6 characters!");
        }

        private User FindUser(string username)
        {
            foreach (var user in users)
            {
                if (user.Username.ToLower() == username.ToLower())
                    return user;
            }
            return null;
        }

        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);

            User user = FindUser(username);

            if (user == null)
                throw new UserNotFoundException(username);

            if (user.IsLocked)
                throw new AccountLockedException();

            if (user.Password == password)
            {
                user.FailedAttempts = 0;
                Console.WriteLine($"Login successful! Welcome, {user.Username}!");
                return true;
            }
            else
            {
                user.FailedAttempts++;

                int attemptsLeft = MaxAttempts - user.FailedAttempts;

                if (attemptsLeft > 0)
                    throw new IncorrectPasswordException(attemptsLeft);
                else
                {
                    user.IsLocked = true;
                    throw new AccountLockedException();
                }
            }
        }

        public void ShowUsers()
        {
            Console.WriteLine("Available users:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}
