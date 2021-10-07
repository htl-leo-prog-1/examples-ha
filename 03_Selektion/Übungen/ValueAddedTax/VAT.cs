/*--------------------------------------------------------------
 *				HTBLA-Leonding / Klasse: 1BHIF 2015/2016
 *--------------------------------------------------------------
 * Übung: 02
 * Datei:			    ValueAddedTax.cs
 * Autor:		        Max Mustermann
 * Erstellungsdatum:    03.10.2015
 *--------------------------------------------------------------
 * Beschreibung:
 *--------------------------------------------------------------
*/

using System;

// Variablendefinitionen
double price;
double grossPrice13;
double grossPrice10;
double netPrice;
double riseInPrice;
string bOrN;
string userInput;
// Eingabe
Console.WriteLine("Steuervergleich 10% und 13%");
Console.WriteLine("===========================");
Console.WriteLine();
Console.Write("Betrag [double]: ");
userInput = Console.ReadLine();
price     = Convert.ToDouble(userInput);
Console.Write("Brutto- oder Nettopreis [bBnN]: ");
bOrN = Console.ReadLine();
// Verarbeitung
if (bOrN == "b" || bOrN == "B")
{
    grossPrice10 = price;
    netPrice     = grossPrice10 / 1.10;
}
else
{
    netPrice     = price;
    grossPrice10 = netPrice * 1.10;
}

grossPrice13 = netPrice * 1.13;
riseInPrice  = grossPrice13 - grossPrice10;
// Ausgabe
Console.WindowWidth = 110;
Console.WriteLine("Bei einem Nettopreis von {0:f2} erhöht sich der Bruttopreis von {1:f2} auf {2:f2}",
    netPrice, grossPrice10, grossPrice13);
Console.WriteLine("Das entspricht einer Preiserhöhung von {0:f2} Euros!", riseInPrice);