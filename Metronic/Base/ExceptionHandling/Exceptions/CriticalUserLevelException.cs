using System;
using System.Runtime.Serialization;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class CriticalUserLevelException : BaseUserLevelException
    {
        protected CriticalUserLevelException()
        {
        }

        protected CriticalUserLevelException(string message) : base(message)
        {
        }

        protected CriticalUserLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CriticalUserLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}