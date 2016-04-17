using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.ExceptionHandling.Exceptions
{
    public class ValidationException : UserLevelException
    {
        public ValidationException(string message, IList<KeyValuePair<string, string>> errorDetail)
            : base(message)
        {
            ErrorDetail = errorDetail;
        }

        public IList<KeyValuePair<string, string>> ErrorDetail { get; }
    }
}
