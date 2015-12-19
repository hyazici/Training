using System.Collections.Generic;
using DataAccessLayer;
using Model;
using System;

namespace BusinessLayer
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public IList<Customer> GetCustomers()
        {
            IList<Customer> customers = _customerRepository.GetCustomers(true);

            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            customer.CreateDate = DateTime.Now;
            customer.IsActive = true;
            _customerRepository.AddCustomer(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            customer.UpdateDate = DateTime.Now;
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            customer.UpdateDate = DateTime.Now;
            customer.IsActive = false;
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
