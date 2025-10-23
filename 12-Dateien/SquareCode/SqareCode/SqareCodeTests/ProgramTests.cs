using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqareCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqareCode.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_Condense()
        {
            Assert.AreEqual("abc", SquareCode.Condense("abc"), "No blank");
            Assert.AreEqual("abcde$3", SquareCode.Condense("abc de"), "1 blank in the middle");
            Assert.AreEqual("abcde$5", SquareCode.Condense("abcde "),"1 blank at the end");
            Assert.AreEqual("abcde$0$4$7", SquareCode.Condense(" abc de "),"3 blanks anywhere");
            Assert.AreEqual("123$1$3", SquareCode.Condense("1 2 3"),"2 blanks between digits");
        }

        [TestMethod()]
        public void T02_Expand()
        {
            Assert.AreEqual("abc", SquareCode.Expand("abc"), "No blank");
            Assert.AreEqual("abc de", SquareCode.Expand("abcde$3"), "1 blank in the middle");
            Assert.AreEqual("abcde ", SquareCode.Expand("abcde$5"), "1 blank at the end");
            Assert.AreEqual(" abc de ", SquareCode.Expand("abcde$0$4$7"), "3 blanks anywhere");
            Assert.AreEqual("1 2 3", SquareCode.Expand("123$1$3"), "2 blanks between digits");
        }

        [TestMethod()]
        public void T03_CreateCypherBoard()
        {
            char[,] board = SquareCode.CreateCypherBoard(4);
            Assert.AreEqual(2, board.GetLength(0), "CreateCypherBoard: Sqrt(4) => 2 x 2 board");
            Assert.AreEqual(2, board.GetLength(1), "CreateCypherBoard: Sqrt(4) => 2 x 2 board");
            board = SquareCode.CreateCypherBoard(5);
            Assert.AreEqual(3, board.GetLength(0), "CreateCypherBoard: Sqrt(5) => 3 x 2 board");
            Assert.AreEqual(2, board.GetLength(1), "CreateCypherBoard: Sqrt(5) => 2 x 2 board");
            board = SquareCode.CreateCypherBoard(87);
            Assert.AreEqual(10, board.GetLength(0), "CreateCypherBoard: Sqrt(87) => 10 x 9 board");
            Assert.AreEqual(9, board.GetLength(1), "CreateCypherBoard: Sqrt(87) => 10 x 9 board");
        }

        [TestMethod()]
        public void T04_Encrypt_Decrypt()
        {
            string message = "abcde";
            char[,] board = SquareCode.CreateCypherBoard(message.Length);
            SquareCode.FillMessageIntoBoard(message, board);
            char[,] expectedBoard = {
                                    {'a', 'b'},
                                    {'c', 'd'},
                                    {'e', '\0'}};
            Assert.IsTrue(CompareBoards(board, expectedBoard), "FillMessageIntoBoard: abcde");
            Assert.AreEqual("ace bd ", SquareCode.EncryptMessage(board), "EncryptMessage: abcde -> ace bd ");
            Assert.AreEqual("abcde", SquareCode.DecryptMessage("ace bd "), "Decrypt: ace bd -> abcde");
        }

        bool CompareBoards(char[,] boardA, char[,] boardB)
        {
            if (boardA.GetLength(0) != boardB.GetLength(0)
                || boardA.GetLength(1) != boardB.GetLength(1))
            {
                return false;
            }
            for (int row = 0; row < boardA.GetLength(0); row++)
            {
                for (int col = 0; col < boardB.GetLength(1); col++)
                {
                    if (boardA[row, col] != boardB[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}