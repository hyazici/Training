using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using CustomerManagementApp.Models;
using Model;

namespace CustomerManagementApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        // GET: Customer
        public ActionResult Index()
        {
            IList<Customer> customers = _customerService.GetCustomers();

            //IList<CustomerModel> customerModels = new List<CustomerModel>();

            //foreach (Customer customer in customers)
            //{
            //    CustomerModel customerModel = new CustomerModel();

            //    customerModel.Id = customer.Id;
            //    customerModel.FirstName = customer.FirstName;
            //    customerModel.LastName = customer.LastName;
            //    customerModel.EmailAddress = customer.EmailAddress;
            //    customerModel.HomeAddress = customer.HomeAddress;
            //    customerModel.WorkAddress = customer.WorkAddress;

            //    customerModels.Add(customerModel);
            //}

            var customerModels = customers.Select(customer => new CustomerModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                HomeAddress = customer.HomeAddress,
                WorkAddress = customer.WorkAddress,
            });

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