using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList myList = new ArrayList();

            //// myList.Add()

            //MyStack<int> intList = new MyStack<int>();
            //MyStack<string> strList = new MyStack<string>();
            //MyStack<Customer> cusList = new MyStack<Customer>();

            //// Olmaz çünkü int bir class değil
            //// MyGenericClassCons<int> genericClas = new MyGenericClassCons<int>();

            ////MyGenericStructCons<Customer> genericCust = new MyGenericStructCons<Customer>
            //MyGenericStructCons<int> genericCust = new MyGenericStructCons<int>();
            //MyGenericClassCons2<Order> order = new MyGenericClassCons2<Order>();

            //MyGenericClass<Circle> Circle = new MyGenericClass<Circle>();

            //Circle.Foo();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("ArrayList Başladı");
            ArrayList arrayList = new ArrayList();

            for (int i = 0; i < 1000; i++)
            {
                arrayList.Add(i);

                object intObj = arrayList[i];

                // Console.WriteLine(intObj);
            }

            sw.Stop();
            Console.WriteLine("ArrayList bitti");
            Console.WriteLine(sw.ElapsedTicks);
            sw.Reset();


            sw.Start();
            Console.WriteLine("List Başladı");
            List<int> intList = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                intList.Add(i);

                int intReal = intList[i];

                // Console.WriteLine(intObj);
            }

            sw.Stop();
            Console.WriteLine("List bitti");
            Console.WriteLine(sw.ElapsedTicks);
            sw.Reset();
        }
    }

    class MyGenericClassCons<T> 
        where T : class
    {

    }

    class MyGenericStructCons<T>
        where T : struct
    {

    }

    public class Order
    {
        public Order()
        {

        }

        public Order(int orderId)
        {

        }
    }

    class MyGenericClassCons2<T>
        where T : class, 
        new()
    {

    }

    class MyGenericClass<T>
        where T : IShape,
        new ()
    {
        public void Foo()
        {
            T shape = new T();

            double result = shape.CalcArea();

            Console.WriteLine(result);
        }
    }

    public interface IShape
    {
        double CalcArea();
    }

    public class Circle : IShape
    {
        public double CalcArea()
        {
            return 100;
        }
    }

    public class Square : IShape
    {
        public double CalcArea()
        {
            return 200;
        }
    }

    class MyGenericType<T, K>
        where T : class, new()
        where K : struct
    {
    }
}
