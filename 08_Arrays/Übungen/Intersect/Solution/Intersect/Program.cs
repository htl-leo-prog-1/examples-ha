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
            Console.WriteLine("Intersect");
            Console.WriteLine("===========");

            Console.WriteLine("Normalfall");
            TryIntersect(new[] {1, 1, 3, 5, 7, 9, 1, 3}, new int[] {0, 1, 2, 3});
            Console.WriteLine("===========");

            Console.WriteLine("Alle gleich");
            TryIntersect(new[] { 1, 1, 3, 5 }, new int[] { 1, 3, 3, 5 });
            Console.WriteLine("===========");

            Console.WriteLine("Keine Überschneidung");
            TryIntersect(new[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6, 8 });
            Console.WriteLine("===========");

        }

        private static void TryIntersect(int[] arA, int[] arB)
        {
            PrintArray("Feld A: ", arA);
            PrintArray("Feld B: ", arB);

            var result = IntersectTools.Intersect(arA, arB);
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