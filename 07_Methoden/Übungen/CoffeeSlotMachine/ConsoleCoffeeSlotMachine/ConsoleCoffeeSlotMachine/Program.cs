using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCoffeeSlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coinValue = { 5, 10, 20, 50, 100, 200 };  // Wert der jeweiligen Münze
            int[] coinsAmount = { 3, 3, 3, 3, 3, 3 }; // Initialisierung für Münzen von 5 - 200 Cent
            int coinIndex;
            int sum;
            int returnCents;
            int countOfCoins;
            int thrownValue;
            string input;

            Console.WriteLine("Kaffeeautomat mit Geldrückgabe");
            // Bis der Benutzer abbricht
            do																					///! 1
			{
                Console.WriteLine();
                Console.WriteLine("Preis 50 Cent; Einwurf von 5, 10, 20, 50, 100, 200 Cent");
                // Münzeinwurf für Kaffee entgegen nehmen
                sum = 0; // Einwurf beginnt wieder von vorne									///! 2
                do																				///! 3
				{
                    Console.Write("Bisher eingeworfen {0}, Einwurf in Cent: ", sum);
                    input = Console.ReadLine();
                    thrownValue = Convert.ToInt32(input);											///! 4
					if (thrownValue == 5 || thrownValue == 10 || thrownValue == 20 || thrownValue == 50 || thrownValue == 100 || thrownValue == 200)
                    {                                                                           ///! 5
                        // Zugehörigen Index im Münzarray suchen
                        for (coinIndex = 0; thrownValue != coinValue[coinIndex]; coinIndex++)		///! 6
						{
                            // leerer Schleifenkörper, da nur gesucht wurde
                        }
                        coinsAmount[coinIndex]++; // Münzen entsprechend hochzählen			///! 7
                        sum = sum + thrownValue;												///! 8
					}
                    else
                    {
                        Console.WriteLine("Bitte geben sie gültige Münzen ein!");
                    }
                }
                while (sum < 50);
                // Einwurf ist beendet jetzt kommt es zum Retourgeld
                // testweise Münzdepot ausgeben
                //				Console.WriteLine();
                //				Console.WriteLine("Testausgabe des Münzdepots!");
                //				for (muenzIndex = 0; muenzIndex < 6; muenzIndex++)
                //				{
                //					Console.WriteLine("Münze: {0}, Menge: {1}", muenzWert[muenzIndex], muenzAnzahl[muenzIndex]);
                //				}
                Console.WriteLine();
                returnCents = sum - 50;															///! 9
				Console.WriteLine("Kaffeeausgabe, Einwurf: {0} ==> Retourgeld: {1} Cent", sum, returnCents);
                Console.WriteLine();
                // Rückgabe des Wechselgeldes
                // Beginnend bei 100 Cent bis hinunter zu 5 Cent maximal mögliche Anzahl ausgeben
                for (coinIndex = 4; returnCents > 0 && coinIndex >= 0; coinIndex--)				///! 10
				{
                    // Münzen herausgeben, solange noch Münze vorhanden und Retourgeld höher als der Münzwert ist
                    countOfCoins = Math.Min(returnCents / coinValue[coinIndex], coinsAmount[coinIndex]);	///! 11
					coinsAmount[coinIndex] -= countOfCoins;  // Münze entnehmen				///! 12
                    returnCents -= coinValue[coinIndex] * countOfCoins;							///! 13
					if (countOfCoins > 0)														///! 14
					{
                        Console.WriteLine("{0} von {1} {2} Cent-Münzen zurückgeben, restliches Retourgeld: {3}", countOfCoins, coinsAmount[coinIndex] + countOfCoins, coinValue[coinIndex], returnCents);
                    }
                }
                if (returnCents > 0) // Münzen sind ausgegangen									///! 15
                {
                    Console.WriteLine("Retourgeld von {0} Cent ist im Automaten nicht mehr verfügbar, sorry!", returnCents);
                }
                // nächste Runde
                Console.WriteLine();
                Console.Write("Für Verlassen X oder x drücken, sonst beliebige Taste: ");
                input = Console.ReadLine();
            }
            while (input != "x" && input != "X");
        }
    }
}

