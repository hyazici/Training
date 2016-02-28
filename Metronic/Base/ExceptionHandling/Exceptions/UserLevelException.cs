using System;
using System.Runtime.Serialization;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class UserLevelException : BaseUserLevelException
    {
        protected UserLevelException()
        {
        }

        protected UserLevelException(string message) : base(message)
        {
        }

        protected UserLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}