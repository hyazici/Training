using Autofac;
using Autofac.Extras.DynamicProxy2;
using Ponera.Base.Contracts.DataAccess;
using Ponera.Base.DataAccess.Interceptors;
using Ponera.Base.DependencyInjection.Bootstrapper.Base;

namespace Ponera.Base.DataAccess.Module
{
    public class DataAccessModule : BaseModule
    {
        public override void OnBuildComplete(IContainer container)
        {
        }

        public override void OnLoad(ContainerBuilder builder)
        {
            builder.RegisterType<DataAccessExceptionHandlingInterceptor>();

            builder.RegisterType<CountryRepository>()
                .As<ICountryRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<DepartmentRepository>()
                .As<IDepartmentRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<EmailLogRepository>()
                .As<IEmailLogRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<ErrorLogRepository>()
                .As<IErrorLogRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<MenuRepository>()
                .As<IMenuRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<PageAuhorizationRepository>()
                .As<IPageAuhorizationRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<RoleRepository>()
                .As<IRoleRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));

            builder.RegisterType<AnketBilgisiRepository>()
                .As<IAnketBilgisiRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (DataAccessExceptionHandlingInterceptor));
        }

        public override void OnPreLoad()
        {
        }
    }
}
