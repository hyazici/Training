using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using FluentValidation.Mvc;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.Security;
using Ponera.Base.DependencyInjection.Bootstrapper.Base;
using Ponera.Base.ExceptionHandling;
using Ponera.Base.Models.Validators.Factories;
using Ponera.Base.Models.Validators.PropertyValidators;
using Ponera.Base.Security;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin
{
    public class PoneraAdminModule : BaseModule
    {
        public override void OnLoad(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SessionManager>().As<ISessionManager>();
            builder.RegisterType<AuthenticationManager>().As<IAuthenticationManager>();
            builder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>();

            builder.RegisterType<MenuManager>().As<IMenuManager>();
        }

        public override void OnBuildComplete(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ExceptionHandlingConfiguration.Configure();

            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                ModelValidatorFactory modelValidatorFactory = container.Resolve<ModelValidatorFactory>();

                provider.ValidatorFactory = modelValidatorFactory;

                provider.Add(typeof (UniqueEmailValidator), (metadata, context, rule, validator) => new UniqueEmailValidatorRemote(metadata, context, rule, validator));
            });
        }

        public override void OnPreLoad()
        {
        }
    }
}
