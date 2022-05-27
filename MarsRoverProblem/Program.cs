using MarsRoverProblem.Business;
using MarsRoverProblem.Enums;
using MarsRoverProblem.Models;


List<int> rectangleSize = new List<int>();
List<char> movementCode;
List<string> currentLocation;
int c1;
int c2;
Start();
void Start()
{
    try
    {
        if (rectangleSize.Count == 0)
        {
            Console.Write("Enter the area where the rover will move\n");
            rectangleSize = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        }
        Console.Write("Enter the current location\n");
        currentLocation = Console.ReadLine().Trim().Split(' ').ToList();
        c1 = Convert.ToInt32(currentLocation[0]);
        c2 = Convert.ToInt32(currentLocation[1]);
        Console.Write("Enter the movement code\n");
        movementCode = Console.ReadLine().Trim().ToUpper().ToList();
    }
    catch (Exception)
    {
        Restart();
    }

    if (rectangleSize.Count > 0 && movementCode.Count > 0 && currentLocation.Count > 0)
    {

        Validation v1 = new Validation(rectangleSize, movementCode, currentLocation);
        var result = v1.Result;

        if (result == true)
        {
            LocationModel l1 = new LocationModel()
            {
                DirectionX = c1,
                DirectionY = c2,
                Direction = (Direction)Enum.Parse(typeof(Direction), currentLocation[2])
            };
            Business b1 = new Business();
            b1.Location = l1;
            b1.RectangleSize = rectangleSize;
            b1.MovementCode = movementCode;
            b1.StartMove(l1, rectangleSize, movementCode);
            LocationModel resultLocation = b1.Location;
            Console.Write($"{resultLocation.DirectionX} {resultLocation.DirectionY} {resultLocation.Direction}\n");
            Console.Write("Press any key to try again\n");
            Console.ReadLine();
            Start();
        }
    }
    else
    {
        Restart();
    }

    void Restart()
    {
        Console.Write("You entered an invalid value \nPress any key to try again");
        Console.Read();
        Start();
    }
}
