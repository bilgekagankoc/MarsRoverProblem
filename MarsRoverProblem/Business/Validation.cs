using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Business
{
    public interface IValidation
    {
        bool IsValid(List<int> area, List<char> moveCod, List<string> currentLocation);
    }
    public class Validation : IValidation
    {
        public List<int> Area { get; set; }
        public List<char> MoveCode { get; set; }
        public List<string> CurrentLocation { get; set; }
        public bool Result { get; set; }

        public Validation(List<int> area, List<char> moveCode, List<string> currentLocation)
        {
            Area = area;
            MoveCode = moveCode;
            CurrentLocation = currentLocation;
            Result = IsValid(area, moveCode, currentLocation);
        }
        public bool IsValid(List<int> area, List<char> moveCode, List<string> currentLocation)
        {
            bool valid = true;
            foreach (var areaItem in area)
            {
                if (areaItem < 0)
                    valid = false;
                if (area.Count > 3 || area.Count == 0)
                    valid = false;

            }
            foreach (var moveCodeItem in moveCode)
            {
                var value = (int)moveCodeItem;
                if (value != 76 && value != 77 && value != 82)
                    valid = false;
            }
            if (Convert.ToInt32(currentLocation[0]) < 0 || Convert.ToInt32(currentLocation[0]) > area[0])
                valid = false;
            if (Convert.ToInt32(currentLocation[1]) < 0 || Convert.ToInt32(currentLocation[1]) > area[1])
                valid = false;
            return valid;
        }
    }
}
