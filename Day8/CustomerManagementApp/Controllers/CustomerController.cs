using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerManagementApp.Models;

namespace CustomerManagementApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IList<CustomerModel> customerModels = new List<CustomerModel>
            {
                new CustomerModel()
                {
                    Id = 1,
                    FirstName = "Deniz",
                    LastName = "İrgin",
                    EmailAddress = "deniz@armut.com",
                    HomeAddress = "Kartal",
                    WorkAddress = "Kadıköy"
                },
                new CustomerModel()
                {
                    Id = 2,
                    FirstName = "Hüseyin",
                    LastName = "Yazıcı",
                    EmailAddress = "huseyin@ponera.com",
                    HomeAddress = "Ataşehir",
                    WorkAddress = "Kozyatağı"
                },
            };

            // return Content("dasfasdasdas");
            // return Json()

            return View(customerModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View();
        }
    }
}