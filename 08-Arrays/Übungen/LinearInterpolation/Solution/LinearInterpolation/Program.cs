/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: linear Interpolation
*--------------------------------------------------------------
*/

namespace LinearInterpolation
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linear Interpolation");
            Console.WriteLine("**********************");

            var pointCount = ReadNumber("Please enter the count of x / y points", 100, 1);
            var xValues = EnterArray(pointCount, "X-Values");
            var yValues = EnterArray(pointCount, "Y-Values");

            double x = ReadNumber("Please enter x to be converted (0 to exit)", Double.MaxValue, Double.MinValue);

            while (x != 0.0)
            {
                Console.WriteLine($"f({x}) = {LinearInterpolationTools.Calculate(x, xValues, yValues)}");
                x = ReadNumber("Please enter x to be converted (0 to exit)", Double.MaxValue, Double.MinValue);
            }
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

        private static double[] EnterArray(int count, string message)
        {
            var ar = new double[count];
            for (var i = 0; i < count; i++)
            {
                ar[i] = ReadNumber($"{message} {i + 1}. number", Double.MaxValue, Double.MinValue);
            }

            return ar;
        }
    }
}