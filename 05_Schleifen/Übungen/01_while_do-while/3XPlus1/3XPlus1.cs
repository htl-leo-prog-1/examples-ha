/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* f(x) = x / 2    => wenn gerade
* f(x) = 3x +1    => sonst
* Berechne die Iterationen bis 1 als Ergebnis berechnet wird
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Calculated 3x + 1");
Console.WriteLine("=================");
Console.WriteLine();

Console.Write("Please enter start value: ");
var val = Convert.ToInt32(Console.ReadLine());
var count = 0;
var maxValue = 0;

while (val > 1)
{
    if (val % 2 != 0)
    {
        Console.Write($"{val} * 3 + 1 =");
        val = 3 * val + 1;
    }
    else
    {
        Console.Write($"{val} / 2     =");
        val /= 2;
    }

    if (maxValue < val)
    {
        maxValue = val;
    }

    count++;
    Console.WriteLine($" {val}");
}

Console.WriteLine($"{count} iterations needed to reach 1.");
Console.WriteLine($"{maxValue} is the highest value.");
