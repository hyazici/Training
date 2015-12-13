using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI.CompassDirection
{
    public class NorthDirection : ICompassDirection
    {
        public int X
        {
            get
            {
                return 0;
            }
        }

        public int Y
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "North";
            }
        }


        public ICompassDirection TurnLeft()
        {
            return new WestDirection();
        }

        public ICompassDirection TurnRight()
        {
            return new EastDirection();
        }
    }
}
