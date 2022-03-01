/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: FibonacciArray
*--------------------------------------------------------------
*/

namespace FibonacciArray
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci-Array");
            Console.WriteLine("**********************");

            Console.Write("Please max number (index): ");
            int maxIndex = int.Parse(Console.ReadLine());

            var numbers = CreateFibonacciArray(maxIndex);
            WriteArray(numbers);
        }

        public static int[] CreateFibonacciArray(int maxIndex)
        {
            int[] fibonacci = new int[maxIndex];

            fibonacci[0] = 1;
            fibonacci[1] = 1;

            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci;
        }

        public static void WriteArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Fibonacci: {numbers[i]}");
            }
        }
    }
}
