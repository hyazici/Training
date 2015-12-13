using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI
{
    class Rover
    {
        public Coordinate Coordinate { get; set; }
        public ICompassDirection Direction { get; set; }

        public Plato Plato { get; set; }

        public void MoveForward()
        {
            Coordinate targetCoordinates = new Coordinate();
            targetCoordinates.X = Coordinate.X + Direction.X;
            targetCoordinates.Y = Coordinate.Y + Direction.Y;
            

            Coordinate lowerLeftCoordinates = Plato.BottomLeft;
            Coordinate upperRightCoordinates = Plato.TopRight;

            if ((targetCoordinates.X >= lowerLeftCoordinates.X && targetCoordinates.Y >= lowerLeftCoordinates.Y)
                   && (targetCoordinates.X <= upperRightCoordinates.X && targetCoordinates.Y <= upperRightCoordinates.Y))
            {
                Coordinate = targetCoordinates;
            }
            else
            {
                // TODO: Yürüyemez 
            }
        }

        public void TurnLeft()
        {
            Direction = Direction.TurnLeft();
        }

        public void TurnRight()
        {
            Direction = Direction.TurnRight();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Coordinate.X, Coordinate.Y, Direction.Name);
        }
    }
}
