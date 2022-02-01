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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verschlüsselt einen Text durch Verschieben im ASCII-Code um (key) Stellen
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string text, int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wandelt eine Binärzahl ins Dezimalsystem um. 
        /// Wenn es sich um keine gültige Binärzahl handelt, wird -1 geliefert.
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public static int BinaryToDecimal(string binary)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Im Ergebnisstring darf jedes Zeichen des übergebenen Textes nur genau einmal vorkommen.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetUniqueCharacters(string text)
        {
            throw new NotImplementedException();
        }

    }
}
