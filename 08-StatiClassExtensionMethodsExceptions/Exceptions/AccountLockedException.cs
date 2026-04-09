using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class AccountLockedException : Exception
    {
        public AccountLockedException()
            : base("Account is locked!") { }
    }
}
