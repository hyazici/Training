using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DataAccessLayer
{
    public class CustomerRepository : BaseRepository
    {
        public IList<Customer> GetCustomers(bool isActive = true)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                IList<Customer> customers = connection.Query<Customer>("Select * From Customer").ToList();

                return customers;
            }
        }

        public void AddCustomer (Customer customer)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                string cmd = @"INSERT INTO Customer (FirstName, LastName, EmailAddress, HomeAddress, WorkAddress, CreateDate,IsActive) 
                                        VALUES( @FirstName, @LastName, @EmailAddress, @HomeAddress, @WorkAddress, @CreateDate, @IsActive )";

                connection.Execute(cmd, customer);                              
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                string cmd = @"UPDATE Customer SET FirstName = @FirstName , LastName = @LastName, EmailAddress = @EmailAddress, HomeAddress = @HomeAddress , WorkAddress= @WorkAddress, UpdateDate = @UpdateDate ,IsActive = @IsActive WHERE Id = @Id";

                connection.Execute(cmd, customer);
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connStr))
            {
                Customer customers = connection.Query<Customer>("Select * From Customer Where Id = @id", new {id = id }).FirstOrDefault();

                return customers;
            }
        }
    }
}
