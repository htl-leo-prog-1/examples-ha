using System;

Console.WriteLine("Wandle Minuten in Wochen, Tage, Stunden und Minuten um");
Console.WriteLine("******************************************************");
Console.Write("Bitte geben Sie die Anzahl der Minuten ein: ");

int userMinutes = Convert.ToInt32(Console.ReadLine());
int workMinutes = userMinutes;

int weeks = workMinutes / (60 * 24 * 7);
workMinutes -= weeks * 60 * 24 * 7;

int days = workMinutes / (60 * 24);
workMinutes -= days * 60 * 24;

int hours   = workMinutes / 60;
int minutes = workMinutes % 60;

Console.Write("{0} Minuten sind ", userMinutes);
if (weeks > 0)
    Console.Write("{0} Wochen, ", weeks);


if (days > 0)
    Console.Write("{0} Tage, ", days);

if (hours > 0)
    Console.Write("{0} Stunden, ", hours);

if (minutes > 0)
    Console.Write("{0} Minuten.", minutes);
Console.WriteLine();