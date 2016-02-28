using System;
using Castle.DynamicProxy;
using Ponera.Base.BusinessLayer.Interceptors;
using Ponera.Base.DataAccess.Interceptors;


namespace Ponera.Base.BusinessLayer.Proxy
{
    public static class PoneraProxyGenerator
    {
        public static TInterface GenerateRepositoryProxy<TInterface, TClass>() 
            where TClass : class, TInterface where TInterface : class
        {
            ProxyGenerator generator = new ProxyGenerator();

            TClass instance = Activator.CreateInstance<TClass>();

            TInterface @interface = generator.CreateInterfaceProxyWithTargetInterface<TInterface>(instance, new DataAccessExceptionHandlingInterceptor());

            return @interface;
        }

        public static TInterface GenerateBusinessProxy<TInterface, TClass>()
            where TClass : class, TInterface where TInterface : class
        {
            ProxyGenerator generator = new ProxyGenerator();

            TClass instance = Activator.CreateInstance<TClass>();

            TInterface @interface = generator.CreateInterfaceProxyWithTargetInterface<TInterface>(instance, new BusinessLayerExceptionHandlingInterceptor());

            return @interface;
        }
    }
}
