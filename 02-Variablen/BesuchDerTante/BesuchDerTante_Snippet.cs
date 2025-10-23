using System;

namespace Basics
{
    class Program
    {
        static void Main()
        {
            /**
			 * Beispiel, wie man dezimale Zeitangaben wie z.b. 2,115 Stunden
			 * in das Format hh:mm:ss umwandeln kann
			 * Ausgabe: 2:06:54
			 */

            double time = 2.115;

			// Wird ein double-Wert auf eine int-Variable zugewiesen,
			// ist ein expliziter cast-Operator notwendig. 
			// Denn bei dieser Zuweisung gehen natürlich die 
			// Nachkommastellen verloren!
			// In diesem Beispiel ist das aber genau das, was wir
			// brauchen, nämlich die ganzen Stunden ...
			int fullHours = (int)time;
			
			// Als nächstes werden die errechneten ganzen Stunden
			// von der time abgezogen, also 2.115 - 2
			// Ergebnis: 0.115. Das mal 60 ergibt die restlichen
			// Minuten, nämlich 6.9.
			double remainingMinutes = (time - fullHours) * 60;

			// In den verbliebenen 6.9 Minuten sind ganze 6
			// Minuten enthalten.
			int fullMinutes = (int)remainingMinutes;
			
 			// Jetzt holen wir uns noch die Sekunden aus dem Rest,
			// indem wir die errechneten ganzen Minuten abziehen
			// Also 6.9 - 6 ergibt 0.9, mal 60 ergibt 54.
			double remainingSeconds = (remainingMinutes - fullMinutes) * 60;
			
			/**
             * Fertig!
			 * Jetzt die Ausgabe
			 **/
			
			Console.WriteLine("Die Zeitdauer von {0} Stunden entspricht umgerechnet {1}:{2:00}:{3:00}", 
				time, fullHours, fullMinutes, remainingSeconds);

            Console.Write("Zum Beenden Eingabetaste drücken ...");
            Console.ReadLine();
        }
    }
}
