/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Ausgabe Visitenkarte
*--------------------------------------------------------------
*/

using System;

// Eingabe
Console.WriteLine("Visitenkarte");
Console.WriteLine("=====================================");
Console.WriteLine();

Console.Write("Bitte geben sie ihren Vornamen ein: ");
var vorname = Console.ReadLine();

Console.Write("Bitte geben sie ihren Nachnamen ein: ");
var nachname = Console.ReadLine();

// Ausgabe
Console.WriteLine("+-----------------+");
Console.WriteLine($"| {vorname,-15} |");
Console.WriteLine($"| {nachname,-15} |");
Console.WriteLine("+-----------------+");
