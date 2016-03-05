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
        public BusinessLayerException()
        {
        }

        public BusinessLayerException(string message) : base(message)
        {
        }

        public BusinessLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
