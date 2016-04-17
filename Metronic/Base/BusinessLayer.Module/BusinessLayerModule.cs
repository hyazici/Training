using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using FluentValidation;
using Ponera.Base.BusinessLayer.Interceptors;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.DependencyInjection.Bootstrapper;
using Ponera.Base.DependencyInjection.Bootstrapper.Base;
using Ponera.Base.Models.Validators;
using Ponera.Base.Models.Validators.Factories;
using Ponera.Base.Models.Validators.Interceptors;
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
            builder.RegisterType<ValidateModelInterceptor>();

            builder.RegisterType<ModelValidatorFactory>().SingleInstance();

            AssemblyScanner.FindValidatorsInAssemblyContaining<UserModelValidator>()
                .ForEach(result =>
                {
                    builder.RegisterType(result.ValidatorType).As(result.InterfaceType).SingleInstance();
                });

            builder.RegisterType<CountryBusiness>()
                .As<ICountryBusiness>()
                .InstancePerDependency() // Life cycle
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof (UnitOfWorkInterceptor))
                .InterceptedBy(typeof (ValidateModelInterceptor));

            builder.RegisterType<DepartmentBusiness>()
                .As<IDepartmentBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof(UnitOfWorkInterceptor))
                .InterceptedBy(typeof(ValidateModelInterceptor));

            builder.RegisterType<MenuBusiness>()
                .As<IMenuBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof(UnitOfWorkInterceptor))
                .InterceptedBy(typeof(ValidateModelInterceptor));

            builder.RegisterType<SecurityBusiness>()
                .As<ISecurityBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof(UnitOfWorkInterceptor))
                .InterceptedBy(typeof(ValidateModelInterceptor));

            builder.RegisterType<AnketBilgisiBusiness>()
                .As<IAnketBilgisiBusiness>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (BusinessLayerExceptionHandlingInterceptor))
                .InterceptedBy(typeof (UnitOfWorkInterceptor))
                .InterceptedBy(typeof (ValidateModelInterceptor));

            // Notification Dependencies

            builder.RegisterType<MailService>()
                .As<IMailService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (BusinessLayerExceptionHandlingInterceptor));

            builder.Register<Func<Type, IValidator>>(context => type => Bootstrapper.Container.ResolveOptional(type) as IValidator);
        }

        // TODO : @deniz application başlamadan önce
        public override void OnPreLoad()
        {
        }
    }
}
