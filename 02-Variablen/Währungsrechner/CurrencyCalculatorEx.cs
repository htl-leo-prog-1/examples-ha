/*--------------------------------------------------------------
 *		 	 	 HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 * Exercise Number:  03
 * File:	 	 	 CurrencyCalculator.cs
 * Author(s):	 	 Birgit Schröder
 * Date:	    	 30.09.2014
 *--------------------------------------------------------------
 * Description:
 * A Currency Calculator for EUR <-> CHF <-> USD conversion, 
 * using constants and selections.
 *--------------------------------------------------------------
*/

using System;

const double EUR_TO_USD = 1.2600;
const double EUR_TO_CHF = 1.2064;

double eurAmount = 0.0;
double usdAmount = 0.0;
double chfAmount = 0.0;

Console.WriteLine("Währung? [E = EUR | F = CHF | D = USD] ");
string baseCurrency = Console.ReadLine();
Console.WriteLine("Betrag? ");
string inputAmount = Console.ReadLine();

switch (baseCurrency)
{
    case "E":
        eurAmount = Convert.ToDouble(inputAmount);
        usdAmount = eurAmount * EUR_TO_USD;
        chfAmount = eurAmount * EUR_TO_CHF;
        break;
    case "F":
        chfAmount = Convert.ToDouble(inputAmount);
        eurAmount = chfAmount / EUR_TO_CHF;
        usdAmount = eurAmount * EUR_TO_USD;
        break;
    case "D":
        usdAmount = Convert.ToDouble(inputAmount);
        eurAmount = usdAmount / EUR_TO_USD;
        chfAmount = eurAmount * EUR_TO_CHF;
        break;
    default:
        break;
}

if (eurAmount > 0.0)
{
    Console.WriteLine("Umrechungsergebnis:");
    Console.WriteLine("===================");
    Console.WriteLine($"-  EUR: {eurAmount:0.00}");
    Console.WriteLine($"-  USD: {usdAmount:0.00}");
    Console.WriteLine($"-  CHF: {chfAmount:0.00}");
}
else
{
    Console.WriteLine("Ungültige Eingabe.");
}