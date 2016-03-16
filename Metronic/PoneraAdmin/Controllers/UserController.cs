using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class UserController : SecureBaseController
    {
        public UserController()
        {
                
        }
        // GET: User
        public ActionResult Index()
        {
            //IList<UserModel> _users = _securityBusiness.Get();

            return View();
        }
    }
}