using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI.CompassDirection
{
    public class WestDirection:ICompassDirection
    {
        public int X
        {
            get { return -1; }
        }

        public int Y
        {
            get { return 0; }
        }

        public string Name
        {
            get { return "West"; }
        }


        public ICompassDirection TurnLeft()
        {
            return new SouthDirection();
        }

        public ICompassDirection TurnRight()
        {
            return new NorthDirection();
        }
    }
}
