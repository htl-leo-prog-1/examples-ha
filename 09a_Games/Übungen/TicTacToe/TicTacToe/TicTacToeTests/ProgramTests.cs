using Microsoft.VisualStudio.TestTools.UnitTesting;
using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_GetPositionRange()
        {
            //Arange
            bool expected = true;
            //Act
            bool actual = Program.CheckPosition(3);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void T02_GetPositionCellFree()
        {
            //Arange
            Board.Init(3,3,"TicTacToe");
            bool expected = true;
            //Act
            bool actual = Program.CheckPosition(3);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void T03_GetPositionCellUsed()
        {
            //Arange
            Board.Init(3, 3, "TicTacToe");
            Board.SetText(2,2,"O","Red");
            bool expected = false;
            //Act
            bool actual = Program.CheckPosition(3);
            //Assert
            Assert.AreEqual(expected,actual);
        }
    }

}