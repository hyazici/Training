using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Ponera.Base.ExceptionHandling
{
    public static class ExceptionHandler
    {
        public static bool HandleException(string policyName, Exception exception)
        {
            return ExceptionPolicy.HandleException(exception, policyName);
        }

        public static bool HandleException(Exception exceptionToHandle, string policyName, out Exception exceptionToThrow)
        {
            return ExceptionPolicy.HandleException(exceptionToHandle, policyName, out exceptionToThrow);
        }
    }
}
