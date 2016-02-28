using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ponera.Base.BusinessLayer;
using Ponera.Base.Models;
using Ponera.Base.Security;
using Ponera.Base.ViewModel;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController()
        {
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool login = AuthenticationManager.Login(model);

            if (!login)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            //TODO:@deniz merkezi bir yere taşınacak
            SessionManager.MenuModels = MenuManager.GetUserMenuModels();

            return RedirectToLocal(returnUrl);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            // TODO: @deniz base controller'a taşınacak
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AuthenticationManager.RegisterUser(model);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}