using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.ExceptionHandling.Exceptions.DataAccess
{
    [Serializable]
    public class DataAccessLayerException : BaseException
    {
        protected DataAccessLayerException()
        {
        }

        protected DataAccessLayerException(string message) : base(message)
        {
        }

        protected DataAccessLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataAccessLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
