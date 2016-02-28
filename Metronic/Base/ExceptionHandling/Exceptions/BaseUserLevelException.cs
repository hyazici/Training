using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public abstract class BaseUserLevelException : BaseException
    {
        protected BaseUserLevelException()
        {
        }

        protected BaseUserLevelException(string message) : base(message)
        {
        }

        protected BaseUserLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected BaseUserLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
