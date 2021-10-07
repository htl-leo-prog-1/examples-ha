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

double discountAmount = amount * discount / 100;
double interestAmount = amount * interestRate / 100 * (paymentLimit - discountLimit) / 365;

Console.WriteLine("Skontorechner - Ausgabe:");
Console.WriteLine("========================");
Console.WriteLine("Bei Zahlung nach {0} Tagen wird ein Skonto von {1:f2} abgezogen und es ist ein Betrag von {2:f2} zu bezahlen.",
    discountLimit, discountAmount, (amount - discountAmount));
Console.WriteLine("Bei Zahlung nach {0} Tagen entsteht ein Zinsvorteil von {1:f5} und die Gesamtbelastung wäre {2:f2}.",
    paymentLimit, interestAmount, (amount - interestAmount));