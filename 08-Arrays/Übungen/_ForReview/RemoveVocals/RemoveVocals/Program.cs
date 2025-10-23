using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveVocals
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            string result = "";
            Console.WriteLine("Vokale aus Text löschen");
            Console.WriteLine("=======================");
            Console.Write("Text: ");
            text = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (!(ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U' ||
                    ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u'))
                {
                    result += ch;
                }
            }
            Console.WriteLine($"Der Text \"{text}\" ohne Vokale {result} ist um {text.Length - result.Length} Zeichen kürzer!");
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
