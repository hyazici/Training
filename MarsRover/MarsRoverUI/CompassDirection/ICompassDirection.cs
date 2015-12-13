using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI
{
    public interface ICompassDirection
    {
        int X { get; }
        int Y { get; }
        string Name { get;}

        ICompassDirection TurnLeft();
        ICompassDirection TurnRight();
        
    }

}
