using MarsRoverUI.CompassDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI
{
    public class CompassHelper
    {
        public static ICompassDirection GetCompass(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return new NorthDirection();
                case 'W':
                    return new WestDirection();
                case 'E':
                    return new EastDirection();
                case 'S':
                    return new SouthDirection();
                default:
                    // TODO: Kontrol Et
                    throw new Exception("");
            }

        }
    }
}
