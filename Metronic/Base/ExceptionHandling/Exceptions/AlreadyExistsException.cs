using System;
using System.Runtime.Serialization;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class AlreadyExistsException : UserLevelException
    {
        public AlreadyExistsException()
        {
        }

        public AlreadyExistsException(string message) : base(message)
        {
        }

        public AlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
