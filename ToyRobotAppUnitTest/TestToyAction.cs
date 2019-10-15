using Attribute.Toy;
using Interfaces;
using NUnit.Framework;
using ToyRobotApp.Action;
using ToyRobotApp.ConsoleOperation;
using ToyRobotApp.Toy;

namespace ToyRobotAppUnitTest
{
    [TestFixture]
    public class TestToyAction
    {
        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Test]
        public void TestValidBehaviourReport1()
        {
            // arrange
            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 1,2,EAST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,3,NORTH", output);
        }
        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Test]
        public void TestValidBehaviourReport2()
        {
            // arrange
            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 0,0,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
           
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 0,1,NORTH", output);
        }
        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Test]
        public void TestValidBehaviourReport3()
        {
            // arrange
            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 0,0,NORTH".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
           
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 0,0,WEST", output);
        }
        /// <summary>
        /// Test a valid place command
        /// </summary>
        [Test]
        public void TestValidBehaviourPlace()
        {
            // arrange
            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(4, robot.Position.Y);
            Assert.AreEqual(Direction.East, robot.Direction);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourPlace()
        {
            // arrange
            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(robot.Position);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [Test]
        public void TestValidBehaviourMove()
        {
            // arrange
            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 0,0,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 0,1,NORTH", simulator.GetReport());
        }

        /// <summary>
        /// Test and invalid move command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourMove()
        {
            // arrange
            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 2,4,NORTH", simulator.GetReport());
        }

        
    }
}
