using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI.Command
{
    class MoverForwardCommand:ICommand
    {
        public void Execute(Rover rover)
        {
            rover.MoveForward();
        }
    }
}
