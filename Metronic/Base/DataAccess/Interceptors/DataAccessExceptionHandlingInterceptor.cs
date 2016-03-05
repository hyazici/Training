using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Ponera.Base.Entities;
using Ponera.Base.ExceptionHandling;

namespace Ponera.Base.DataAccess.Interceptors
{
    public class DataAccessExceptionHandlingInterceptor : IInterceptor
    {
        // TODO : depedency verilebilir.
        public DataAccessExceptionHandlingInterceptor()
        {
            
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                bool notifiyRethrow = ExceptionHandler.HandleException("DataAccess", ex);

                if (notifiyRethrow)
                {
                    throw;
                }
            }
        }
    }
}
