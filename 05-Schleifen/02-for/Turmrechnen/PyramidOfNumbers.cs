/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: PyramidOfNumbers
*--------------------------------------------------------------
*/

using System;

ulong currentBase;

do
{
    bool isOk;

    do
    {
        Console.Write("Please enter a number [0..] (0 for exit): ");
        isOk = ulong.TryParse(Console.ReadLine(), out currentBase);
    } while (!isOk);

    if (currentBase != 0)
    {
        ulong lastResult = currentBase;
        for (ulong i = 2; i <= 10; i++)
        {
            currentBase = lastResult;
            lastResult  = currentBase * i;
            Console.WriteLine($"{currentBase} * {i} = {lastResult}");
        }

        for (ulong i = 2; i <= 10; i++)
        {
            currentBase = lastResult;
            lastResult  = currentBase / i;
            Console.WriteLine($"{currentBase} / {i} = {lastResult}");
        }
    }
} while (currentBase != 0);