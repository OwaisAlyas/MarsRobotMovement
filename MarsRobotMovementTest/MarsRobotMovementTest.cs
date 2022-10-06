using System.Collections.Generic;
using MarsRobotMovement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRobotMovementTest
{
    [TestClass]
    public class MarsRobotMovementTest
    {
        [TestMethod]
        public void TestCase_FFRFLFLF_14West()
        {
            Position position = new Position()
            {
                X = 1,
                Y = 1,
                Direction = Directions.North
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "FFRFLFLF";

            position.StartToMove(maxPoints, moves);

            var actualOutput = position.X + " , " + position.Y + " , " + position.Direction.ToString();
            var expectedOutput = "1 , 4 , West";

            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestCase_LFLFLFLFF_01West()
        {
            Position position = new Position()
            {
                X = 1,
                Y = 1,
                Direction = Directions.North
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "LFLFLFLFF";

            position.StartToMove(maxPoints, moves);

            var actualOutput = position.X + " , " + position.Y + " , " + position.Direction.ToString();
            var expectedOutput = "0 , 1 , West";

            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestCase_FRRFFRFRRF_10South()
        {
            Position position = new Position()
            {
                X = 1,
                Y = 1,
                Direction = Directions.North
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "FRRFFRFRRF";

            position.StartToMove(maxPoints, moves);

            var actualOutput = position.X + " , " + position.Y + " , " + position.Direction.ToString();
            var expectedOutput = "1 , 0 , South";

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
