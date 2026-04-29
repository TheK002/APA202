using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("User not found!") { }

        public UserNotFoundException(string username)
            : base($"User '{username}' not found!") { }
    }
}
