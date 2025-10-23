/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: MyTemplate
 *--------------------------------------------------------------
 */

using System;

namespace Prime;

static class Program
{
    static void Main()
    {
        Console.WriteLine("Calculate prime numbers");
        Console.WriteLine("=======================");

        int count = 0;

        for (int i = 0; i <= 1000; i++)
        {
            if (PrimeNumbers.IsPrime(i))
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
}