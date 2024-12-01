/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Berechnung der Fibonacci Zahlen
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Fibonacci");
Console.WriteLine("=================");
Console.WriteLine();

Console.Write("Please enter start value [1..], 0 for exit: ");
int startvalue = Convert.ToInt32(Console.ReadLine());

while (startvalue > 0)
{
    int last = 1;
    int preLast = 1;
    int fibonacci = preLast + last;

    while (fibonacci <= startvalue)
    {
        preLast = last;
        last = fibonacci;
        fibonacci = preLast + last;
    }

    Console.WriteLine($"Next fibonacci after {startvalue} => {fibonacci}");

    Console.Write("Please enter start value [1..], 0 for exit: ");
    startvalue = Convert.ToInt32(Console.ReadLine());
}