using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Ponera.Base.Contracts;
using Ponera.Base.DependencyInjection.Bootstrapper;
using Ponera.Base.ExceptionHandling;
using Ponera.Base.ExceptionHandling.Exceptions;
using Ponera.PoneraAdmin.Core.ActionResults;

namespace Ponera.PoneraAdmin.Core
{
    public class BaseController : Controller
    {
        protected readonly ISessionManager SessionManager;

        public BaseController()
        {
            SessionManager = Bootstrapper.Container.Resolve<ISessionManager>();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            bool notifiyRethrow = ExceptionHandler.HandleException("PoneraAdmin", exception);

            var responseCode = HttpStatusCode.InternalServerError;
            string message = "İşleminiz yapılırken bir hata oluştu.";

            if (exception is BaseUserLevelException && !(exception is UnhandledUserLevelException))
            {
                responseCode = HttpStatusCode.BadRequest;
                message = exception.Message;
            }

            filterContext.Result = GetUnauthorizedActionResult(filterContext, message, responseCode);

            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData["UserMenus"] = SessionManager.UserMenus;
            ViewData["CurrentUser"] = SessionManager.User;

            base.OnActionExecuting(filterContext);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new JsonNetResult() {ContentEncoding = contentEncoding, Data = data, ContentType = contentType};
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult() { ContentEncoding = contentEncoding, Data = data, ContentType = contentType, JsonRequestBehavior = behavior};
        }

        private ActionResult GetUnauthorizedActionResult(ExceptionContext filterContext, string message, HttpStatusCode httpStatusCode)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                Response.StatusCode = (int) httpStatusCode;
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
            }

            return
                new RedirectToRouteResult(new RouteValueDictionary()
                {
                    {"controller", "Error"},
                    {"action", "OnError"},
                    {"message", message}
                });
        }
    }
}
