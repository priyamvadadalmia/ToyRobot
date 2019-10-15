using Attribute.Toy;
using NUnit.Framework;
using ToyRobotApp.Toy;

namespace ToyRobotAppUnitTest
{
    [TestFixture]
    public class TestToyBoard
    {

        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [Test]
        public void TestInvalidBoardPosition()
        {
            // arrange
            ToyBoard toyBoard = new ToyBoard(5, 5);
            Position position = new Position(6, 6);

            // act
            var result = toyBoard.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test valid positon 
        /// </summary>
        [Test]
        public void TestValidBoardPosition()
        {
            // arrange
            ToyBoard toyBoard = new ToyBoard(5, 5);
            Position position = new Position(1, 4);

            // act
            var result = toyBoard.IsValidPosition(position);

            // assert
            Assert.IsTrue(result);
        }

    }
}
