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
        void StartMoving(List<int> maxPoints, string moves);
    }

    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Position()
        {
            X = Y = 0;
            Direction = Directions.North;
        }

        private void Rotate90Left()
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

        private void Rotate90Right()
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

        private void MoveInSameDirection()
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

        public void StartMoving(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'F':
                    case 'f':
                        this.MoveInSameDirection();
                        break;
                    case 'L':
                    case 'l':
                        this.Rotate90Left();
                        break;
                    case 'R':
                    case 'r':
                        this.Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        Console.WriteLine($"Suggestion : Only used these 3 Charters [ F , L , R ] ");
                        break;
                }

                if (this.X < 0 || this.X > maxPoints[0] || this.Y < 0 || this.Y > maxPoints[1])
                {
                    throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }
    }
}
