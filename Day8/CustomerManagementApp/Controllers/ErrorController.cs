using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult HandleError(string message)
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}