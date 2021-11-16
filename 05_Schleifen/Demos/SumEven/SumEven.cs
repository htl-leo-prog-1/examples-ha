/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Summe der geraden Zahlen bis ein bestimmter Wert erreicht wurde.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Sum of even numbers");
Console.WriteLine("====================");
Console.WriteLine();

Console.Write("Please minimum value: [0..int.Max]: ");
var minValue = Convert.ToInt32(Console.ReadLine());

int sum        = 0;
int nextEvenNo = 2;

while (sum <= minValue)
{
    sum        += nextEvenNo;
    nextEvenNo += 2;
}

Console.WriteLine($"Next sum of even numbers after {minValue} : {sum}");