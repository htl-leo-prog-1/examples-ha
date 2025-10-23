using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Einladung
{
	public class Einladung
	{
        /// <summary>
        /// Gegeben ist die Anzahl der Sekunden. Sie haben die Aufgabe, daraus
        /// die resultierenden Stunden:Minuten:Sekunden zu ermitteln, wobei die
        /// Ausgabe als String erfolgt und Minuten und Sekunden jeweils zweistellig
        /// auszugeben sind. Ergeben sich keine Stunden, wird deren Ausgabe weggelassen.
        /// Gleiches gilt, falls das Ergebnis nicht einmal eine Minute erreicht.
        /// </summary>
        /// <param name="seconds">Gesamtsekunden 0 bis int.MaxValue</param>
        /// <returns></returns>
        public static string CalcTimeSpan(int seconds)
        {
            return "";
        }

		private static void Main(string[] args)
		{
			Console.WriteLine("Einladungsliste aus mehreren Detaillisten zusammenmischen");
			Console.WriteLine();
			Console.Write("Bitte Listennamen eingeben (leere Eingabe zum Beenden) ");
            //!
            Console.ReadLine();
		}

	}

}
