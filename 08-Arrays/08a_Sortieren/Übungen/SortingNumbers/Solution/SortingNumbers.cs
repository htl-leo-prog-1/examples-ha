/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sorting Numbers
*--------------------------------------------------------------
*/

namespace SortingNumbers
{
    using System;

    class Program
    {
        const int NUMBERS_PERLINE = 20;

        public static void Main()
        {
            Console.WriteLine("Sorting Numbers");
            Console.WriteLine("===============");
            Console.WriteLine();

            Console.Write("Please enter array size: ");
            var arraySize = int.Parse(Console.ReadLine());

            var numbers = CreateRandom(arraySize);

            Console.WriteLine();
            Console.WriteLine("Original Table");
            Print(numbers, NUMBERS_PERLINE);

            var timer = new System.Diagnostics.Stopwatch();

            timer.Start();
            Sort(numbers);
            timer.Stop();

            Console.WriteLine();
            Console.WriteLine("Sorted Table");
            Print(numbers, NUMBERS_PERLINE);

            Console.WriteLine($"Elapsed ticks: {timer.ElapsedTicks}");
            Console.WriteLine($"Elapsed milliseconds: {timer.ElapsedMilliseconds}");
        }

        public static int[] CreateRandom(int arraySize)
        {
            var dice = new Random();
            var numbers = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                numbers[i] = dice.Next(1, arraySize + 1);
            }

            return numbers;
        }

        public static void Print(int[] numbers, int numbersPerLine)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(",");
                }

                if (i != 0 && i % numbersPerLine == 0)
                {
                    Console.WriteLine();
                }

                Console.Write(numbers[i]);
            }

            Console.WriteLine();
        }

        public static void Sort(int[] numbers)
        {
            for (int left = 0; left < numbers.Length - 1; left++)
            {
                for (int right = left + 1; right < numbers.Length; right++)
                {
                    if (numbers[left] > numbers[right])
                    {
                        int temp = numbers[left];
                        numbers[left] = numbers[right];
                        numbers[right] = temp;
                    }
                }
            }
        }
    }
}