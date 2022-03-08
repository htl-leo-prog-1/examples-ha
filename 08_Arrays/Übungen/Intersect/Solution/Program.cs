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
            int[] numbersA = { 1, 3, 5, 7, 9 };
            int[] numbersB = { 0, 1, 2, 3 };

            Console.WriteLine("Ziffern Und");
            Console.WriteLine("===========");

            PrintArray("Feld A: ", numbersA);
            PrintArray("Feld B: ", numbersB);

            var result = Intersect(numbersA, numbersB);
            Console.WriteLine($"Ergebnis enthält {result.Length} Ziffern");
            PrintArray("Ziffern in Feld A und Feld B: ",result);
  }

        private static int[] Intersect(int[] numbersA, int[] numbersB)
        {
            var isInBoth = new bool[Math.Max(numbersA.Length,numbersB.Length)];

            for (int i = 0; i < numbersA.Length; i++)
            {
                for (int j = 0; j < numbersB.Length; j++)
                {
                    if (numbersA[i] == numbersB[j])
                    {
                        isInBoth[numbersA[i]] = true;
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < isInBoth.Length; i++)
            {
                if (isInBoth[i])
                {
                    count++;
                }
            }

            int index=0;
            var result = new int[count];
            for (int i = 0; i < isInBoth.Length; i++)
            {
                if (isInBoth[i])
                {
                    result[index] = i;
                    index++;
                }
            }

            return result;
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
