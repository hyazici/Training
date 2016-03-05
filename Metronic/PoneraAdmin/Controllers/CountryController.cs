using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models;
using Ponera.PoneraAdmin.Core;
using Ponera.PoneraAdmin.Core.Permission;

namespace PoneraAdmin.Controllers
{
    public class CountryController : SecureBaseController
    {
        private readonly ICountryBusiness _countryBusiness;
         
        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;

            // Elle register ettiğimiz nesneleri container'dan almak için
            // ICountryBusiness business = Bootstrapper.Container.Resolve<ICountryBusiness>();
        }

        [ActionPermission(ActionPermissions.Read)]
        public ActionResult Index()
        {
            IList<CountryModel> _country = _countryBusiness.GetCountrys();
            return View(_country);
        }

        [HttpPost]
        [ActionPermission(ActionPermissions.Save)]
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

        [ActionPermission(ActionPermissions.Delete)]
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

        [ActionPermission(ActionPermissions.Read)]
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
