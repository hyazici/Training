using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("AnaSayfa")]
        public ActionResult Index()
        {
            return View();
        }

                [Route("hakkımızda")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

                [Route("iletisim")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}