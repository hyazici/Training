using System.Collections.Generic;
using System.Web.Mvc;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core;
using Ponera.PoneraAdmin.Core.Permission;

namespace PoneraAdmin.Controllers
{
    public class DepartmentController : SecureBaseController
    {
        private readonly IDepartmentBusiness _departmentBusiness;

        public DepartmentController(IDepartmentBusiness departmentBusiness)
        {
            _departmentBusiness = departmentBusiness;
        }

        [ActionPermission(ActionPermissions.Read)]
        public ActionResult Index()
        {
           IList<DepartmentModel> departmentModels = _departmentBusiness.GetDepartments(null);

            return View("Index", departmentModels);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
