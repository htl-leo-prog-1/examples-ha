/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Berechnung der Fibunacci Zahlen
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Fibunacci");
Console.WriteLine("=================");
Console.WriteLine();

Console.Write("Please enter start value [1..], 0 for exit: ");
var startvalue = Convert.ToInt32(Console.ReadLine());

while (startvalue > 0)
{
    var last = 1;
    var preLast = 1;
    var fibunacci = preLast + last;

    while (fibunacci <= startvalue)
    {
        preLast = last;
        last = fibunacci;
        fibunacci = preLast + last;
    }

    Console.WriteLine($"Next fibonacci after {startvalue} => {fibunacci}");

    Console.Write("Please enter start value [1..], 0 for exit: ");
    startvalue = Convert.ToInt32(Console.ReadLine());
}