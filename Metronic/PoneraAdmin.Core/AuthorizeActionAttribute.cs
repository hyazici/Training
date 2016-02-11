using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Ponera.Base.Security;

namespace Ponera.PoneraAdmin.Core
{
    public class AuthorizeActionAttribute : ActionFilterAttribute
    {
        private readonly IList<string> _roles;

        public AuthorizeActionAttribute(params string[] roles)
        {
            _roles = roles.ToList();
            _roles.Add("Admin");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isUserAuthorized = AuthorizationManager.IsUserAuthorized(_roles.ToArray());

            if (!isUserAuthorized)
            {
                filterContext.Result =
                    new RedirectToRouteResult(new RouteValueDictionary()
                    {
                        {"controller", "Error"},
                        {"action", "UnauthorizedAccess"}
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
