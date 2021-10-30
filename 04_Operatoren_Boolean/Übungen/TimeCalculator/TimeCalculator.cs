/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
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
    Console.WriteLine($"{totalSeconds} Sekunden sind {days} Tage {hours} Stunden {minutes} Minuten und {seconds} Sekunden");
}
else if (hours > 0)
{
    Console.WriteLine($"{totalSeconds} Sekunden sind {hours} Stunden {minutes} Minuten und {seconds} Sekunden");
}
else if (minutes > 0)
{
    Console.WriteLine($"{totalSeconds} Sekunden sind {minutes} Minuten und {seconds} Sekunden");
}
else
{
    Console.WriteLine($"{totalSeconds} Sekunden bleiben {seconds} Sekunden");
}