using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.DependencyInjection.Bootstrapper;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core.Permission;
using AuthenticationManager = Ponera.Base.Security.AuthenticationManager;

namespace Ponera.PoneraAdmin.Core
{
    public class SecureBaseController : BaseController
    {
        private readonly ISecurityBusiness _securityBusiness;

        public SecureBaseController()
        {
            _securityBusiness = Bootstrapper.Container.Resolve<ISecurityBusiness>();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserModel userModel = SessionManager.User;
            

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

            IList<RoleModel> roleModels = userModel.Roles;

            if (roleModels.Any(model => model.RoleName == "Admin"))
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            var customAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof (ActionPermissionAttribute), false);

            if (!customAttributes.Any())
            {
                ActionResult unauthorizedActionResult = GetUnauthorizedActionResult(filterContext);
                filterContext.Result = unauthorizedActionResult;

                base.OnActionExecuting(filterContext);
                return;
            }

            ActionPermissionAttribute actionPermissionAttribute = (ActionPermissionAttribute)customAttributes[0];
            string actionPermissions = actionPermissionAttribute.Permission;
            string url = $"/{filterContext.RouteData.Values["controller"]}/{filterContext.RouteData.Values["action"]}";

            IList<PageAuthorizationModel> authorizationModels = _securityBusiness.GetMenuAuthorizationModelsByUrl(url);

            List<PageAuthorizationModel> userMenuAuth = authorizationModels.Where(
                model => (model.UserId == userModel.Id || roleModels.Any(roleModel => roleModel.Id == model.RoleId)))
                .ToList();

            if (userMenuAuth.All(model => model.Permission != actionPermissions))
            {
                ActionResult unauthorizedActionResult = GetUnauthorizedActionResult(filterContext);
                filterContext.Result = unauthorizedActionResult;
            }

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

        private string GetAuthUrl(string url)
        {
            string[] urlParts = url.Split('/');

            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append("/");
            for (int i = 0; i < urlParts.Length - 1; i++)
            {
                urlBuilder.Append(urlParts[i]);
                urlBuilder.Append("/");
            }

            return urlBuilder.ToString(0, urlBuilder.Length - 1);
        }
    }
}