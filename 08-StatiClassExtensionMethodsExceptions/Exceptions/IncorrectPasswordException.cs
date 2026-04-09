using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; set; }

        public IncorrectPasswordException(int attemptsLeft)
            : base($"Incorrect password! Attempts left: {attemptsLeft}")
        {
            AttemptsLeft = attemptsLeft;
        }
    }
}
