using System;
using Ponera.Base.BusinessLayer.Module;
using Ponera.Base.DataAccess.Module;
using Ponera.Base.DependencyInjection.Bootstrapper;
using Ponera.Base.ExceptionHandling;

namespace PoneraAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper
                .Create()
                    .RegisterModule<DataAccessModule>()
                    .RegisterModule<BusinessLayerModule>()
                    .RegisterModule<PoneraAdminModule>()
                .Load();
        }

        void Application_Error(Object sender, EventArgs e)
        {
            Exception lastError = Server.GetLastError();

            bool handleException = ExceptionHandler.HandleException("PoneraAdmin", lastError);

            // TODO : @deniz 500 sayfasına yönlendir.
        }
    }
}
