using System;
using System.Diagnostics;

namespace SortingNumbers
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Sorting Numbers");
            Console.WriteLine("===============");
            Console.WriteLine();

            // Create test data
            const int NUMBERS_COUNT = 5000;
            Random dice = new Random();          
            int[] numbers = new int[NUMBERS_COUNT];
            for (int i = 0; i < NUMBERS_COUNT; i++)
            {
                numbers[i] = dice.Next(1, NUMBERS_COUNT + 1);
            }
            Console.WriteLine("Original Table");
            for (int i = 0; i < NUMBERS_COUNT; i++)
            {
                Console.Write(numbers[i] + ", ");
            }
            Console.WriteLine("\b\b  ");
            Console.WriteLine();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            // Sort
            for (int left = 0; left < NUMBERS_COUNT - 1; left++)
            {
                for (int right = left + 1; right < NUMBERS_COUNT; right++)
                {
                    if (numbers[left] > numbers[right])
                    {
                        int temp = numbers[left];
                        numbers[left] = numbers[right];
                        numbers[right] = temp;
                    }
                }
            }
            timer.Stop();

            // Output
            Console.WriteLine("Sorted Table");
            for (int i = 0; i < NUMBERS_COUNT; i++)
            {
                Console.Write(numbers[i] + ", ");
            }
            Console.WriteLine("\b\b  ");
            
            Console.WriteLine("Elapsed ticks: " + timer.ElapsedTicks); 
            Console.WriteLine("Elapsed milliseconds: " + timer.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
