using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        /// <summary>
        ///Alles Frei
        ///</summary>
        [TestMethod()]
        public void T01_GetFreeRow_AllCellsFree()
        {
            int[,] allocation = {
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,0,0,0}
                              };
            int col = 0;
            int expected = 4;
            int actual;
            actual = Program.GetFreeRow(allocation, col);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Mitten drin
        ///</summary>
        [TestMethod()]
        public void T02_GetFReeRow_Middle()
        {
            int[,] allocation = {
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,1,0,0},
                                  {0,0,2,0,0},
                                  {0,0,1,0,0}
                              };

            int col = 2;
            int expected = 1;
            int actual;
            actual = Program.GetFreeRow(allocation, col);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Mitten drin
        ///</summary>
        [TestMethod()]
        public void T03_GetFReeRow_Full()
        {
            int[,] allocation = {
                                  {0,0,1,0,0},
                                  {0,0,2,0,0},
                                  {0,0,1,0,0},
                                  {0,0,2,0,0},
                                  {0,0,1,0,0}
                              };

            int col = 2;
            int expected = -1;
            int actual;
            actual = Program.GetFreeRow(allocation, col);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T04_IsWinner_No()
        {
            int[,] allocation = {
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,1,0,0}
                              };
            int row = 4;
            int col = 2;
            int expected = 0;
            int actual;
            actual = Program.IsWinner(allocation, row, col);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T05_IsWinner_Vertical()
        {
            int[,] allocation = {
                                  {0,0,0,0,0},
                                  {0,0,1,0,0},
                                  {0,0,1,0,0},
                                  {0,0,1,0,0},
                                  {0,0,1,0,0}
                              };
            int row = 1;
            int col = 2;
            int expected = 1;
            int actual;
            actual = Program.IsWinner(allocation, row, col);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T06_IsWinner_Horizontal()
        {
            int[,] allocation = {
                                  {0,0,0,0,0},
                                  {0,0,0,0,0},
                                  {0,0,0,2,0},
                                  {0,1,1,1,1},
                                  {0,2,1,2,2}
                              };
            int row = 3;
            int col = 4;
            int expected = 1;
            int actual;
            actual = Program.IsWinner(allocation, row, col);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T07_IsWinner_Diagonal1()
        {
            int[,] allocation = {
                                  {0,0,0,0,0},
                                  {0,0,0,1,0},
                                  {0,0,1,2,0},
                                  {0,1,1,1,0},
                                  {1,2,1,2,2}
                              };
            int row = 1;
            int col = 3;
            int expected = 1;
            int actual;
            actual = Program.IsWinner(allocation, row, col);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T08_IsWinner_Diagonal2()
        {
            int[,] allocation = {
                                  {0,2,0,0,0},
                                  {0,2,2,0,0},
                                  {0,1,1,2,0},
                                  {0,1,1,1,2},
                                  {1,2,1,2,2}
                              };
            int row = 0;
            int col = 1;
            int expected = 2;
            int actual;
            actual = Program.IsWinner(allocation, row, col);
            Assert.AreEqual(expected, actual);
        }

    }
}