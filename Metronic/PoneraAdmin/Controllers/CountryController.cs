using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.Base.BusinessLayer;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    [AuthorizeAction()]
    public class CountryController : SecureBaseController
    {
        private readonly SecurityBusiness _securityBusiness;
        private readonly CountryBusiness _countryBusiness;

        public CountryController()
        {
            _securityBusiness = new SecurityBusiness();
            _countryBusiness=new CountryBusiness();
        }
        // GET: Country
        public ActionResult Index()
        {
            IList<CountryModel> _country = _countryBusiness.GetCountrys();
            return View(_country);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
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

        // POST: Role/Create
        [HttpPost]
        public ActionResult Save(CountryModel countryModel)
        {
            try
            {
                if (countryModel.Id == 0)
                {
                    _countryBusiness.AddCountry(countryModel);
                }
                else
                {
                    _countryBusiness.UpdateCountry(countryModel);
                }

                return Json(countryModel);

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Country/Edit/5
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

        public ActionResult Delete(int id)
        {
            try
            {
                _countryBusiness.DeleteCountry(id);

                return new EmptyResult();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetById(int id)
        {
            CountryModel countryById = _countryBusiness.GetCountryById(id);

            if (countryById == null)
            {
                // TODO :asdasd
            }

            return Json(countryById, JsonRequestBehavior.AllowGet);
        }
    }
}
