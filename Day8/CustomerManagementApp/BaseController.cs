using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementApp
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {
                filterContext.Result = new RedirectResult("~/Error/HandleError");
                filterContext.ExceptionHandled = true;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}