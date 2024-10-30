/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description:
 * TimeSpanConverter
 *--------------------------------------------------------------
 */

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

int hours = workMinutes / 60;
int minutes = workMinutes % 60;

string output = string.Empty;
string minutesStr = userMinutes > 1 ? "Minuten sind" : "Minute ist";

Console.Write($"{userMinutes} {minutesStr} ");

if (weeks > 0)
{
    if (output.Length > 0)
    {
        output += ", ";
    }

    output += $"{weeks} ";

    if (weeks == 1)
    {
        output += "Woche";
    }
    else
    {
        output += "Wochen";
    }
}

if (days > 0)
{
    if (output.Length > 0)
    {
        output += ", ";
    }

    output += $"{days} ";
    output += days == 1 ? "Tag" : "Tage";
}

if (hours > 0)
{
    if (output.Length > 0)
    {
        output += ", ";
    }

    output += $"{hours} ";
    output += hours == 1 ? "Stunde" : "Stunden";
}

if (minutes > 0)
{
    if (output.Length > 0)
    {
        output += ", ";
    }

    output += $"{minutes} ";
    output += minutes switch {1 => "Minute", _ => "Minuten"};
}

Console.WriteLine(output);