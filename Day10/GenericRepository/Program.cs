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

    public class CustomerRepository : IRepository<Customer, int>
    {
        public void Add(Customer entity)
        {
            // git dapper'ı çağır
            // query'ni yaz
            // dapper'ı dispose et
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }
    }

    //public abstract class BaseRepository<T>
    //{
    //    pub
    //}
}
