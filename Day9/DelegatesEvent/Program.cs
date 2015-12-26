using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Factory factory = new Factory();
            factory.TempAlarm += factory_TempAlarm;
            factory.Build(100);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exceptionObject = (Exception) e.ExceptionObject;

            Console.WriteLine("Birt hata oluştu. Mesaj : {0}", exceptionObject.Message);
        }

        static void factory_TempAlarm(object sender, TempretureEventArgs e)
        {
            Console.WriteLine("Dikkat Sıcaklık {0}", e.Tempreture);
        }
    }
}
