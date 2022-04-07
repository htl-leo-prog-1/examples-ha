using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tests
{
    [TestClass()]
    public class TetrisTests
    {
        /// <summary>
        ///A test for IsLastRowFilled
        ///</summary>
        [TestMethod()]
        public void T01_EmptyPlate()
        {
            bool[,] gamePlate = new bool[5, 5];
            bool expected = false;
            bool actual;
            actual = Tetris.IsLastRowFilled(gamePlate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T02_LastRowIsFull()
        {
            bool[,] gamePlate = {
                                    {false, false, true},
                                    {false, false, true},
                                    {true, true, true}
                                };
            bool expected = true;
            bool actual;
            actual = Tetris.IsLastRowFilled(gamePlate);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void T03_LastRowIsPartialFilled()
        {
            bool[,] gamePlate = {
                                    {false, false, true},
                                    {false, false, true},
                                    {true, false, true}
                                };
            bool expected = false;
            bool actual;
            actual = Tetris.IsLastRowFilled(gamePlate);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void T04_EmptyPlate()
        {
            bool[,] gamePlate = {
                                    {false, false, false},
                                    {false, false, false},
                                    {false, false, false}
                                };
            bool[,] expected = {
                                    {false, false, false},
                                    {false, false, false},
                                    {false, false, false}
                                };
            bool[,] actual;
            actual = Tetris.DeleteLastRow(gamePlate);
            Assert.IsTrue(AreEqualArrays(expected, actual));
        }

        [TestMethod()]
        public void T05_PartialFilledPlate()
        {
            bool[,] gamePlate = {
                                    {true, false, false},
                                    {true, true, false},
                                    {true, true, true}
                                };
            bool[,] expected = {
                                    {false, false, false},
                                    {true, false, false},
                                    {true, true, false}
                                };
            bool[,] actual;
            actual = Tetris.DeleteLastRow(gamePlate);
            Assert.IsTrue(AreEqualArrays(expected, actual));
        }

        /// <summary>
        /// Vergleicht den Inhalt zweier zweidimensionaler
        /// bool-Arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns>Inhalte sind gleich</returns>
        static bool AreEqualArrays(bool[,] arr1, bool[,] arr2)
        {
            if (arr1.GetLength(0) != arr2.GetLength(0)
                || arr1.GetLength(1) != arr2.GetLength(1))
            {
                return false;
            }
            for (int row = 0; row < arr1.GetLength(0); row++)
            {
                for (int col = 0; col < arr1.GetLength(1); col++)
                {
                    if (arr1[row, col] != arr2[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}