using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class UserController : SecureBaseController
    {
        private readonly ISecurityBusiness _securityBusiness;

        public UserController(ISecurityBusiness securityBusiness)
        {
            _securityBusiness = securityBusiness;
        }
        // GET: User
        public ActionResult Index()
        {
            IList<UserModel> _users = _securityBusiness.GetAllUsers();

            return View(_users);
        }
    }
}