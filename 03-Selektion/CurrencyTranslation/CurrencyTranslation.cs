/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung HA
 *--------------------------------------------------------------
 * Description: Currencytranslator Euro => Dollar => Franken
 *--------------------------------------------------------------
*/

using System;

// Wechselkurse vom ... see internet
const double euroDollar  = 1.15;
const double euroFranken = 1.07;

// Umrechnung für die restlichen Partnerkurse
const double dollarEuro    = 1.0 / euroDollar;
const double dollarFranken = dollarEuro * euroFranken;
const double frankenEuro   = 1.0 / euroFranken;
const double frankenDollar = 1.0 / dollarFranken;
double       startAmount;

Console.WriteLine("Waehrungsrechner zwischen Euro, Dollar und Schweizer Franken");
Console.Write("Eingabe der Ausgangswaehrung (D=Dollar, E=Euro, F=Franken): ");
string startCurrency = Console.ReadLine();

Console.Write("Betrag: ");
string input = Console.ReadLine();
startAmount = double.Parse(input);

switch (startCurrency)
{
    case "D":
    case "d":
    {
        Console.WriteLine($"Euro:    {startAmount * dollarEuro:f2}");
        Console.WriteLine($"Franken: {startAmount * dollarFranken:f2}");
        break;
    }
    case "E":
    case "e":
    {
        Console.WriteLine($"Dollar:  {startAmount * euroDollar}");
        Console.WriteLine($"Franken: {startAmount * euroFranken}");
        break;
    }
    case "F":
    case "f":
    {
        Console.WriteLine($"Dollar: {startAmount * frankenDollar}");
        Console.WriteLine($"Euro:   {startAmount * frankenEuro}");
        break;
    }
    default:
    {
        Console.WriteLine($"Als Ausgangswaehrung bitte D, E oder F eingeben, nicht {startCurrency}!");
        break;
    }
}