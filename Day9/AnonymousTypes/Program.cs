using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //var customer = new {Id = 1, Name = "Deniz", LastName = "İrgin", CreateDate = DateTime.Now};

            //Type type = customer.GetType();
            //PropertyInfo[] propertyInfos = type.GetProperties();

            //foreach (PropertyInfo propertyInfo in propertyInfos)
            //{
            //    object value = propertyInfo.GetValue(customer);
            //    string name = propertyInfo.Name;

            //    Console.WriteLine("{0} - {1}", name, value);
            //}

            //var customers = new[]
            //{
            //    new {Id = 1.1, Name = "Deniz", LastName = "İrgin", CreateDate = DateTime.Now},
            //    new {Id = 20.5, Name = "Hüseyin", LastName = "Yazıcı", CreateDate = DateTime.Now}
            //};

            IList<Customer> customerss = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Jack"},
                new Customer() {Id = 2, Name = "Jones"},
                new Customer() {Id = 3, Name = "Muammer"}
            };

            IList<Adress> adresses = new List<Adress>()
            {
                new Adress() {Id = 1, CustomerId = 1, Text = "dsasdasdasdsa"},
                new Adress() {Id = 2, CustomerId = 2, Text = "jjkjjs s s s"},
                new Adress() {Id = 3, CustomerId = 3, Text = "şşşllele ss sa"},
            };

            var cusAdress = (from cus in customerss
                from ad in adresses
                where cus.Id == ad.CustomerId
                select new
                {
                    Id = cus.Id,
                    Name = cus.Name,
                    AddressText = ad.Text
                }).ToList();

            foreach (var x in cusAdress)
            {
                Console.WriteLine("{0} - {1} - {2}", x.Id, x.Name, x.AddressText);
            }

        }
    }

    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Adress
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Text { get; set; }
    }
}
