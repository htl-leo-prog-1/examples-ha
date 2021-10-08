/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung 
 *--------------------------------------------------------------
 * Description: Umrechnung Celsius nach Fahrenheit
 *--------------------------------------------------------------
*/

using System;

// Eingabe
Console.WriteLine("Umrechnung Celsius => Fahrenheit");
Console.WriteLine("================================");
Console.Write("Eingabe Grad Celsius: ");
double celsius = Convert.ToDouble(Console.ReadLine());

// Verarbeitung
double fahrenheit = celsius * 9.0 / 5.0 + 32;

// Ausgabe
Console.WriteLine();
Console.WriteLine("Umrechnungsergebnis:");
Console.WriteLine("--------------------");
Console.WriteLine($"Celsius:    {celsius,8:f1}");
Console.WriteLine($"Fahrenheit: {fahrenheit,8:f1}");