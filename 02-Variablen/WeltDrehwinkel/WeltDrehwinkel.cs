/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: xAHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Winkelberechnung Grad/Minuten/Sekunden der Erde
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Winkelberechnung Grad/Minuten/Sekunden");
Console.WriteLine("============");
Console.WriteLine();

Console.Write("Please enter amount of seconds:");
var totalSeconds = Convert.ToInt32(Console.ReadLine());

var angle     = totalSeconds / (24.0 * 60.0 * 60.0) * 360.0;
var fullAngle = (int)angle;

var minute     = (angle - fullAngle) * 60.0;
var fullMinute = (int)minute;

var seconds     = (minute - fullMinute) * 60;
var fullSeconds = (int)seconds;

Console.WriteLine($"In {totalSeconds} dreht sich die Erde um {fullAngle}° {fullMinute:00}\' {fullSeconds:00}\"");