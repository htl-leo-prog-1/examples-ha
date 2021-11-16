/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Berechnet die Summe aller eingegebenen Werte.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Calculate sum");
Console.WriteLine("====================");
Console.WriteLine();

Console.Write("Please enter a number: [0..int.Max]: ");
var number = Convert.ToInt32(Console.ReadLine());

int sum = 0;

while (number != 0)
{
    sum += number;
    Console.Write("Please enter a number: [0..int.Max]: ");
    number = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine($"Next sum all entered numbers: {sum}");