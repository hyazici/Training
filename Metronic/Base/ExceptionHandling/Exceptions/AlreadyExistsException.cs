using System;
using System.Runtime.Serialization;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class AlreadyExistsException : UserLevelException
    {
        protected AlreadyExistsException()
        {
        }

        protected AlreadyExistsException(string message) : base(message)
        {
        }

        protected AlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected AlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
