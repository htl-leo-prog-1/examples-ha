/*----------------------------------------------------------
 *				HTL-Leonding / Klasse: 1CHD
 * ----------------------------------------------------------
 * Übung Nummer: 6
 * Übungstitel:  Geschwindigkeit
 * Autoren:      Gerald Köck
 * Version:		 1.0
 * Datum:        10.11.08
 * ----------------------------------------------------------
 * Änderungen:
 * - keine
 * 
 * ----------------------------------------------------------
 * Beschreibung der grundlegenden Lösungsidee:
 * Ausgehend von der Startgeschwindigkeit die aktuelle Geschwindigkeit
 * mit der Bescheunigung ermitteln. Alle halbe Stunde wird 
 * die noch verbleibende Reststrecke ermittelt. Wenn
 * die aktuelle Geschwindigkeit ausreicht, um in der
 * nächsten halben Stunde das Ziel zu erreichen, wird die
 * Schleife verlassen und die erforderliche Restzeit ermittelt.
 * 
* ----------------------------------------------------------
*/
using System;

namespace Koeck
{
	class Geschwindigkeit
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		static void Main(string[] args)
		{
			const double intervall = 0.5;
			int startGeschwindigkeit;
			int geschwindigkeitsZuwachs;
			int entfernung;
			double restStrecke;
			int geschwindigkeit;
			double zeit = 0.0;
			int stunden;
			double minuten;
			// Eingabe
			Console.WriteLine("Ziel mit steigender Geschwindigkeit ansteuern");
			Console.Write("Startgeschwindigkeit: ");
			startGeschwindigkeit = Convert.ToInt32(Console.ReadLine());
			Console.Write("GeschwindigkeitsZuwachs: ");
			geschwindigkeitsZuwachs = Convert.ToInt32(Console.ReadLine());
			Console.Write("Entfernung: ");
			entfernung = Convert.ToInt32(Console.ReadLine());
			// Verarbeitung
			restStrecke = entfernung;
			geschwindigkeit = startGeschwindigkeit;
			// Strecken, die mit aktueller Geschwindigkeit gefahren werden
			// aufsummieren bisZiel überschritten würde
			while (geschwindigkeit * intervall < restStrecke) // Dieses Intervall muss noch voll gefahren werden
			{
				restStrecke -= geschwindigkeit * intervall; // restliche Strecke in aktueller Geschwindigkeit reduzieren
				zeit += intervall; // gefahrene Zeit aufsummieren
				geschwindigkeit += geschwindigkeitsZuwachs;
			}
			// aus verbleibender Strecke Zeit ermitteln und zur bisher angefallenen Zeit addieren
			zeit += restStrecke /geschwindigkeit;
			stunden = Convert.ToInt32(Math.Floor(zeit));
			minuten = (zeit-stunden)*60;
			Console.WriteLine("Fahrzeit: {0} Stunden und {1:f2} Minuten",stunden,minuten);
			Console.Write("Weiter mit Enter!");
			Console.ReadLine();
		}
	}
}
