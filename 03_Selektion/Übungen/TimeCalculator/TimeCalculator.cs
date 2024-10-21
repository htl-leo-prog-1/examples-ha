/*--------------------------------------------------------------
 *				HTBLA-Leonding / Klasse: 1BHIF 2015/2016
 *--------------------------------------------------------------
 * Übung: 02
 * Datei:			    TimeCalculator.cs
 * Autor:		        Max Mustermann
 * Erstellungsdatum:    07.10.2015
 *--------------------------------------------------------------
 * Beschreibung:
 * Das Programm ermittelt aus den eingegebenen Sekunden die
 * sich daraus ergebenden Tage, Stunden, Minuten und Sekunden.
 *--------------------------------------------------------------
*/

using System;

// Variablendefinitionen
int    totalSeconds;
int    seconds;
int    minutes;
int    hours;
int    days;
string userInput;

// Eingabe
Console.WriteLine("Umrechner von Sekunden in Tage, Stunden, Minuten und Sekunden");
Console.WriteLine("=============================================================");
Console.WriteLine();
Console.Write("Gesamtsekunden [int]: ");
userInput    = Console.ReadLine();
totalSeconds = int.Parse(userInput);

// Verarbeitung
minutes = totalSeconds / 60;
seconds = totalSeconds % 60;
hours   = minutes / 60;
minutes = minutes % 60;
days    = hours / 24;
hours   = hours % 24;

// Ausgabe
if (days > 0)
{
    Console.WriteLine($"{totalSeconds} Sekunden sind {days} Tage {hours} Stunden {minutes} Minuten und {seconds} Sekunden");
}
else if (hours > 0)
{
    Console.WriteLine($"{totalSeconds} Sekunden sind {days} Tage {hours} Stunden {minutes}");
}
else if (minutes > 0)
{
    Console.WriteLine($"{totalSeconds} Sekunden sind {minutes} Minuten und {seconds} Sekunden" );
}
else
{
    Console.WriteLine($"{totalSeconds} Sekunden bleiben {seconds}");
}
