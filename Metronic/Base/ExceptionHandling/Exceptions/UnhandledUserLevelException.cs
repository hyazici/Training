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
        public UnhandledUserLevelException()
        {
        }

        public UnhandledUserLevelException(string message) : base(message)
        {
        }

        public UnhandledUserLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
