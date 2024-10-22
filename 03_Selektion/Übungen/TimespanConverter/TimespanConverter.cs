using System;

Console.WriteLine("Wandle Minuten in Wochen, Tage, Stunden und Minuten um");
Console.WriteLine("******************************************************");
Console.Write("Bitte geben Sie die Anzahl der Minuten ein: ");

int userMinutes = int.Parse(Console.ReadLine());
int workMinutes = userMinutes;

int weeks = workMinutes / (60 * 24 * 7);
workMinutes -= weeks * 60 * 24 * 7;

int days = workMinutes / (60 * 24);
workMinutes -= days * 60 * 24;

int hours   = workMinutes / 60;
int minutes = workMinutes % 60;

Console.Write($"{userMinutes} Minuten sind ");
if (weeks > 0)
{
    Console.Write("{weeks} Wochen, ");
}

if (days > 0)
{
    Console.Write($"{days} Tage, " );
}

if (hours > 0)
{
    Console.Write($"{hours} Stunden, ");
}

if (minutes > 0)
{
    Console.Write($"{minutes} Minuten.");
}

Console.WriteLine();