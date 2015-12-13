using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI
{
    public static class CoordinateHelper
    {
        public static Coordinate Parse(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                // Exception Fırlatılacak
                
            }

            string[] strCoordinate = command.Split(' ');
            if (strCoordinate.Length != 2)
            {
                // Exception Fırlatılacak
            }

            return Parse(strCoordinate[0], strCoordinate[1]);
        }

        public static Coordinate Parse(string strX, string strY)
        {
            int xVal = 0;
            int yVal = 0;

            bool parsed = int.TryParse(strX, out xVal);
            if (!parsed)
            {
                // Exception Fırlatılacak
            }

            parsed = int.TryParse(strY, out yVal);
            if (!parsed)
            {
                // Exception Fırlatılacak
            }

            Coordinate coordinate = new Coordinate();
            coordinate.X = xVal;
            coordinate.Y = yVal;
            return coordinate;
        }

    }
}
