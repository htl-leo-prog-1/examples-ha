using System;

namespace CountDifferentDigits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input;
            int number;
            var isDigitInArray = new bool[10];
            var digits = new int[10];
            var result = "";
            Console.WriteLine("Count different digits");
            Console.WriteLine("======================");
            // Eingabe
            for (var i = 0; i < digits.Length; i++)
            {
                Console.Write("{0}. Ziffer [0-9] eingeben: ", i + 1);
                input = Console.ReadLine();
                number = Convert.ToInt32(input);
                while (number < 0 || number > 9)
                {
                    Console.WriteLine("Fehleingabe, Ziffer muss zwischen 0 und 9 liegen!");
                    Console.Write("{0}. Ziffer [0-9] eingeben: ", i + 1);
                    input = Console.ReadLine();
                    number = Convert.ToInt32(input);
                }
                digits[i] = number;
            }
            // Testausgabe
            Console.Write("Eingegebene Ziffern im Array: ");
            for (var i = 0; i < digits.Length; i++)
            {
                Console.Write(digits[i]);
            }
            Console.WriteLine();
            // Verarbeitung
            for (var i = 0; i < digits.Length; i++)
            {
                isDigitInArray[digits[i]] = true;
            }
            // Ausgabe
            Console.Write("Eindeutige Ziffern im Array: ");
            for (var i = 0; i < isDigitInArray.Length; i++)
            {
                if (isDigitInArray[i])
                {
                    Console.Write(i);
                }
            }
            Console.WriteLine();
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}