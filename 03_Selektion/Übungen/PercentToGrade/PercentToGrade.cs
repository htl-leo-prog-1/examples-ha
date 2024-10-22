/*--------------------------------------------------------------
 *				HTBLA-Leonding / Klasse: 1BHIF 2015/2016
 *--------------------------------------------------------------
 * Übung: 02
 * Datei:			    PercentToGrade.cs
 * Autor:		        Max Mustermann
 * Erstellungsdatum:    07.10.2015
 *--------------------------------------------------------------
 * Beschreibung:
 *--------------------------------------------------------------
*/

using System;

string input;
double percent;
string result = "";

Console.WriteLine("Percent to Grade!");
Console.WriteLine("=================");
Console.Write("Bitte geben Sie die Prozente ein, die Sie erreicht haben: ");
input   = Console.ReadLine();
percent = double.Parse(input);

if (percent < 50.0)
{
    result = "Nicht Genügend";
}
else if (percent < 62.5)
{
    result = "Genügend";
}
else if (percent < 75.0)
{
    result = "Befriedigend";
}
else if (percent < 87.5)
{
    result = "Gut";
}
else if (percent <= 100.0)
{
    result = "Sehr Gut";
}

// Ausgabe
if (percent >= 0.0 && percent <= 100.0)
{
    Console.WriteLine($"{input} Prozent ergeben die Note {result}");
}
else
{
    Console.WriteLine($"Die Eingabe war {input} ungültig");
}