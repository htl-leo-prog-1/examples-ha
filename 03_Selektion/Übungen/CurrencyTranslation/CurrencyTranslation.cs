using System;

// Wechselkurse vom 26.9.05 http://www.monetenfuchs.de/wechselkurs.htm
const double euroDollar  = 1.3736;
const double euroFranken = 1.0824;
// Umrechnung für die restlichen Partnerkurse
const double dollarEuro    = 1.0 / euroDollar;
const double dollarFranken = dollarEuro * euroFranken;
const double frankenEuro   = 1.0 / euroFranken;
const double frankenDollar = 1.0 / dollarFranken;
string       input;
double       startAmount;

Console.WriteLine("Waehrungsrechner zwischen Euro, Dollar und Schweizer Franken");
Console.Write("Eingabe der Ausgangswaehrung (D=Dollar, E=Euro, F=Franken): ");
string startCurrency = Console.ReadLine();
Console.Write("Betrag: ");
input       = Console.ReadLine();
startAmount = Convert.ToDouble(input);

// Lösung mit switch
switch (startCurrency)
{
    case "D":
    case "d":
    {
        Console.WriteLine("Euro: {0:f2}",    startAmount * dollarEuro);
        Console.WriteLine("Franken: {0:f2}", startAmount * dollarFranken);
        break;
    }
    case "E":
    case "e":
    {
        Console.WriteLine("Dollar: " + startAmount * euroDollar);
        Console.WriteLine("Franken: " + startAmount * euroFranken);
        break;
    }
    case "F":
    case "f":
    {
        Console.WriteLine("Dollar: " + startAmount * frankenDollar);
        Console.WriteLine("Euro: " + startAmount * frankenEuro);
        break;
    }
    default:
    {
        Console.WriteLine("Als Ausgangswaehrung bitte D, E oder F eingeben, nicht " + startCurrency + "!");
        break;
    }
}
