using System;
using System.Runtime.Serialization;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class CriticalUserLevelException : BaseUserLevelException
    {
        public CriticalUserLevelException()
        {
        }

        public CriticalUserLevelException(string message) : base(message)
        {
        }

        public CriticalUserLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}