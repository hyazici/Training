using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;
using Ponera.Base.BusinessLayer.Attributes;

namespace Ponera.Base.BusinessLayer.Interceptors
{
    public class UnitOfWorkInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            UnitOfWorkAttribute unitOfWorkAttribute = invocation.MethodInvocationTarget.GetCustomAttributes<UnitOfWorkAttribute>(false).FirstOrDefault();

            if (unitOfWorkAttribute == null)
            {
                invocation.Proceed();
                return;
            }

            var transactionScopeOptions = new TransactionOptions
            {
                IsolationLevel = unitOfWorkAttribute.IsolationLevel,
                Timeout = TimeSpan.MaxValue
            };

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionScopeOptions))
            {
                invocation.Proceed();
                transactionScope.Complete();
            }
        }
    }
}
