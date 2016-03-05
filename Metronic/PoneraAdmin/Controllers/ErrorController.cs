using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.Base.ViewModel;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult UnauthorizedAccess()
        {
            ErrorViewModel errorViewModel = new ErrorViewModel()
            {
                ErrorMessage = "Bu işlemi yapmaya yetkiniz yok"
            };

            return View(errorViewModel);
        }

        public ActionResult OnError(string message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                // TODO : @deniz default mesajı set etmek gerekiyor
            }

            ErrorViewModel errorViewModel = new ErrorViewModel()
            {
                ErrorMessage = message
            };

            return View(errorViewModel);
        }
    }
}