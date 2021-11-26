/*----------------------------------------------------------
 *                   HTL-Leonding / Klasse: 1xHD
 * ----------------------------------------------------------
 * Übungsnr.:	ML        
 * Übungstitel:	Dagobert  
 * Autoren:		Gerhard Gehrer
 * Version:		1.0
 * Datum:		16.11.2005
 * ----------------------------------------------------------
 * Änderungen:
 * 
 * 
 * ----------------------------------------------------------
 * Kurzbeschreibung:
 * 
 * StandardAnforderung
 *  Der Bankier Dagobert schätzt sein Vermögen auf 1 bis 2 Millionen 
 * Dukaten. Um sich die Zeit zu vertreiben, legt er seine Dukaten 
 * einmal in Quadrat- und einmal in Dreiecksform, wobei er jeweils 
 * alle Münzen verwendet, ohne eine übrig zu lassen. Wie viele Dukaten 
 * besitzt Dagobert? 
 * 
 * Anleitung: Der Computer muss die Folge der Dreieckszahlen und die 
 * der Quadratzahlen durchlaufen.
 * 
 * Anmerkung: 
 *  Quadratzahlen errechnen sich nach folgender Formel:   qz = n * n
 *  Dreieckszahlen errechnen sich nach folgender Formel:  dz = (n + 1) * n / 2
 * 
 * Idee:
 * In der Angabe steht, dass das Vermögen von Dagobert zwischen 1 und 
 * 2 Millionen Dukaten liegt. Ok, dann brauche ich auch nur diesen Bereich 
 * untersuchen und eine Zahl finden, wo die Quadratzahl gleich der Dreieckszahl 
 * ist.
 * Weiters ist an den Formeln zu erkennen, dass die Quadratzahlen schneller 
 * als die Dreieckszahlen ansteigen. 
 * 
 * Ich kontrolliere diese Vermutung für n = 10 und n = 100:
 * qz(10) = 10 * 10 = 100
 * dz(10) = (10 + 1) * 10 / 2 = 55
 * 
 * qz(100) = 100 * 100 = 10000
 * dz(100) = (100 + 1) * 100 / 2 = 5050
 * Diese Vermutung hat sich mit diesen Beispielen verteutlicht.
 * 
 * Ich beginne mit qn = 1000 (1000 * 1000 ist eine Million) und berechne die Quadratzahl. 
 * Ebenso initialisiere ich dn mit 1000 und berechne anschließend die Dreieckszahl (dn).
 * Ist die Dreieckszahl gleich der Quadratzahl, dann habe ich die Lösung gefunden -> Ausgabe.
 * Falls die Dreieckszahl kleiner als die Quadratzahl ist, dann erhöhe ich dn um 1 und 
 * bereche die beiden Zahlen wieder. Falls die Dreieckszahl größer als die Quadratzah ist, dann 
 * erhöhe ich die qn um 1. Das mache ich solange, bis die beiden Zahlen gleich sind oder 
 * der Bereich 2 Millionen überschritten worden ist.
 *    
 * ErweiterteAnforderung
 * - keine
* ----------------------------------------------------------
*/

using System;

namespace EinfInProg
{
	/// <summary>
	/// Zusammenfassung für DagobertApp.
	/// </summary>
	class Dagobert
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		static void Main(string[] args)
		{
			int qz, qn; 			// Quadratzahl
			int dz, dn;				// Dreieckszahl
			int result = 0;			// Ergebnis, wenn dz == qz
            int calcs = 0;

			// Ausgabe der Firmendaten
			System.Console.WriteLine("**************************************************");	
			System.Console.WriteLine("*  RätselKnack - Knackt jedes Geheimnis          *");	
			System.Console.WriteLine("**************************************************");	
			System.Console.WriteLine("");	
			System.Console.WriteLine("");
			System.Console.WriteLine("Dagoberts Vermögen liegt zwischen 1 und 2 Millionen Dukaten.");
			System.Console.WriteLine("Die Quadratzahl und Dreieckszahl sind in diesem Bereich gleich groß - mmmmh...");
			System.Console.WriteLine("");
			System.Console.WriteLine("");
			System.Console.WriteLine("");

            // Eingabe (E)
            qn = 1000;
            dn = qn;
			do
			{
                // Verarbeitung (V)
                calcs++;
				qz = qn * qn;
				dz = (dn + 1) * dn / 2;
                if (dz > qz)
                    qn = qn + 1;
                else if (dz < qz)
                    dn = dn + 1;
                else
                {
                	result = dz;
                	qn++;
                }

			} while (qz <= 2000000 || dz <= 2000000);

            // Ausgabe (A)
			if (result > 0)
			{
				System.Console.WriteLine("...in {0} Berechnungen habe ich das Rätsel gelöst!", calcs);
				System.Console.WriteLine("Dagoberts Vermögen beläuft sich in der Höhe von {0} Dukaten", result);
				System.Console.WriteLine("Das ist des Rätsels Lösung!");
			}
			else
			{
				System.Console.WriteLine("Leider habe ich keine Lösung gefunden!");
				System.Console.WriteLine("Das Rätsels ist mir doch etwas zu schwierig!");
			}
			System.Console.ReadLine();
		}
	}
}
