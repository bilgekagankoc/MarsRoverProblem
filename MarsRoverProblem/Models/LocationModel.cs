using MarsRoverProblem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Models
{
    public class LocationModel
    {
        public int DirectionX { get; set; } = 0;
        public int DirectionY { get; set; } = 0;
        public Direction Direction { get; set; } = Direction.N;
    }
}
