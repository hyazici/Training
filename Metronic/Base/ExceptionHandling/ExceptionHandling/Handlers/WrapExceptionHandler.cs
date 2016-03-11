using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Ponera.Base.ExceptionHandling.Handlers
{
    //public class WrapExceptionHandler : IExceptionHandler
    //{
    //    private readonly NameValueCollection _attributes;

    //    public WrapExceptionHandler(NameValueCollection attributes)
    //    {
    //        _attributes = attributes;
    //    }

    //    public Exception HandleException(Exception exception, Guid handlingInstanceId)
    //    {
    //        return WrapException(exception,"Test");
    //    }

    //    private Exception WrapException(Exception originalException, string wrapExceptionMessage)
    //    {
    //        object[] extraParameters = new object[2];
    //        extraParameters[0] = wrapExceptionMessage;
    //        extraParameters[1] = originalException;
    //        return (Exception)Activator.CreateInstance(wrapExceptionType, extraParameters);
    //    }
    //}
}
