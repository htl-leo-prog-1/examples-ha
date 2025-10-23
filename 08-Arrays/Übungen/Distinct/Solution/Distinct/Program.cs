/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: (Array-)Distinct with UnitTests
*--------------------------------------------------------------
*/

namespace Distinct
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distinct");
            Console.WriteLine("**********************");

            var ar = EnterArray();

            Console.Write($"Input:      {ToString(ar)}");
            if (DistinctTools.IsDistinct(ar))
            {
                Console.WriteLine(" => The array is distinct");
            }
            else
            {
                Console.WriteLine(" => The array is NOT distinct");
            }

            Console.WriteLine($"Distinct:   {ToString(DistinctTools.Distinct(ar))}");
            Console.WriteLine($"Duplicates: {ToString(DistinctTools.Duplicate(ar))}");
        }

        private static int[] EnterArray()
        {
            Console.Write("Please enter the count of numbers: ");

            var countOfNumbers = int.Parse(Console.ReadLine());
            var intNumbers = new int[countOfNumbers];

            for (var i = 0; i < countOfNumbers; i++)
            {
                Console.Write($"Please enter {i + 1}. number: ");
                intNumbers[i] = int.Parse(Console.ReadLine());
            }

            return intNumbers;
        }

        static string ToString(int[] ar)
        {
            var result = string.Empty;
            foreach (var val in ar)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += ", ";
                }

                result += val;
            }

            return result;
        }
    }
}