using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExamples
{
    class Program
    {
        static void Main()
        {
            string input;
            string text;
            int startIndex;
            string result;
            int length;
            Console.WriteLine("Extract lower case characters");
            Console.WriteLine("=============================");
            Console.Write("Text eingeben: ");
            text = Console.ReadLine();
            Console.Write("Startindex: ");
            input = Console.ReadLine();
            startIndex = Convert.ToInt32(input);
            Console.Write("Länge: ");
            input = Console.ReadLine();
            length = Convert.ToInt32(input);
            result = ExtractLowerCaseCharacters(text, startIndex, length);
            Console.WriteLine($"Der Ergebnistext lautet \"{result}\"");
            Console.WriteLine();
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        public static string ExtractLowerCaseCharacters(string text, int startPosition, int count)
        {
            string result = "";
            int position = startPosition;
            char ch;
            while (count > 0 && position < text.Length)
            {
                ch = text[position];
                if (ch >= 'a' && ch <= 'z')
                {
                    result += ch;
                    count--;
                }
                position++;
            }
            return result;
        }
    }
}
