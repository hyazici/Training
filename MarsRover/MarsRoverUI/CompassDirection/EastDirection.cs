using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI.CompassDirection
{
    public class EastDirection:ICompassDirection
    {
        public int X
        {
            get { return 1; }
        }

        public int Y
        {
            get { return 0; }
        }

        public string Name
        {
            get { return "East"; }
        }

        public ICompassDirection TurnLeft()
        {
            return new NorthDirection();
        }

        public ICompassDirection TurnRight()
        {
            return new SouthDirection();
        }
    }
}
