using System;
using System.Diagnostics;

namespace MultiplyRecursively
{
    class Program
    {
        static Stopwatch timer;

        static void Main(string[] args)
        {
            timer = Stopwatch.StartNew();
            Console.WriteLine("{0} * {1} = {2}", 200, 700, MultiplyIteratively(200, 700));
            timer.Stop();
            Console.WriteLine("Ticks Iteratively: " + timer.ElapsedTicks);

            timer = Stopwatch.StartNew(); 
            Console.WriteLine("{0} * {1} = {2}", 200, 700, Multiply(200, 700));
            timer.Stop();
            Console.WriteLine("Ticks Recursively: " + timer.ElapsedTicks);

            Console.ReadKey();
        }

        static long MultiplyIteratively(int a, int b)
        {
            return a * b;
        }

        static long Multiply(int a, int b)
        {
            if (a == 0)
            {
                return 0;
            }
            else
            {
                return b + Multiply(a - 1, b);
            }
        }
    }
}
