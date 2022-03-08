using System;

namespace SqareCode
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            RunProgram();
            RunTests();

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
            Console.WriteLine("Cypher Matrix:");
            PrintCypherBoard(cypherBoard);
            Console.WriteLine();

            Console.Write("Encrypted Message: ");
            string code = EncryptMessage(cypherBoard);
            Console.WriteLine(code);
            Console.WriteLine();

            string back = DecryptMessage(code);
            Console.Write("Decrypted Message: ");
            Console.WriteLine(back);

            string original = AddBlanks(back);
            Console.Write("Blanks re-inserted: ");
            Console.WriteLine(original);
        }

        private static void RunTests()
        {
            Assert(RemoveBlanks("abc") == "abc", "RemoveBlanks: No blank");
            Assert(RemoveBlanks("abc de") == "abcde$3", "RemoveBlanks: 1 blank in the middle");
            Assert(RemoveBlanks("abcde ") == "abcde$5", "RemoveBlanks: 1 blank at the end");
            Assert(RemoveBlanks(" abc de ") == "abcde$0$4$7", "RemoveBlanks: 3 blanks anywhere");
            Assert(RemoveBlanks("1 2 3") == "123$1$3", "RemoveBlanks: 2 blanks between digits");

            Assert(AddBlanks("abcde$0$4$7") == " abc de ", "Add blanks again");
            Assert(AddBlanks("abcde") == "abcde", "Add blanks again");
            Assert(AddBlanks("abcde$0") == " abcde", "Add blanks again");
            Assert(AddBlanks("123$1$3") == "1 2 3", "Add blanks again");



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

            Assert(DecryptMessage("ace bd ") == "abcde", "Decrypt: ace bd -> abcde");
            
        }

        /// <summary>
        /// First, two separate strings are built: One string containing all characters
        /// from the message without any blanks, one string containing a '$' followed
        /// by the position of a specific blank in the original message.
        /// Finally, both strings are appended and returned as a single condensed string.
        /// </summary>
        /// <param name="message">Original message perhaps containing blanks</param>
        /// <returns>condensed string</returns>
        static string RemoveBlanks(string message)
        {
            string condensedMessage = "";
            string whiteSpacePositions = "";

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] != ' ')
                {
                    condensedMessage += message[i];
                }
                else
                {
                    whiteSpacePositions += "$" + i;
                }
            }
            return condensedMessage + whiteSpacePositions;
        }

        /// <summary>
        /// A condensed string, where all the blanks are listed
        /// at the end of the string as a sequence of '$' followed
        /// by the blank position in the original string, must be 
        /// converted back into the original message.
        /// </summary>
        /// <param name="condensedMessage"></param>
        /// <returns></returns>
        static string AddBlanks(string condensedMessage)
        {
            int indexOfFirstDollar = condensedMessage.IndexOf('$');
            if (indexOfFirstDollar < 0)
            {
                return condensedMessage;
            }
            string pureMessage = condensedMessage.Substring(0, indexOfFirstDollar);
            string dollarPart = condensedMessage.Substring(indexOfFirstDollar + 1);
            string[] blankPositions = dollarPart.Split('$');
            char[] finalMessage = new char[pureMessage.Length + blankPositions.Length];
            int posIndex = 0;
            int pureIndex = 0;
            for (int i = 0; i < finalMessage.Length; i++)
            {
                if (i != Convert.ToInt32(blankPositions[posIndex]))
                {
                    finalMessage[i] = pureMessage[pureIndex];
                    pureIndex++;
                }
                else
                {
                    finalMessage[i] = ' ';
                    if (posIndex < blankPositions.Length - 1)
                    {
                        posIndex++;
                    }
                }
            }
            return new string(finalMessage);
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
            int idealSideLength = (int)Math.Sqrt(messageLength);
            int cypherBoardLength = idealSideLength;
            int cypherBoardWidth = idealSideLength;
            if (cypherBoardLength * cypherBoardWidth < messageLength)
            {
                cypherBoardLength++;
                if (cypherBoardLength * idealSideLength < messageLength)
                    cypherBoardWidth++;
            }
            return new char[cypherBoardLength, cypherBoardWidth];
        }

        static bool CompareBoards(char[,] boardA, char[,] boardB)
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
        /// A message is filled into the given 2-dimensional
        /// character array. Starting from left top, each line
        /// is filled one after each other.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cipherBoard"></param>
        static void FillMessageIntoBoard(string message, char[,] cipherBoard)
        {
            int idx = 0;
            for (int i = 0; i < cipherBoard.GetLength(0); i++)
            {
                for (int j = 0; j < cipherBoard.GetLength(1); j++)
                {
                    if (idx < message.Length)
                        cipherBoard[i, j] = message[idx++];
                }
            }
        }

        static string DecryptMessage(string encryptedMessage)
        {
            string[] lines = encryptedMessage.Trim().Split(' ');
            int rows = lines.Length;
            int cols = lines[0].Length;
            string message = "";
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (col < lines[row].Length)
                        message += lines[row][col];
                }
            }
            return message;

        }

        static void PrintCypherBoard(char[,] cypherBoard)
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

        static string EncryptMessage(char[,] cypherBoard)
        {
            string code = "";
            for (int j = 0; j < cypherBoard.GetLength(1); j++)
            {
                for (int i = 0; i < cypherBoard.GetLength(0); i++)
                {
                    if (cypherBoard[i, j] != '\0')
                    {
                        code += cypherBoard[i, j];
                    }
                        
                }
                code += " ";
            }
            return code;
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
