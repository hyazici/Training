using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core;
using Ponera.PoneraAdmin.Core.Permission;

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

        [HttpPost]
        [ActionPermission(ActionPermissions.Save)]
        public ActionResult Save(UserModel userModel)
        {
            try
            {
                if (userModel.Id == 0)
                {
                    _securityBusiness.AddUser(userModel);
                }
                else
                {
                    _securityBusiness.UpdateUser(userModel);
                }

                return Json(userModel);

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult GetById(int id)
        {
            UserModel userById = _securityBusiness.GetUserById(id);

            if (userById == null)
            {
                // TODO :asdasd
            }

            return Json(userById, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _securityBusiness.DeleteUserById(id);

                return new EmptyResult();
            }
            catch
            {
                return View();
            }
        }
    }
}