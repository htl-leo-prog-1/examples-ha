using System;

namespace CountDifferentDigits
{
    public class Program
    {
        private static void Main(string[] args)
        {
            int number;
            var digits = new int[10];
            Console.WriteLine("Count different digits");
            Console.WriteLine("======================");
            // Eingabe
            for (var i = 0; i < digits.Length; i++)
            {
                number = ReadIntegerFromConsole("1. Ziffer [0-9] eingeben: ");
                while (number < 0 || number > 9)
                {
                    Console.WriteLine("Fehleingabe, Ziffer muss zwischen 0 und 9 liegen!");
                    number = ReadIntegerFromConsole($"{i+1} Ziffer [0-9] eingeben: ");
                }
                digits[i] = number;
            }
            // Testausgabe
            WriteIntegerArray("Eingegebene Ziffern im Array: ",digits);
            // Verarbeitung
            string result = GetUniqueDigitsString(digits);
            Console.Write("Eindeutige Ziffern im Array: ");
            Console.WriteLine(result);
            Console.WriteLine();
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }


        /// <summary>
        /// Gibt einen  String zurück, der alle Ziffern aufsteigend 
        /// enthält, die im Ziffernarray vorkommen.
        /// Jede Ziffer ist im Ergebnisstring maximal einmal enthalten.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns>Ergebnisstring mit den enthaltenen Ziffren</returns>
        public static string GetUniqueDigitsString(int[] digits)
        {
            bool[] isDigitInArray = new bool[10];
            string result = "";
            for (var i = 0; i < digits.Length; i++)
            {
                isDigitInArray[digits[i]] = true;
            }
            for (var i = 0; i < isDigitInArray.Length; i++)
            {
                if (isDigitInArray[i])
                {
                    result += i;
                }
            }
            return result;
        }


        /// <summary>
        /// Gibt das Integerarray in einer Zeile aus
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="digits"></param>
        private static void WriteIntegerArray(string prompt, int[] digits)
        {
            Console.Write(prompt);
            for (var i = 0; i < digits.Length; i++)
            {
                Console.Write(digits[i]);
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Liest eine Ganzzahl von der Konsole ein
        /// </summary>
        /// <param name="commandPrompt"></param>
        /// <returns>Ganzzahl</returns>
        private static int ReadIntegerFromConsole(String commandPrompt)
        {
            Console.Write(commandPrompt);
            var input = Console.ReadLine();
            var number = Convert.ToInt32(input);
            return number;
        }
    }
}