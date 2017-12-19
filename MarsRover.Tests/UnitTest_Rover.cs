using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{
    [TestClass]
    public class UnitTest_Rover
    {
        [TestMethod]
        public void Test_WhenRoverGetsToBoundary_ItShouldStop()
        {
            //Arrange
            Rover rover = new Rover(0, 0, 'E', new Grid(10, 10));

            //Act
            var result = rover.Move("MMMMMMMMMMM"); //make rover move 11 spaces i.e. off the grid

            //Assert
            Assert.IsFalse(result);

            Assert.AreEqual(rover.ReportPosition(), "10 0 E"); //it stopped before going past boundary
        }

        [TestMethod]
        public void Test_RoverWithValidMovement_ShouldMove()
        {
            //Arrange
            Rover rover = new Rover(0, 0, 'E', new Grid(10, 10));

            //Act
            var result = rover.Move("MMMMMMMMMMLMMMMM");

            //Assert
            Assert.IsTrue(result);

            Assert.AreEqual(rover.ReportPosition(), "10 5 N");
        }

        [TestMethod]
        public void Test_RoverWithCircularMovement_ShouldEndAtStart()
        {
            //Arrange
            Rover rover = new Rover(0, 0, 'N', new Grid(10, 10));

            //Act
            var result = rover.Move("MMRMMRMMRMM");

            //Assert
            Assert.IsTrue(result);

            Assert.AreEqual(rover.ReportPosition(), "0 0 W");
        }

        [TestMethod]
        public void Test_RoverWithInvalidMovement_ShouldNotMove()
        {
            //Arrange
            Rover rover = new Rover(10, 10, 'S', new Grid(10, 10));

            //Act
            var result = rover.Move("INVALID");

            //Assert
            Assert.IsFalse(result);

            Assert.AreEqual(rover.ReportPosition(), "10 10 S");
        }

        [TestMethod]
        public void Test_GridWithValidPosition_ShouldReturnTrue()
        {
            //Arrange
            Grid grid = new Grid(10, 10);

            //Act
            var result = grid.IsInBounds(5, 5);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_GridWithInvalidPosition_ShouldReturnFalse()
        {
            //Arrange
            Grid grid = new Grid(10, 10);

            //Act
            var result = grid.IsInBounds(11, 5);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
