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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public static string EncryptFromBoard(char[,] cypherBoard)
        {
            throw new NotImplementedException();
        }

        public static string Encrypt(string text)
        {
            throw new NotImplementedException();
        }

        public static string Decrypt(string text)
        {
            throw new NotImplementedException();
        }

        public static string DecryptCondensed(string encryptedMessage)
        {
            throw new NotImplementedException();
        }

 
    }

}
