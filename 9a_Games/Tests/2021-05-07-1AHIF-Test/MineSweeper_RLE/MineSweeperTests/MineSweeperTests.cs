using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Tests
{
    [TestClass()]
    public class MineSweeperTests
    {
        [TestMethod()]
        public void T01_CountMinesOnBoard_3()
        {
            bool[,] minesBoard = { {true,false,true},
                                  {false, false,true},
                                  {false, false,true} };
            int counter = Program.CountMinesOnBoard(minesBoard);
            Assert.AreEqual(4, counter, "3 Minen im Feld");
            bool[,] minesBoard2 = { {false,false},
                                   {false, false} };
            Assert.AreEqual(0, Program.CountMinesOnBoard(minesBoard2), "0 Minen im Feld");
        }

        [TestMethod()]
        public void T02_CountMinesOnBoard_0()
        {
            bool[,] minesBoard = { {false,false},
                                   {false, false} };
            Assert.AreEqual(0, Program.CountMinesOnBoard(minesBoard), "0 Minen im Feld");
        }

        [TestMethod()]
        public void T03_HideMines_10_in_25()
        {
            bool[,] minesBoard;
            minesBoard = Program.CreateMines(10, 5);
            Assert.AreEqual(10, Program.CountMinesOnBoard(minesBoard), "keine 10 Minen im Feld");
        }

        [TestMethod()]
        public void T04_HideMines_25_in_16()
        {
            bool[,] minesBoard;
            minesBoard = Program.CreateMines(25, 4);
            Assert.AreEqual(4*4, Program.CountMinesOnBoard(minesBoard), "keine 16 Minen im Feld");
        }

        [TestMethod()]
        public void T05_HideMines_0_in_25()
        {
            bool[,] minesBoard;
            minesBoard = Program.CreateMines(0, 5);
            Assert.AreEqual(0, Program.CountMinesOnBoard(minesBoard), "keine 0 Minen im Feld");
        }

        [TestMethod()]
        public void T06_CountMinesAround_Corner()
        {
            bool[,] minesBoard = { {true,    false,  true},
                                  {false,   false,  true},
                                  {false,   false,  true} };
            int counter = Program.CountMinesAround(minesBoard, 0, 0);
            Assert.AreEqual(0, counter, "0/0 hat keinen Nachbarn");
        }

        [TestMethod()]
        public void T07_CountMinesAround_Center()
        {
            bool[,] minesBoard = { {true,    false,  true},
                                  {false,   false,  true},
                                  {false,   false,  true} };
            int counter = Program.CountMinesAround(minesBoard, 1, 1);
            Assert.AreEqual(4, counter, "1/1 hat 4 Nachbarn");
        }

        [TestMethod()]
        public void T08_CountMinesAround_LowerCorner()
        {
            bool[,] minesBoard = { {true,    false,  true},
                                  {false,   false,  true},
                                  {false,   false,  true} };
            int counter = Program.CountMinesAround(minesBoard, 2, 2);
            Assert.AreEqual(1, counter, "2/2 hat 1 Nachbarn");
        }

        [TestMethod()]
        public void T09_CountMinesAround_LastRow()
        {
            bool[,] minesBoard = { {true,    false,  true},
                                  {false,   false,  true},
                                  {false,   false,  true} };
            int counter = Program.CountMinesAround(minesBoard, 2, 1);
            Assert.AreEqual(2, counter, "2/1 hat 2 Nachbarn");
        }


    }
}