using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.ExceptionHandling.Exceptions.Business
{
    public class BusinessLayerException : BaseException
    {
        protected BusinessLayerException()
        {
        }

        protected BusinessLayerException(string message) : base(message)
        {
        }

        protected BusinessLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected BusinessLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
