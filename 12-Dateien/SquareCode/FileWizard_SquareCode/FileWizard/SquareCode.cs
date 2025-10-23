using System;

namespace FileWizard
{
    public class SquareCode
    {
        /// <summary>
        /// First, two separate strings are built: One string containing all characters
        /// from the message without any blanks, one string containing a '$' followed
        /// by the position of a specific blank in the original message.
        /// Finally, both strings are appended and returned as a single condensed string.
        /// </summary>
        /// <param name="message">Original message perhaps containing blanks</param>
        /// <returns>condensed string</returns>
        public static string Condense(string message)
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
        public static string Expand(string condensedMessage)
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
        public static char[,] CreateCypherBoard(int messageLength)
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


        /// <summary>
        /// A message is filled into the given 2-dimensional
        /// character array. Starting from left top, each line
        /// is filled one after each other.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cipherBoard"></param>
        public static void FillMessageIntoBoard(string message, char[,] cipherBoard)
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

        public static string Encrypt(string text)
        {
            string condensedMessage = Condense(text);
            char[,] cypherBoard = CreateCypherBoard(condensedMessage.Length);
            FillMessageIntoBoard(condensedMessage, cypherBoard);
            return  EncryptFromBoard(cypherBoard);
        }

        public static string Decrypt(string text)
        {
            string back = DecryptCondensed(text);
            return Expand(back);
        }

        public static string DecryptCondensed(string encryptedMessage)
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

        public static string EncryptFromBoard(char[,] cypherBoard)
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
