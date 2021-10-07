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
totalSeconds = Convert.ToInt32(userInput);
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
    Console.WriteLine("{0} Sekunden sind {1} Tage {2} Stunden {3} Minuten und {4} Sekunden",
        totalSeconds, days, hours, minutes, seconds);
}
else if (hours > 0)
{
    Console.WriteLine("{0} Sekunden sind {1} Stunden {2} Minuten und {3} Sekunden",
        totalSeconds, hours, minutes, seconds);
}
else if (minutes > 0)
{
    Console.WriteLine("{0} Sekunden sind {1} Minuten und {2} Sekunden",
        totalSeconds, minutes, seconds);
}
else
{
    Console.WriteLine("{0} Sekunden bleiben {1} Sekunden",
        totalSeconds, seconds);
}
