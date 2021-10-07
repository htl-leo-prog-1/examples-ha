/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung 
 *--------------------------------------------------------------
 * Description: Umrechnung Celsius <=> Fahrenheit
 *--------------------------------------------------------------
*/

using System;

// Definitionen
string auswahl;
string eingabe;
double celsius;
double fahrenheit;
double vorgabeTemperatur;
// Eingabe
Console.WriteLine("Umrechnung Celsius <=> Fahrenheit");
Console.WriteLine("=================================");
Console.WriteLine();
Console.Write("Ausgangseinheit Celsius oder Fahrenheit [C/F]: ");
auswahl = Console.ReadLine();

if (auswahl == "C")
{
    Console.Write("Grade in Celsius: ");
}
else
{
    Console.Write("Grade in Fahrenheit: ");
}

eingabe           = Console.ReadLine();
vorgabeTemperatur = Convert.ToDouble(eingabe);

// Verarbeitung
if (auswahl == "C")
{
    celsius    = vorgabeTemperatur;
    fahrenheit = celsius * 9.0 / 5.0 + 32;
}
else
{
    fahrenheit = vorgabeTemperatur;
    celsius    = (fahrenheit - 32) * 5.0 / 9.0;
}

// Ausgabe
Console.WriteLine();
if (auswahl == "C")
{
    Console.WriteLine(celsius + " Grad Celsius entsprechen " + fahrenheit + " Grad Fahrenheit");
}
else
{
    Console.WriteLine(fahrenheit + " Grad Fahrenheit entsprechen " + celsius + " Grad Celsius");
}