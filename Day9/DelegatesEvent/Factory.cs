using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesEvent
{
    public class Factory
    {
        private double _tempture;
        public event TempretureEventHandler TempAlarm;

        public void Build(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i%10 == 0)
                {
                    _tempture = _tempture + 1;
                }

                if (_tempture >= 5 && TempAlarm != null)
                {
                    TempAlarm(this, new TempretureEventArgs() { Tempreture = _tempture });
                }

                if (i == 70)
                {
                    throw new Exception("Bir sıkıntı var.");
                }

                Thread.Sleep(100);
            }
        }
    }

    public class TempretureEventArgs
    {
        public double Tempreture { get; set; }
    }

    public delegate void TempretureEventHandler(object sender, TempretureEventArgs e);       
}
