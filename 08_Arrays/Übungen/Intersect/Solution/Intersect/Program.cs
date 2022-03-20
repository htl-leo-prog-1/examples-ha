/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Method for intersection between two arrays  
*--------------------------------------------------------------
*/

using System;

namespace Intersect
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersA = {1, 1, 3, 5, 7, 9, 1, 3};
            int[] numbersB = {0, 1, 2, 3};

            Console.WriteLine("Intersect");
            Console.WriteLine("===========");

            PrintArray("Feld A: ", numbersA);
            PrintArray("Feld B: ", numbersB);

            var result = IntersectTools.Intersect(numbersA, numbersB);
            Console.WriteLine($"Ergebnis enthält {result.Length} Ziffern");
            PrintArray("Ziffern in Feld A und Feld B: ", result);
        }

        private static void PrintArray(string message, int[] numbersA)
        {
            Console.Write(message);
            for (int i = 0; i < numbersA.Length; i++)
            {
                Console.Write($"{numbersA[i]} ");
            }

            Console.WriteLine();
        }
    }
}