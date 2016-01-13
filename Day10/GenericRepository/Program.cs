using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            // customerRepository.
        }
    }

    public interface IRepository<TEntity, KPrimaryKey>
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        TEntity Get(KPrimaryKey primaryKey);

        void Delete(TEntity entity);
    }

    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

//    public class CustomerRepository : IRepository<Customer, int>
//    {
//        public void Add(Customer entity)
//        {
//            // git dapper'ı çağır
//            // query'ni yaz
//            // dapper'ı dispose et

////            using (IDbConnection connection = new SqlConnection(_connStr))
////            {
////                string cmd = @"INSERT INTO Customer (FirstName, LastName, EmailAddress, HomeAddress, WorkAddress, CreateDate,IsActive) 
////                                        VALUES( @FirstName, @LastName, @EmailAddress, @HomeAddress, @WorkAddress, @CreateDate, @IsActive )";

////                connection.Execute(cmd, customer);
////            }
//        }

//        public void Update(Customer entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Customer Get(int primaryKey)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(Customer entity)
//        {
//            throw new NotImplementedException();
//        }
//    }

    public abstract class BaseRepository<TEntity, KPrimaryKey> : IRepository<TEntity, KPrimaryKey>
    {
        public void Add(TEntity entity)
        {
// query generate et

            //            using (IDbConnection connection = new SqlConnection(_connStr))
            //            {
            //                string cmd = generate edilen query veriler.

            //                connection.Execute(cmd, entity);
            //            }
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(KPrimaryKey primaryKey)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        protected string GenerateSelectQuery(params string[] columns)
        {
            return "Select * from .....";
        }
    }

    public class CustomerRepository : BaseRepository<Customer, int>
    {
        public Customer GetCustomerByLastName(string name)
        {
            // GenerateSelectQuery()

            return new Customer();
        }
    }
}
