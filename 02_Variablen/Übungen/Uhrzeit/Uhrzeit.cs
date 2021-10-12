/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Umrechnung Sekunden in das Format hh:mm:ss
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Uhrzeitumrechnung in 00:00:00");
Console.WriteLine("=============================");
Console.WriteLine();

Console.Write("Please enter amount of seconds [0..86399]:");
var input        = Console.ReadLine();
var totalSeconds = Convert.ToInt32(input);

if (totalSeconds < (24 * 60 * 60))
{
    // Ausgabeformat: hh:mm:ss

    var seconds      = totalSeconds % 60;
    var totalMinutes = totalSeconds / 60;
    var minutes      = totalMinutes % 60;
    var hours        = totalMinutes / 60;

    Console.WriteLine($"{hours:00}:{minutes:00}:{seconds:00}");
}
else
{
    Console.WriteLine($"Falsche Eingabe: {totalSeconds}");
}