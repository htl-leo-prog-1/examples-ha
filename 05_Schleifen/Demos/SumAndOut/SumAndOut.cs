/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Summe der Zahlen bis ein bestimmter Wert erreicht wurde.
* Die Berechnung wird auf der Konsole in der Form 1+2+3+4 ausgegeben.
*--------------------------------------------------------------
*/

using System;

Console.Write("Please enter number [0.int.Max): ");
var minNo = Convert.ToInt32(Console.ReadLine());

var sum = 0;
var inc = 1;

while (sum < minNo)
{
    if (inc == 1)
    {
        Console.Write($"{inc}");
    }
    else
    {
        Console.Write($"+{inc}");
    }

    sum += inc;
    inc++;
}