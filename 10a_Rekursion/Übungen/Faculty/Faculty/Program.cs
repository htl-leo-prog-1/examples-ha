using System;
using System.Diagnostics;

namespace Faculty
{
    class Program
    {
        static Stopwatch timer;

        static void Main(string[] args)
        {
            Console.WriteLine("Die Fakultät von {0} ist {1}.", 5, Factorial(5));
            Console.WriteLine("Die Fakultät von {0} ist {1}.", 0, Factorial(0));
            Console.WriteLine("Die Fakultät von {0} ist {1}.", 1, Factorial(1));

            timer = Stopwatch.StartNew();
            Console.WriteLine("Die Fakultät von {0} ist {1}.", 20, Factorial(20));
            Console.WriteLine("Ticks Rekursiv: " + timer.ElapsedTicks);

            timer = Stopwatch.StartNew();
            Console.WriteLine("Die Fakultät von {0} ist {1}.", 20, FactorialIteratively(20));
            timer.Stop();
            Console.WriteLine("Ticks Iterativ: " + timer.ElapsedTicks);
            Console.ReadKey();
        }

        static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static long FactorialIteratively(int n)
        {
            long factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
    }
}
