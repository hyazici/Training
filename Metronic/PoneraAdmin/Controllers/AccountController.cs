using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ponera.Base.BusinessLayer;
using Ponera.Base.Contracts;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Contracts.Security;
using Ponera.Base.Models;
using Ponera.Base.Security;
using Ponera.Base.ViewModel;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IMenuManager _menuManager;
        private readonly ISessionManager _sessionManager;

        public AccountController(IAuthenticationManager authenticationManager, IMenuManager menuManager, ISessionManager sessionManager)
        {
            _authenticationManager = authenticationManager;
            _menuManager = menuManager;
            _sessionManager = sessionManager;
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

            bool login = _authenticationManager.Login(model);

            if (!login)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            //TODO:@deniz merkezi bir yere taşınacak
            IList<MenuModel> menuModels = _menuManager.GetMenuModels();
            IList<MenuModel> userMenuModels = _menuManager.GetUserMenuModels(menuModels);

            _sessionManager.Menus = menuModels;
            _sessionManager.UserMenus = userMenuModels;

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

            _authenticationManager.RegisterUser(model);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            _authenticationManager.Logout();

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