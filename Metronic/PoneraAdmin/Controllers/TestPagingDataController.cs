using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models;
using Ponera.Base.ViewModel;
using Ponera.PoneraAdmin.Core;

namespace PoneraAdmin.Controllers
{
    public class TestPagingDataController : SecureBaseController
    {
        private readonly IAnketBilgisiBusiness _anketBilgisiBusiness;

        public TestPagingDataController(IAnketBilgisiBusiness anketBilgisiBusiness)
        {
            _anketBilgisiBusiness = anketBilgisiBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAjaxData(int draw, int start, int length)
        {
            string search = Request.QueryString["search[value]"];
            int sortColumn = -1;
            string sortDirection = "asc";
            if (length == -1)
            {
                length = 995;
            }

            if (Request.QueryString["order[0][column]"] != null)
            {
                sortColumn = int.Parse(Request.QueryString["order[0][column]"]);
            }

            if (Request.QueryString["order[0][dir]"] != null)
            {
                sortDirection = Request.QueryString["order[0][dir]"];
            }
           
            DataTableData<AnketBilgisiModel> dataTableData = _anketBilgisiBusiness.GetAnketBilgisiByFilter(start, length, search, sortColumn, sortDirection);

            dataTableData.Draw = draw;

            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }
    }
}