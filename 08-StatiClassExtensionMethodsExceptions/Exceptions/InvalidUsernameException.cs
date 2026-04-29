using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
            : base("Username is invalid!") { }

        public InvalidUsernameException(string message)
            : base(message) { }
    }
}
