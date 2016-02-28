using System;
using Castle.DynamicProxy;
using Ponera.Base.ExceptionHandling;

namespace Ponera.Base.BusinessLayer.Interceptors
{
    public class BusinessLayerExceptionHandlingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                bool notifiyRethrow = ExceptionHandler.HandleException("Business", ex);

                if (notifiyRethrow)
                {
                    throw;
                }
            }
        }
    }
}
