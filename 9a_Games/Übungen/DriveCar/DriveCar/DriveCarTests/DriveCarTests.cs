using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games.Tests
{
    [TestClass()]
    public class DriveCarTests
    {
        [TestMethod()]
        public void T01_BorderReached_Simplest()
        {
            //arrange
            int actCol = 5;
            int actRow = 5;
            Board.Init(10, 10, "Test");
            bool expected = false;

            //act
            bool actual = DriveCar.IsBorderReached(actRow, actCol);
            // Assert
            Assert.AreEqual(expected,actual);
        }
        [TestMethod()]
        public void T02_BorderReached_RightOut()
        {
            //arrange
            int actCol = 10;
            int actRow = 5;
            Board.Init(10, 10, "Test");
            bool expected = true;

            //act
            bool actual = DriveCar.IsBorderReached(actRow, actCol);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void T03_BorderReached_LeftOut()
        {
            //arrange
            int actCol = -1;
            int actRow = 5;
            Board.Init(10, 10, "Test");
            bool expected = true;

            //act
            bool actual = DriveCar.IsBorderReached(actRow, actCol);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}