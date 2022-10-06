using System;
using System.Collections.Generic;

namespace MarsRobotMovement
{
    public enum Directions
    {
        North = 1,//North
        South = 2,//South
        East = 3,//East
        West = 4//West
    }

    public interface IPosition
    {
        void StartToMove(List<int> maxPoints, string moves);
    }

    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Position()
        {
            X = 1;
            Y = 1;
            Direction = Directions.North;
        }

        private void MoveInL_Direction()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.West;
                    break;
                case Directions.South:
                    this.Direction = Directions.East;
                    break;
                case Directions.East:
                    this.Direction = Directions.North;
                    break;
                case Directions.West:
                    this.Direction = Directions.South;
                    break;
                default:
                    break;
            }
        }

        private void MoveInR_Direction()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.East;
                    break;
                case Directions.South:
                    this.Direction = Directions.West;
                    break;
                case Directions.East:
                    this.Direction = Directions.South;
                    break;
                case Directions.West:
                    this.Direction = Directions.North;
                    break;
                default:
                    break;
            }
        }

        private void MoveInF_Direction()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Y += 1;
                    break;
                case Directions.South:
                    this.Y -= 1;
                    break;
                case Directions.East:
                    this.X += 1;
                    break;
                case Directions.West:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void StartToMove(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                // If the robot reaches the limits of the plateau the command must be ignored
                if (this.X > 0 && this.X < maxPoints[0] && this.Y > 0 && this.Y < maxPoints[1])
                {
                    switch (move)
                    {
                        case 'F':
                        case 'f':
                            this.MoveInF_Direction();
                            break;
                        case 'L':
                        case 'l':
                            this.MoveInL_Direction();
                            break;
                        case 'R':
                        case 'r':
                            this.MoveInR_Direction();
                            break;
                        default:
                            Console.WriteLine($"Invalid Character {move}");
                            Console.WriteLine($"Suggestion : Only used these 3 Charters [ F , L , R ] ");
                            break;
                    }
                }
            }
        }
    }
}
