using System;

namespace LetterCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Buchstabenzähler");

            Console.Write("Eingabetext: ");
            string input = Console.ReadLine();
            int[] letterCounts = new int[26];
            for (int i = 0; i < input.Length; i++)
            {
                int letterIndex = Char.ToLower(input[i]) - 'a';
                if (letterIndex >= 0 && letterIndex <= 26)
                {
                    letterCounts[letterIndex]++;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < letterCounts.Length / 2; i++)
            {
                Console.Write($"{(char)(i + 'A')}: {letterCounts[i]}\t");
                Console.WriteLine($"{(char)(i + 13 + 'A')}: {letterCounts[i + 13]}\t");

            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
