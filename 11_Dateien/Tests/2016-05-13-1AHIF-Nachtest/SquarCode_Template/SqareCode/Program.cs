/***********************************************************************************************
 * Assignment:     Square Code
 * Author:             
 * Class:          1AHIF
 * Date:           13.5.2016                              
 * ------------------------------------------------ 
 * Description:      
 * A program to encrypt a message by creating its square code.
 ***********************************************************************************************/
using System;

namespace SqareCode
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            RunTests(); 
            RunProgram();

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();            
        }

        private static void RunProgram()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("* Square Code Encryption *");
            Console.WriteLine("==========================");
            Console.WriteLine();
            Console.Write("Enter clear text: ");
            string message = Console.ReadLine();

            string condensedMessage = RemoveBlanks(message);
            Console.WriteLine("Condensed Text: " + condensedMessage);
            Console.WriteLine("Length of condensed text: " + condensedMessage.Length);
            Console.WriteLine();

            char[,] cypherBoard = CreateCypherBoard(condensedMessage.Length);
            FillMessageIntoBoard(condensedMessage, cypherBoard);
            Console.WriteLine("Cypher Board:");
            PrintCypherBoard(cypherBoard);
            Console.WriteLine();

            Console.Write("Encrypted Message: ");
            string code = EncryptMessage(cypherBoard);
            Console.WriteLine(code);
            Console.WriteLine();
        }

        private static void RunTests()
        {
            Assert(RemoveBlanks("abc") == "abc", "RemoveBlanks: No blank");
            Assert(RemoveBlanks("abc de") == "abcde", "RemoveBlanks: 1 blank in the middle");
            Assert(RemoveBlanks("abcde ") == "abcde", "RemoveBlanks: 1 blank at the end");
            Assert(RemoveBlanks(" abc de ") == "abcde", "RemoveBlanks: 3 blanks anywhere");
            Assert(RemoveBlanks("1 2 3") == "123", "RemoveBlanks: 2 blanks between digits");

            char[,] board = CreateCypherBoard(4);
            Assert(board.GetLength(0) == 2, "CreateCypherBoard: Sqrt(4) => 2 x 2 board");
            Assert(board.GetLength(1) == 2, "CreateCypherBoard: Sqrt(4) => 2 x 2 board");
            board = CreateCypherBoard(5);
            Assert(board.GetLength(0) == 3, "CreateCypherBoard: Sqrt(5) => 3 x 2 board");
            Assert(board.GetLength(1) == 2, "CreateCypherBoard: Sqrt(5) => 2 x 2 board");
            board = CreateCypherBoard(87);
            Assert(board.GetLength(0) == 10, "CreateCypherBoard: Sqrt(87) => 10 x 9 board");
            Assert(board.GetLength(1) == 9, "CreateCypherBoard: Sqrt(87) => 10 x 9 board");

            string message = "abcde";
            board = CreateCypherBoard(message.Length);
            FillMessageIntoBoard(message, board);
            char[,] expectedBoard = {
                                    {'a', 'b'},
                                    {'c', 'd'},
                                    {'e', '\0'}};
            Assert(CompareBoards(board, expectedBoard), "FillMessageIntoBoard: abcde");
            Assert(EncryptMessage(board) == "ace bd ", "EncryptMessage: abcde -> ace bd ");
            
        }

        /// <summary>
        /// A new string is returned, which only contains non-blank
        /// characters.
        /// </summary>
        /// <param name="message">Original message perhaps containing blanks</param>
        /// <returns>condensed string</returns>
        static string RemoveBlanks(string message)
        {
            return "";
        }

        /// <summary>
        /// This method creates an empty two-dimensional array of
        /// characters, which is big enough for the given amount
        /// of characters (messageLength).
        /// Take the square root of the size and set the resulting
        /// integer value as width and height of the matrix.
        /// If the square root is a floating point value with digits after
        /// the comma, the width and height is too small. In this
        /// case, the height of the array must be increased by one.
        /// </summary>
        /// <param name="messageLength"></param>
        /// <returns></returns>
        static char[,] CreateCypherBoard(int messageLength)
        {
            return new char[0,0];
        }

        /// <summary>
        /// A message is filled into the given 2-dimensional
        /// character array. Starting from left top, each line
        /// is filled one after each other.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cipherBoard"></param>
        static void FillMessageIntoBoard(string message, char[,] cipherBoard)
        {
        }

        /// <summary>
        /// This method reads the characters from a given
        /// cypher board vertically - one column after the other:
        /// For each column, all characters from all rows are
        /// collected into the resulting string.
        /// </summary>
        /// <param name="cypherBoard">Two-dimensional matrix containing characters</param>
        /// <returns>Encrypted text created vertically from the cypher board.</returns>
        static string EncryptMessage(char[,] cypherBoard)
        {
            string code = "";
            return code;
        }

        private static void PrintCypherBoard(char[,] cypherBoard)
        {
            for (int i = 0; i < cypherBoard.GetLength(0); i++)
            {
                for (int j = 0; j < cypherBoard.GetLength(1); j++)
                {
                    Console.Write(cypherBoard[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool CompareBoards(char[,] boardA, char[,] boardB)
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

        /// <summary>
        /// Assert the specified condition and reports message.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        /// <param name="message">Message.</param>
        private static void Assert(bool condition, string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            if (condition)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message + "... OK");
                passCount++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message + "... Fail");
                failCount++;
            }
            Console.ForegroundColor = originalColor;
        }

        private static void PrintSummary()
        {
            Console.WriteLine("Total number of " + (passCount + failCount) + " test cases");
            Console.WriteLine(passCount + " tests passed");
            Console.WriteLine(failCount + " tests failed");
        }
        private static int passCount;
        private static int failCount;
    }
}
