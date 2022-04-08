using System;

namespace FibonacciRecursion
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Fibonacci({0}): {1}", 0, Fibonacci(0));
            Console.WriteLine("Fibonacci({0}): {1}", 1, Fibonacci(1));
            Console.WriteLine("Fibonacci({0}): {1}", 2, Fibonacci(2));
            Console.WriteLine("Fibonacci({0}): {1}", 3, Fibonacci(3));
            Console.WriteLine("Fibonacci({0}): {1}", 6, Fibonacci(6)); 
            Console.WriteLine("Fibonacci({0}): {1}", 8, Fibonacci(8));
            Console.WriteLine("Fibonacci({0}): {1}", 10, Fibonacci(10));

            Console.ReadKey();
        }

        static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
