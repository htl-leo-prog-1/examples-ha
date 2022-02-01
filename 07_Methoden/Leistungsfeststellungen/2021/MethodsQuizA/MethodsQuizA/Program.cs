using System;

namespace MethodsQuizA
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please run the unit tests!");
            Console.ReadKey();
        }

        /// <summary>
        /// Liefert einen string, der den gegebenen Character (length) mal enthält
        /// </summary>
        /// <param name="c"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string PrintCharacters(char c, int length)
        {
            string value = "";
            for (int i = 0; i < length; i++)
            {
                value += c;
            }
            return value;
        }

		/// <summary>
        /// Zählt wie oft das gegebene Zeichen im Text vorkommt.
        /// Groß-/Kleinschreibung ist dabei irrelevant.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountCharacters(char c, string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++) 
            {
                if (Char.ToLower(c) == Char.ToLower(text[i]))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Verschlüsselt einen Text durch Verschieben im ASCII-Code um (key) Stellen
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
		public static string Encrypt(string text, int key)
        {
            string encrypted = "";
            for (int i = 0; i < text.Length; i++) 
            {
                encrypted += (char)(text[i] + key);
            }
            return encrypted;
        }



        /// <summary>
        /// Wandelt eine Binärzahl ins Dezimalsystem um. 
        /// Wenn es sich um keine gültige Binärzahl handelt, wird -1 geliefert.
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
		public static int BinaryToDecimal(string binary)
        {
            int dec = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] < '0' || binary[i] > '1')
                {
                    return -1;
                }
                dec = dec * 2 + (binary[i] - '0');
            }
            return dec;
        }

        /// <summary>
        /// Im Ergebnisstring darf jedes Zeichen des übergebenen Textes nur genau einmal vorkommen.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
		public static string GetUniqueCharacters(string text)
        {
            string uniqueCharacters = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (!Contains(uniqueCharacters, text[i])){
                    uniqueCharacters += text[i];
                }
            }
            return uniqueCharacters;
        }

        private static bool Contains(string text, char c)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == c)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
