using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ponera.Base.ExceptionHandling;

namespace PoneraAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ExceptionHandlingConfiguration.Configure();
        }

        void Application_Error(Object sender, EventArgs e)
        {
            Exception lastError = Server.GetLastError();

            bool handleException = ExceptionHandler.HandleException("PoneraAdmin", lastError);

            // TODO : @deniz 500 sayfasına yönlendir.
        }
    }
}
