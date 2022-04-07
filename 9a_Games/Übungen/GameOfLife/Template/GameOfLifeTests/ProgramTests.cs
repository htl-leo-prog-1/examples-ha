using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_CountNeighboursTestMiddle()
        {
            bool[,] world = {{false, false, false, true},
                             {false, false, false, true},
                             {true,  true,  true,  true},
                             {true,  true,  false, false}};
            int count = Program.CountNeighbours(world, 1, 1);
            Assert.AreEqual(3, count);
            count = Program.CountNeighbours(world, 1, 2);
            Assert.AreEqual(5, count);
            count = Program.CountNeighbours(world, 2, 1);
            Assert.AreEqual(4, count);
            count = Program.CountNeighbours(world, 2, 2);
            Assert.AreEqual(4, count);
        }

        [TestMethod()]
        public void T02_CountNeighboursTestCorner()
        {
            bool[,] world = {{false, false, false, true},
                             {false, false, false, true},
                             {true,  true,  true,  true},
                             {true,  true,  false, false}};
            int count = Program.CountNeighbours(world, 0, 0);
            Assert.AreEqual(0, count);
            count = Program.CountNeighbours(world, 0, 3);
            Assert.AreEqual(1, count);
            count = Program.CountNeighbours(world, 3, 0);
            Assert.AreEqual(3, count);
            count = Program.CountNeighbours(world, 3, 3);
            Assert.AreEqual(2, count);
        }

        [TestMethod()]
        public void T03_CountNeighboursTestBorder()
        {
            bool[,] world = {{false, false, false, true},
                             {false, false, false, true},
                             {true,  true,  true,  true},
                             {true,  true,  false, false}};
            int count = Program.CountNeighbours(world, 0, 2);
            Assert.AreEqual(2, count);
            count = Program.CountNeighbours(world, 2, 0);
            Assert.AreEqual(3, count);
            count = Program.CountNeighbours(world, 3, 2);
            Assert.AreEqual(4, count);
            count = Program.CountNeighbours(world, 2, 3);
            Assert.AreEqual(2, count);
        }

    }
}