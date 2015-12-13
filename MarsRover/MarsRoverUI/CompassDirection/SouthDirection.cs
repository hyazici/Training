using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI.CompassDirection
{
    public class SouthDirection:ICompassDirection
    {
        public int X
        {
            get { return 0; }
        }

        public int Y
        {
            get { return -1; }
        }

        public string Name
        {
            get { return "South"; }
        }


        public ICompassDirection TurnLeft()
        {
            return new EastDirection();
        }

        public ICompassDirection TurnRight()
        {
            return new WestDirection();
        }
    }
}
