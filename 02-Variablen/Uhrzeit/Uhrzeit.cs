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
string input     = Console.ReadLine();
int totalSeconds = int.Parse(input);

// Ausgabeformat: hh:mm:ss

int seconds      = totalSeconds % 60;
int totalMinutes = totalSeconds / 60;
int minutes      = totalMinutes % 60;
int hours        = totalMinutes / 60;

Console.WriteLine($"{hours:00}:{minutes:00}:{seconds:00}");
