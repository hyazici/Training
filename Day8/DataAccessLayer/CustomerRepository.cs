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
    }
}
