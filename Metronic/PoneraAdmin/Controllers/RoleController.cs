using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class RoleController : SecureBaseController
    {
        private readonly ISecurityBusiness _securityBusiness;

        public RoleController(ISecurityBusiness securityBusiness)
        {
            _securityBusiness = securityBusiness;
        }

        public ActionResult Index()
        {
            IList<RoleModel> _roles = _securityBusiness.GetRoles();

            return View(_roles);
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Save(RoleModel roleModel)
        {
            try
            {
                if (roleModel.Id == 0)
                {
                    _securityBusiness.AddRole(roleModel);
                }
                else
                {
                    _securityBusiness.UpdateRole(roleModel);
                }

                return Json(roleModel);

            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult GetById(int id)
        {
            RoleModel roleById = _securityBusiness.GetRoleById(id);

            if (roleById == null)
            {
                // TODO :asdasd
            }

            return Json(roleById, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _securityBusiness.DeleteRoleById(id);

                return new EmptyResult();
            }
            catch
            {
                return View();
            }
        }
    }
}
