using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.PoneraAdmin.Core;
using Ponera.PoneraAdmin.Core.ActionResults;

namespace PoneraAdmin.Controllers
{
    public class ValidationController : SecureBaseController
    {
        private readonly ISecurityBusiness _securityBusiness;

        public ValidationController(ISecurityBusiness securityBusiness)
        {
            _securityBusiness = securityBusiness;
        }

        [HttpGet]
        public JsonResult UniqueEmail(string email)
        {
            bool validationResult = true;

            if (!string.IsNullOrEmpty(email))
            {
                validationResult = !_securityBusiness.IsUserExists(email);
            }

            return Json(validationResult, JsonRequestBehavior.AllowGet);
        }
    }
}