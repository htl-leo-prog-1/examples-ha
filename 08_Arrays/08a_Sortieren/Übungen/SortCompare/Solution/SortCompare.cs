/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sorting Numbers
*--------------------------------------------------------------
*/

using System;
using System.Diagnostics;

namespace SortCompare
{
    class Program
    {
        enum SortingStrategy
        {
            BruteForce,
            BubbleSort,
            InsertionSort,
            SelectionSort
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Sorting Numbers");
            Console.WriteLine("===============");
            Console.WriteLine();

            Console.Write("Please enter array size: ");
            var arraySize = int.Parse(Console.ReadLine());


            var numbers = CreateRandom(arraySize);
            int[] numbersSorted;

            Console.WriteLine($"Ticks for sorting {arraySize} numbers: ");
            CallSort(SortingStrategy.BruteForce, numbers, out numbersSorted);
            CallSort(SortingStrategy.BubbleSort, numbers, out numbersSorted);
            CallSort(SortingStrategy.InsertionSort, numbers, out numbersSorted);
            CallSort(SortingStrategy.SelectionSort, numbers, out numbersSorted);

            Console.WriteLine($"Ticks for sorting already sorted {arraySize} numbers: ");
            CallSort(SortingStrategy.BruteForce, numbersSorted, out numbersSorted);
            CallSort(SortingStrategy.BubbleSort, numbersSorted, out numbersSorted);
            CallSort(SortingStrategy.InsertionSort, numbersSorted, out numbersSorted);
            CallSort(SortingStrategy.SelectionSort, numbersSorted, out numbersSorted);
        }

        static int[] CreateRandom(int arraySize)
        {
            var dice = new Random();
            var numbers = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                numbers[i] = dice.Next(1, arraySize + 1);
            }

            return numbers;
        }

        static void CallSort(SortingStrategy strategy, int[] numbersUnsorted, out int[] numbersSorted)
        {
            Console.WriteLine($"- {SortName(strategy)}:    {Sort(strategy, numbersUnsorted, out numbersSorted)}");
            
            if (!IsSorted(numbersSorted))
            {
                Console.WriteLine("FATAL: Not Sorted");
            }
        }

        static string SortName(SortingStrategy strategy)
        {
            switch (strategy)
            {
                default:
                case SortingStrategy.BruteForce: return "Brute Force:    ";
                case SortingStrategy.BubbleSort: return "Bubble Sort:    ";
                case SortingStrategy.InsertionSort: return "Insertion Sort: ";
                case SortingStrategy.SelectionSort: return "Selection Sort: ";
            }
        }

        static long Sort(SortingStrategy strategy, int[] numbersUnsorted, out int[] numbersSorted)
        {
            numbersSorted = new int[numbersUnsorted.Length];
            Array.Copy(numbersUnsorted, numbersSorted, numbersUnsorted.Length);

            var timer = Stopwatch.StartNew();
            switch (strategy)
            {
                case SortingStrategy.BruteForce:
                    Sorting.SortBruteForce(numbersSorted);
                    break;
                case (SortingStrategy.BubbleSort):
                    Sorting.BubbleSort(numbersSorted);
                    break;
                case (SortingStrategy.InsertionSort):
                    Sorting.InsertionSort(numbersSorted);
                    break;
                case (SortingStrategy.SelectionSort):
                    Sorting.SelectionSort(numbersSorted);
                    break;
                default: break;
            }

            timer.Stop();

            return timer.ElapsedTicks;
        }

        static bool IsSorted(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}