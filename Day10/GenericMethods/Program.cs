using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer ser = new XmlSerializer();

            string serValue = ser.Serialize<Order>(new Order());
            string sersValue = ser.Serialize<Customer>(new Customer());
        }
    }

    public class Order
    {

    }

    public class Customer
    {

    }

    public static class Converter
    {

        public static string ConvertToString<T>(T value)
        {
            return string.Empty;
        }

        public static int ConvertToInt32<T>(T value)
            where T : class
        {
            return default(int);
        }
    }

    public interface ISerializer
    {
        string Serialize<T>(T item);

        T Deseriliaze<T>(string value);
    }

    public class XmlSerializer : ISerializer
    {
        public string Serialize<T>(T item)
        {
            throw new NotImplementedException();
        }

        public T Deseriliaze<T>(string value)
        {
            throw new NotImplementedException();
        }
    }

    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T item)
        {
            throw new NotImplementedException();
        }

        public T Deseriliaze<T>(string value)
        {
            throw new NotImplementedException();
        }
    }


}
