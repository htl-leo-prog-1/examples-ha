/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Traveler Salesman problem
*--------------------------------------------------------------
*/

using System.Runtime.InteropServices;

namespace TravelerSalesman
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Traveler Salesman");
            Console.WriteLine("*****************");

            var pointCount = ReadNumber("Please enter the count of locations", 20, 1);

            var locations = new double[pointCount, 2];

            for (int i = 0; i < pointCount; i++)
            {
                locations[i, 0] = ReadNumber($"{i + 1}. X-Position", Double.MaxValue, Double.MinValue);
                locations[i, 1] = ReadNumber($"{i + 1}. Y-Position", Double.MaxValue, Double.MinValue);
            }

            double minDistance;
            var travel = TravelerSalesman.FindMinTravelSequence(locations, out minDistance);
            var distanceTable = TravelerSalesman.CreateDistanceTable(locations);

            Console.WriteLine($"shortest way to all destinations:");

            for (int i = 0; i < travel.Length - 1; i++)
            {
                PrintTravel(distanceTable, i + 1, travel[i], travel[i + 1]);
            }

            PrintTravel( distanceTable, travel.Length, travel[travel.Length - 1], travel[0]);
            Console.WriteLine($"Total: {minDistance}");
        }

        private static void PrintTravel(double[,] distanceTable, int idx, int fromIdx, int toIdx)
        {
            Console.WriteLine($"{idx}: from {fromIdx + 1} to {toIdx + 1} => {distanceTable[fromIdx, toIdx]}");
        }

        private static int ReadNumber(string message, int max, int min)
        {
            int number;
            bool isOk;
            do
            {
                Console.Write($"{message} [{min}..{max}]: ");
                isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
            } while (!isOk);

            return number;
        }

        private static double ReadNumber(string message, double max, double min)
        {
            double number;
            bool isOk;
            do
            {
                if (min == Double.MinValue && max == Double.MaxValue)
                {
                    Console.Write($"{message}: ");
                }
                else
                {
                    Console.Write($"{message} [{min}..{max}]: ");
                }

                isOk = double.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
            } while (!isOk);

            return number;
        }
    }
}