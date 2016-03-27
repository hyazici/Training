using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Ponera.Base.BusinessLayer.Interceptors;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.DependencyInjection.Bootstrapper.Base;
using Ponera.Base.Notification;

namespace Ponera.Base.BusinessLayer.Module
{
    public class BusinessLayerModule : BaseModule
    {
        // Depedencyler yüklendikten sonra
        public override void OnBuildComplete(IContainer container)
        {
        }

        // Application başlarken
        public override void OnLoad(ContainerBuilder builder)
        {
            builder.RegisterType<BusinessLayerExceptionHandlingInterceptor>();
            builder.RegisterType<UnitOfWorkInterceptor>();

            builder.RegisterType<CountryBusiness>()
                .As<ICountryBusiness>()
                .InstancePerDependency() // Life cycle
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof (UnitOfWorkInterceptor));

            builder.RegisterType<DepartmentBusiness>()
                .As<IDepartmentBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof(UnitOfWorkInterceptor));

            builder.RegisterType<MenuBusiness>()
                .As<IMenuBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof(UnitOfWorkInterceptor));

            builder.RegisterType<SecurityBusiness>()
                .As<ISecurityBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof(UnitOfWorkInterceptor));

            builder.RegisterType<AnketBilgisiBusiness>()
                .As<IAnketBilgisiBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof (UnitOfWorkInterceptor));

            // Notification Dependencies

            builder.RegisterType<MailService>()
                .As<IMailService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (BusinessLayerExceptionHandlingInterceptor));
        }

        // TODO : @deniz application başlamadan önce
        public override void OnPreLoad()
        {
        }
    }
}
