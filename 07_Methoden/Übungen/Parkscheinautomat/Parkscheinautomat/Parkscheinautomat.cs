/*----------------------------------------------------------
 *				HTL-Leonding / Klasse: 1AHD
 * ----------------------------------------------------------
 * Übung Nummer: 1. Test
 * Übungstitel:  Parkscheinautomat
 * Autoren:      Gerald Köck
 * Version:		 1.0
 * Datum:        5.12.09
 * ----------------------------------------------------------
*/
using System;

namespace Koeck
{
	/// <summary>
	/// Realisierung eines Parkscheinautomaten.
	/// </summary>
	class Parkscheinautomat
	{
		[STAThread]
		static void Main(string[] args)
		{
			const int MINDESTEINWURF = 50;
			const int MAXIMALEINWURF = 150;
			int summe = 0;
			int zeitMinuten = 0;
			bool ticketDrucken = false;
			int einwurf;
			string eingabe;
			int ueberZahlung;

			Console.WriteLine("Parkscheinautomat mit Mindestparkdauer 30 Min und Höchstparkdauer 1:30 Stunden");
			Console.WriteLine("Tarif pro Stunde: 1 Euro");
			Console.WriteLine("Zulässige Münzen: 5, 10, 20, 50, 100, 200 Cent");
			Console.WriteLine("Parkschein drucken mit d oder D");
			Console.WriteLine();
			do
			{
				Console.Write("Parkzeit bisher: {0,2:d}:{1,2:d}, d für Ticket, Einwurf in Cent: ", zeitMinuten/60, zeitMinuten%60);
				eingabe = Console.ReadLine();
				if (eingabe == "d" || eingabe == "D") // Ticket drucken
				{
					if (summe < MINDESTEINWURF) // Mindesteinwurf 50 Cent
					{
						Console.WriteLine("Mindesteinwurf 50 Cent, bisher haben Sie {0} Cent eingeworfen", summe);
					}
					else  // Parkzeit stimmt ==> Drucken ist möglich
					{
						ticketDrucken = true;
					}
				}
				else  // weiterer Einwurf
				{
					einwurf = Convert.ToInt32(eingabe);
					if (einwurf == 5 || einwurf ==  10 || einwurf == 20 || einwurf == 50 || einwurf == 100 || einwurf == 200)
					{
						summe = summe + einwurf;
						zeitMinuten = summe / 5 * 3;  // 5 Cent entsprechen 3 Minuten ==> keine Gleitkommaberechnung notwendig
					}
					else
					{
						Console.WriteLine("Bitte geben sie gültige Münzen ein!");
					}
				}
			}
			while (summe < MAXIMALEINWURF && !ticketDrucken);  // Maximalparkzeit überschritten oder Drucken mit gültiger Parkzeit
			Console.WriteLine();
			Console.WriteLine("Ticket ausgeben");
			// Ausgabe mit Dankeschön für etwaige Spende
			if (summe > MAXIMALEINWURF) // Überzahlung der Maximalparkdauer
			{
				ueberZahlung = summe - MAXIMALEINWURF;
				Console.WriteLine("Danke für Ihre Spende von {0} Euro {1,2:d} Cent", ueberZahlung / 100, ueberZahlung % 100);
				summe = MAXIMALEINWURF; // Für Zeitberechnung gültigen Wert normieren
			}
			zeitMinuten = summe / 5 * 3;  // 5 Cent entsprechen 3 Minuten ==> keine Gleitkommaberechnung notwendig
			Console.WriteLine("Sie dürfen {0,2:d}:{1,2:d} Stunden parken", zeitMinuten/60, zeitMinuten%60);
			Console.WriteLine("Programm beenden mit Eingabetaste");
			Console.ReadLine();
		}
	}
}
