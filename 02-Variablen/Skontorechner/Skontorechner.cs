/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung 
 *--------------------------------------------------------------
 * Description: Skontorechner. 
 *--------------------------------------------------------------
*/

using System;

// Eingabe
Console.WriteLine("Skontorechner - Eingabe:");
Console.WriteLine("========================");
Console.Write("- Rechnungsbetrag (Euro): ");
double amount = Convert.ToDouble(Console.ReadLine());
Console.Write("- Skonto (%):             ");
double discount = Convert.ToDouble(Console.ReadLine());
Console.Write("- Skontofrist (Tage):     ");
int discountLimit = Convert.ToInt32(Console.ReadLine());
Console.Write("- Zahlungsziel (Tage):    ");
int paymentLimit = Convert.ToInt32(Console.ReadLine());
Console.Write("- Bankzinsen (%):         ");
double interestRate = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("--------------------------");

double discountAmount = amount * discount / 100.0;
double interestAmount = amount * interestRate / 100.0 * (paymentLimit - discountLimit) / 365.0;

Console.WriteLine("Skontorechner - Ausgabe:");
Console.WriteLine("========================");
Console.WriteLine($"Bei Zahlung nach {discountLimit} Tagen wird ein Skonto von {discountAmount:f2} abgezogen und es ist ein Betrag von {amount - discountAmount:f2} zu bezahlen.");
Console.WriteLine($"Bei Zahlung nach {paymentLimit} Tagen entsteht ein Zinsvorteil von {interestAmount:f5} und die Gesamtbelastung wäre {amount - interestAmount:f2}.");