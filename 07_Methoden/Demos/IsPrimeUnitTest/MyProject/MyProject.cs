/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MyTemplate
*--------------------------------------------------------------
*/

using System;

namespace MyProject
{
    public static class Program
    {
        public static void Main(string[] argv)
        {
            Console.WriteLine("Calculate prime numbers");
            Console.WriteLine("=======================");

            int count = 0;

            for (int i = 10; i <= 1000; i++)
            {
                if (IsPrime(i))
                {
                    if (count != 0)
                    {
                        Console.Write(",");
                    }
                    if (count != 0 && count % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write(i);
                    count++;
                }
            }
        }

        public static bool IsPrime(int number)
        {
            if (number == 0)
            {
                return false;
            }

            if (number < 0)
            {
                number = -number;
            }

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}