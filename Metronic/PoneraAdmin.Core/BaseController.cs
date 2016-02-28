using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Ponera.Base.ExceptionHandling;
using Ponera.Base.ExceptionHandling.Exceptions;

namespace Ponera.PoneraAdmin.Core
{
    public class BaseController : Controller
    {
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

            base.OnException(filterContext);
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
