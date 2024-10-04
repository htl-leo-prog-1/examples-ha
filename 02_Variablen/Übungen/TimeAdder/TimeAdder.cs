/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung 
 *--------------------------------------------------------------
 * Description: TimeAdder, ein Programm zum Addieren von Uhrzeiten
 *--------------------------------------------------------------
*/

using System;

int    hours1;
int    hours2;
int    minutes1;
int    minutes2;

int totalHours;
int totalMinutes;

string input;

// Eingabe
Console.WriteLine("Einfacher Addierer für zwei Uhrzeiten");
Console.WriteLine("=====================================");
Console.WriteLine();

Console.Write("Stunden 1 [int]: ");
input   = Console.ReadLine();
hours1 = int.Parse(input);
Console.Write("Minuten 1 [int]: ");
input    = Console.ReadLine();
minutes1 = int.Parse(input);

Console.Write("Stunden 2 [int]: ");
input   = Console.ReadLine();
hours2 = int.Parse(input);
Console.Write("Minuten 2 [int]: ");
input    = Console.ReadLine();
minutes2 = int.Parse(input);

// Verarbeitung
totalMinutes = (minutes1 + minutes2) % 60;
totalHours   = (hours1 + hours2) + (minutes1 + minutes2) / 60;

// Ausgabe
Console.WriteLine();
Console.WriteLine($"  {hours1,4}:{minutes1:00}");
Console.WriteLine($"+ {hours2,4}:{minutes2:00}");
Console.WriteLine($"= {totalHours,4}:{totalMinutes:00}");