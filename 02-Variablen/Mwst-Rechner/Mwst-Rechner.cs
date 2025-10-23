/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung 
 *--------------------------------------------------------------
 * Description: Mwst.Recher
 * Das Programm berechnet die Mehrwertsteuer (10 und 5%) einer Benutzereingabe. 
 *--------------------------------------------------------------
*/

using System;

string eingabe;
double brutto10;
double brutto5;
double mwst10;
double mwst5;
double netto;
double ersparnis;

// Eingabe
Console.WriteLine("Steuerrechner auf Grundnahrungsmittel");
Console.WriteLine("=====================================");
Console.WriteLine();
Console.Write("Aktueller Verkaufspreis: ");
eingabe = Console.ReadLine();

// Verarbeitung
brutto10  = double.Parse(eingabe);
netto     = brutto10 / 1.1;
mwst10    = brutto10 - netto;
mwst5     = mwst10 / 2.0;
brutto5   = netto + mwst5;
ersparnis = mwst10 - mwst5;

// Ausgabe
Console.WriteLine();
Console.WriteLine($"Nettopreis:                {netto,20:f2}");
Console.WriteLine($"Derzeitige Mehrwertsteuer: {mwst10,20:f2}");
Console.WriteLine();
Console.WriteLine("Werte bei 5% Steuer");
Console.WriteLine("-------------------");
Console.WriteLine($"Mehrwertsteuer:            {mwst5,20:f2}");
Console.WriteLine($"Zukünftiger Verkaufspreis: {brutto5,20:f2}");
Console.WriteLine($"Ersparnis:                 {ersparnis,20:f2}");