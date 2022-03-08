using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileWizard;
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
        public void T01_Condense_NoBlank()
        {
            Assert.AreEqual("abc", SquareCode.Condense("abc"), "No blank");
        }

        [TestMethod()]
        public void T02_Condense_OneBlank()
        {
            Assert.AreEqual("abcde$3", SquareCode.Condense("abc de"), "1 blank in the middle");
            Assert.AreEqual("abcde$5", SquareCode.Condense("abcde "), "1 blank at the end");
            Assert.AreEqual("abcde$0", SquareCode.Condense(" abcde"), "1 blank at the beginning");
        }

        [TestMethod()]
        public void T03_Condense_MoorBlanks()
        {
            Assert.AreEqual("abcde$0$4$7", SquareCode.Condense(" abc de "), "3 blanks anywhere");
            Assert.AreEqual("123$1$3", SquareCode.Condense("1 2 3"), "2 blanks between digits");
            Assert.AreEqual("$0$1$2$3", SquareCode.Condense("    "), "Nothing else than blanks");
        }

        [TestMethod()]
        public void T04_Expand_NoBlank()
        {
            Assert.AreEqual("abc", SquareCode.Expand("abc"), "No blank");
            Assert.AreEqual("abc de", SquareCode.Expand("abcde$3"), "1 blank in the middle");
            Assert.AreEqual("abcde ", SquareCode.Expand("abcde$5"), "1 blank at the end");
            Assert.AreEqual(" abc de ", SquareCode.Expand("abcde$0$4$7"), "3 blanks anywhere");
            Assert.AreEqual("1 2 3", SquareCode.Expand("123$1$3"), "2 blanks between digits");
        }

        [TestMethod()]
        public void T05_Expand_MoreBlanks()
        {
            Assert.AreEqual("abc de", SquareCode.Expand("abcde$3"), "1 blank in the middle");
            Assert.AreEqual("abcde ", SquareCode.Expand("abcde$5"), "1 blank at the end");
            Assert.AreEqual(" abc de ", SquareCode.Expand("abcde$0$4$7"), "3 blanks anywhere");
            Assert.AreEqual("1 2 3", SquareCode.Expand("123$1$3"), "2 blanks between digits");
            Assert.AreEqual("    ", SquareCode.Expand("$0$1$2$3"), "Nothing else than blanks");
        }


        [TestMethod()]
        public void T06_CreateCypherBoard()
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
        public void T07_FillMessageIntoBoard_NoBlanks()
        {
            string message = "abcde";
            char[,] board = SquareCode.CreateCypherBoard(message.Length);
            SquareCode.FillMessageIntoBoard(message, board);
            char[,] expectedBoard = {
                                    {'a', 'b'},
                                    {'c', 'd'},
                                    {'e', '\0'}};
            Assert.IsTrue(CompareBoards(board, expectedBoard), "FillMessageIntoBoard: abcde");
            Assert.AreEqual("ace bd ", SquareCode.EncryptFromBoard(board), "EncryptMessage: abcde -> ace bd ");
            Assert.AreEqual("abcde", SquareCode.DecryptCondensed("ace bd "), "Decrypt: ace bd -> abcde");
        }

        [TestMethod()]
        public void T08_FillMessageIntoBoard_TextWithBlanks()
        {
            string message = "It is easier for a rich man";
            string condensed = SquareCode.Condense(message);
            string expectedCondensed = "Itiseasierforarichman$2$5$12$16$18$23";
            Assert.AreEqual(expectedCondensed, condensed);
            char[,] board = SquareCode.CreateCypherBoard(condensed.Length);
            SquareCode.FillMessageIntoBoard(condensed, board);
            char[,] expectedBoard = {
                                    {'I', 't', 'i', 's', 'e', 'a'},
                                    {'s', 'i', 'e', 'r', 'f', 'o'},
                                    {'r', 'a', 'r', 'i', 'c', 'h'},
                                    {'m', 'a', 'n', '$', '2', '$'},
                                    {'5', '$', '1', '2', '$', '1'},
                                    {'6', '$', '1', '8', '$', '2'},
                                    {'3', '\0', '\0', '\0', '\0', '\0'}
            };
            Assert.IsTrue(CompareBoards(board, expectedBoard), "Cypherboards stimmen nicht überein");
            string expectedEncrypted = "Isrm563 tiaa$$ iern11 sri$28 efc2$$ aoh$12 ";
            string encrypted = SquareCode.EncryptFromBoard(board);
            Assert.AreEqual(expectedEncrypted, encrypted);
            Assert.AreEqual(expectedCondensed, SquareCode.DecryptCondensed(encrypted));
        }

        [TestMethod()]
        public void T09_Decrypt_From_Condensed()
        {
            Assert.AreEqual("abcde", SquareCode.DecryptCondensed("ace bd "), "Decrypt: ace bd -> abcde");
            string expectedCondensed = "Itiseasierforarichman$2$5$12$16$18$23";
            string encrypted = "Isrm563 tiaa$$ iern11 sri$28 efc2$$ aoh$12 ";
            Assert.AreEqual(expectedCondensed, SquareCode.DecryptCondensed(encrypted));
        }

        [TestMethod()]
        public void T10_Encrypt_Decrypt_ShortText()
        {
            string message = "abcde";
            string encrypted = SquareCode.Encrypt(message);
            Assert.AreEqual("ace bd ", encrypted);
            string decrypted = SquareCode.Decrypt(encrypted);
            Assert.AreEqual(message, decrypted);
            message =
                "It is easier for a rich man to pass through the eye of a needle " +
                " than it is for a camel to";
            encrypted = SquareCode.Encrypt(message);
            string expected = "Iooheit63$37 trpteso$05$5 iaahdf$1$16$ srselo283$47 eiseer$$55$9 actyta52$46$ shhehc$34$98 imroaa1$35$1 eaofnm22$67$ rnuaie$74$28 ftgntl1$76$7 ";
            Assert.AreEqual(expected, encrypted);
            decrypted = SquareCode.Decrypt(encrypted);
            Assert.AreEqual(message, decrypted);

        }

        [TestMethod()]
        public void T11_Encrypt_Decrypt_LongerText()
        {
            string message =
                "It is easier for a rich man to pass through the eye of a needle " +
                " than it is for a camel to";
            string encrypted = SquareCode.Encrypt(message);
            string expected = "Iooheit63$37 trpteso$05$5 iaahdf$1$16$ srselo283$47 eiseer$$55$9 actyta52$46$ shhehc$34$98 imroaa1$35$1 eaofnm22$67$ rnuaie$74$28 ftgntl1$76$7 ";
            Assert.AreEqual(expected, encrypted);
            string decrypted = SquareCode.Decrypt(encrypted);
            Assert.AreEqual(message, decrypted);

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