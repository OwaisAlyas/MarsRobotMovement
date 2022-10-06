using MarsRobotMovement;
using System;
using System.Linq;

namespace MarsRobotMovement
{
    public class Program
    {
        static void Main(string[] args)
        {
        Restart:
            try
            {
                Console.WriteLine("Please Provide the Grid Size for Rebort Movement, such as 5*5, 3*4, etc");
                var maxPoints = Console.ReadLine().Trim().Split('*').Select(int.Parse).ToList();
                if (maxPoints.Count == 2 && maxPoints[0]>0 && maxPoints[1]>0)
                {
                    Position position = new Position();
                    position.X = 1;
                    position.Y = 1;
                    position.Direction = (Directions)Enum.Parse(typeof(Directions), Directions.North.ToString().ToString());

                    Console.WriteLine("Please Provide the a string containing multiple commands as described below (Sample command string: FFRFLFLF )");
                    Console.WriteLine("1) L --> Turn the robot left");
                    Console.WriteLine("2) R --> Turn the robot right");
                    Console.WriteLine("3) F --> Move forward on it's facing direction");

                    var moves = Console.ReadLine().ToUpper();

                    try
                    {
                        position.StartToMove(maxPoints, moves);
                        Console.WriteLine(position.X + " , " + position.Y + " , " + position.Direction.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Grid Size");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("If you want to try again then press 'Y' else 'N'");
            var input = Console.ReadLine();

            if (input == "y" || input == "Y")
                goto Restart;
        }
    }
}
