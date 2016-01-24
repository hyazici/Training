using System.Web.Mvc;
using System.Web.Routing;
using Ponera.Base.Security;

namespace Ponera.PoneraAdmin.Core
{
    public class SecureBaseController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.User == null)
            {
                RouteValueDictionary routeValueDictionary = new RouteValueDictionary
                {
                    {"returnUrl", filterContext.HttpContext.Request.Url}
                };


                filterContext.Result = RedirectToAction("Login", "Account", routeValueDictionary);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}