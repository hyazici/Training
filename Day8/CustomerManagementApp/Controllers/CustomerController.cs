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

            var customerModels = customers.Select(customer => CustomerToCustomerModel(customer));
            

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
                Customer customer = CustomerModelToCustomer(customerModel);
                _customerService.AddCustomer(customer);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer customer = _customerService.GetCustomerById(id);

            CustomerModel customerModel = CustomerToCustomerModel(customer);

            return View(customerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel customerModel)
        {

            if (ModelState.IsValid)
            {
                Customer customer = CustomerModelToCustomer(customerModel);
                customer.Id = customerModel.Id;

                _customerService.UpdateCustomer(customer);
                
                return RedirectToAction("Index");
            }
            return View();
        }

        private CustomerModel CustomerToCustomerModel(Customer customer)
        {
            CustomerModel customerModel = new CustomerModel();

            customerModel.Id = customer.Id;
            customerModel.FirstName = customer.FirstName;
            customerModel.LastName = customer.LastName;
            customerModel.EmailAddress = customer.EmailAddress;
            customerModel.HomeAddress = customer.HomeAddress;
            customerModel.WorkAddress = customer.WorkAddress;
            return customerModel;
        }

        private Customer CustomerModelToCustomer(CustomerModel customerModel)
        {
            Customer customer = new Customer();
            customer.FirstName = customerModel.FirstName;
            customer.LastName = customerModel.LastName;
            customer.HomeAddress = customerModel.HomeAddress;
            customer.WorkAddress = customerModel.WorkAddress;
            customer.EmailAddress = customerModel.EmailAddress;

            return customer;
        }
    }
}