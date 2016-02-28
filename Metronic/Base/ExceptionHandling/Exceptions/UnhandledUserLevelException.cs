using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class UnhandledUserLevelException : UserLevelException
    {
        protected UnhandledUserLevelException()
        {
        }

        protected UnhandledUserLevelException(string message) : base(message)
        {
        }

        protected UnhandledUserLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected UnhandledUserLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
