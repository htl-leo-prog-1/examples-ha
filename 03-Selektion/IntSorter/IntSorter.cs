/*--------------------------------------------------------------
 *				HTBLA-Leonding / Klasse: 1BHIF 2015/2016
 *--------------------------------------------------------------
 * Übung: 02
 * Datei:			    IntSorter.cs
 * Autor:		        Max Mustermann
 * Erstellungsdatum:    07.10.2015
 *--------------------------------------------------------------
 * Beschreibung:
 * Sortiert drei eingegebene Ganzzahlen nach deren Wert unter Verwendung
 * nur einer Hilfsvariablen zum Tauschen.
 *--------------------------------------------------------------
*/

using System;

string input;
int    firstNumber;
int    secondNumber;
int    thirdNumber;
int    tempForSwap;
int    difference;
// Eingabe
Console.WriteLine("Einfacher Sorter für ganze Zahlen");
Console.WriteLine("==================================");
Console.WriteLine();
Console.Write("Erste Ganzzahl [int]: ");
input       = Console.ReadLine();
firstNumber = int.Parse(input);
Console.Write("Zweite Ganzzahl [int]: ");
input        = Console.ReadLine();
secondNumber = int.Parse(input);
Console.Write("Dritte Ganzzahl [int]: ");
input       = Console.ReadLine();
thirdNumber = int.Parse(input);
// Verarbeitung
if (secondNumber < firstNumber)
{
    tempForSwap  = secondNumber;
    secondNumber = firstNumber;
    firstNumber  = tempForSwap;
}

if (thirdNumber < secondNumber)
{
    tempForSwap  = thirdNumber;
    thirdNumber  = secondNumber;
    secondNumber = tempForSwap;
}

if (secondNumber < firstNumber)
{
    tempForSwap  = secondNumber;
    secondNumber = firstNumber;
    firstNumber  = tempForSwap;
}

difference = thirdNumber - firstNumber;
// Ausgabe
Console.WriteLine($"Zahlen in sortierter Reihenfolge: {firstNumber}, {secondNumber}, {thirdNumber}");
Console.WriteLine($"Die Differenz zwischen der kleinsten Zahl {firstNumber} und der größten Zahl {thirdNumber} beträgt {difference}");