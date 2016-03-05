using System;
using System.Runtime.Serialization;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class UserLevelException : BaseUserLevelException
    {
        public UserLevelException()
        {
        }

        public UserLevelException(string message) : base(message)
        {
        }

        public UserLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}