using System.Collections.Generic;
using DataAccessLayer;
using Model;

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
    }
}
