using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core.Permission;
using AuthenticationManager = Ponera.Base.Security.AuthenticationManager;

namespace Ponera.PoneraAdmin.Core
{
    public class SecureBaseController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserModel userModel = AuthenticationManager.User;
            IList<RoleModel> roleModels = userModel.Roles;

            if (userModel == null)
            {
                RouteValueDictionary routeValueDictionary = new RouteValueDictionary
                {
                    {"returnUrl", filterContext.HttpContext.Request.Url}
                };

                filterContext.Result = RedirectToAction("Login", "Account", routeValueDictionary);

                base.OnActionExecuting(filterContext);
                return;
            }

            var customAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof (ActionPermissionAttribute), false);

            if (!customAttributes.Any())
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = Json(new {Message = "Unauthorized"}, JsonRequestBehavior.AllowGet);
                    Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                }
                else
                {
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary()
                        {
                            {"controller", "Error"},
                            {"action", "UnauthorizedAccess"}
                        });
                }

                base.OnActionExecuting(filterContext);
                return;
            }

            ActionPermissionAttribute actionPermissionAttribute = (ActionPermissionAttribute)customAttributes[0];
            var actionPermissions = actionPermissionAttribute.Permission;
            IList<MenuModel> flatMenuModels = MenuManager.GetFlatMenuModels();
            string url = Request.Url.ToString();
            MenuModel menuModel = flatMenuModels.FirstOrDefault(model => model.Url == url);

            if (menuModel == null)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            IList<MenuAuthorizationModel> authorizationModels = menuModel.MenuAuthorizationModels;

            authorizationModels.Where(model => (model.UserId == userModel.Id || roleModels.Any(roleModel => roleModel.Id == model.RoleId)));

            base.OnActionExecuting(filterContext);
        }

        private ActionResult GetUnauthorizedActionResult(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return Json(new { Message = "Unauthorized" }, JsonRequestBehavior.AllowGet);
            }

            return 
                new RedirectToRouteResult(new RouteValueDictionary()
                {
                    {"controller", "Error"},
                    {"action", "UnauthorizedAccess"}
                });
        }
    }
}