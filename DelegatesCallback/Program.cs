using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesCallback
{
    class Program
    {
        static void Main(string[] args)
        {
            // Counter(1000, (i => i%2 == 0), i => Console.WriteLine("Çift sayı bulundu {0}", i));

            using (FileStream fileStream = new FileStream(@"D:\Temp\config.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fileStream.Length];

                // int read = fileStream.Read(bytes, 0, bytes.Length);

                fileStream.BeginRead(bytes, 0, bytes.Length, UserCallback, new object());
            }
        }

        private static void UserCallback(IAsyncResult ar)
        {
            var asyncState = ar.AsyncState;
            var isCompleted = ar.IsCompleted;
        }

        static void Counter(int length, Func<int, bool> condition, Action<int> callBack)
        {
            for (int i = 0; i < length; i++)
            {
                if (condition(i))
                {
                    callBack(i);
                }

                Thread.Sleep(10);
            }
        }
    }
}
