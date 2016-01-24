using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult UnauthorizedAccess()
        {
            return View();
        }
    }
}