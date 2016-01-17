using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Customer
    {

    }

    class IntStack
    {
        private object[] _stackItems;

        public IntStack()
        {
            _stackItems = new object[1];
        }

        public void Push(int item)
        {
            _stackItems[0] = item;
        }

        public int Pop(int index)
        {
            return (int)_stackItems[index];
        }
    }

    class StringStack
    {

    }


    // class XStack

    class MyStack<T>
    {
        private T[] _mystackItems;

        public MyStack()
        {
            _mystackItems = new T[1];
        }

        public void Push(T item)
        {

        }

        public T Pop(int index)
        {
            return default(T);
        }
    }
}
