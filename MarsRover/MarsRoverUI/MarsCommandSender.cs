using MarsRoverUI.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI
{
    class MarsCommandSender
    {
        private Plato _plato;
        private Rover _rover;
        
        public string Output()
        {
            return _rover.ToString();
        }

        public void ExecuteCommand(string str)
        {
            // TODO: validasyonları yap
            string[] keyArr = str.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
           _plato = BuildPlato(keyArr[0]);
           _rover = BuildRover(keyArr[1]);

           IList<ICommand> commands = CommandHelper.ParseCommands(keyArr[2]);
           foreach (ICommand command in commands)
           {
               command.Execute(_rover);
           }

        }

        private Plato BuildPlato(string str)
        {
            Plato plato = new Plato()
            {
                BottomLeft = new Coordinate() { X = 0, Y = 0 }
            };

           Coordinate coordinate = CoordinateHelper.Parse(str);

           plato.TopRight = coordinate;
           return plato;

        }

        private Rover BuildRover(string str)
        {
            string[] keyArr = str.Split(' ');

            Coordinate coordinate = CoordinateHelper.Parse(keyArr[0], keyArr[1]);
            ICompassDirection compassDirection = CompassHelper.GetCompass(Convert.ToChar(keyArr[2]));

            Rover rover = new Rover();
            rover.Coordinate = coordinate;
            rover.Direction = compassDirection;
            rover.Plato = _plato;

            return rover;            
        }

    }
}
