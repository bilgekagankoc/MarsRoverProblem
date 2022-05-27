using MarsRoverProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Business
{
    public interface BasePosition
    {
        #region Methods
        void Turn90DegreesRight();
        void Turn90DegreesLeft();
        void Move();
        void StartMove(LocationModel location, List<int> rectangleSize, List<char> movementCode); 
        #endregion
    }
    public class Business : BasePosition
    {
        #region Properties
        public LocationModel Location { get; set; }
        public List<int> RectangleSize { get; set; }
        public List<char> MovementCode { get; set; }
        #endregion

        #region Methods
        public void Move()
        {
            switch (Location.Direction)
            {
                case Enums.Direction.N:
                    Location.DirectionY += 1;
                    break;
                case Enums.Direction.E:
                    Location.DirectionX += 1;
                    break;
                case Enums.Direction.W:
                    Location.DirectionX -= 1;
                    break;
                case Enums.Direction.S:
                    Location.DirectionY -= 1;
                    break;
                default:
                    Console.WriteLine($"The character you entered is not valid");
                    break;
            }
        }

        public void StartMove(LocationModel location, List<int> rectangleSize, List<char> movementCode)
        {
            foreach (var item in movementCode)
            {
                switch (item)
                {
                    case 'M':
                        Move();
                        break;
                    case 'L':
                        Turn90DegreesLeft();
                        break;
                    case 'R':
                        Turn90DegreesRight();
                        break;
                    default:
                        Console.WriteLine($"The character you entered is not valid {item}");
                        break;
                }
                if (location.DirectionX < 0 || location.DirectionX > rectangleSize[0] || location.DirectionY < 0 || location.DirectionY > rectangleSize[1])
                {
                    throw new Exception("Rover Out of Range Area");
                }
            }
        }

        public void Turn90DegreesLeft()
        {
            switch (Location.Direction)
            {
                case Enums.Direction.N:
                    Location.Direction = Enums.Direction.W;
                    break;
                case Enums.Direction.E:
                    Location.Direction = Enums.Direction.N;
                    break;
                case Enums.Direction.W:
                    Location.Direction = Enums.Direction.S;
                    break;
                case Enums.Direction.S:
                    Location.Direction = Enums.Direction.E;
                    break;
                default:
                    Console.WriteLine($"The character you entered is not valid");
                    break;
            }
        }

        public void Turn90DegreesRight()
        {
            switch (Location.Direction)
            {
                case Enums.Direction.N:
                    Location.Direction = Enums.Direction.E;
                    break;
                case Enums.Direction.E:
                    Location.Direction = Enums.Direction.S;
                    break;
                case Enums.Direction.W:
                    Location.Direction = Enums.Direction.N;
                    break;
                case Enums.Direction.S:
                    Location.Direction = Enums.Direction.W;
                    break;
                default:
                    Console.WriteLine($"The character you entered is not valid");
                    break;
            }
        } 
        #endregion
    }

}
