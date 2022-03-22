using System;
using System.IO;
using System.Text;

namespace BookLibrary
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Eine Taste drücken für Beenden.");
            Console.ReadKey();
        }


        /// <summary>
        /// Eine gültige ISBN-Nummer besteht aus den Ziffern 0, ... , 9,
        /// 'x' oder 'X' (nur an der letzten Stelle)
        /// Die Gesamtlänge der ISBN beträgt 10 Zeichen.
        /// Für die Ermittlung der Prüfsumme werden die Ziffern 
        /// von links nach rechts mit 1 - 10 multipliziert und die 
        /// Produkte aufsummiert. Ist das rechte Zeichen ein x oder X
        /// wird als Zahlenwert 10 verwendet.
        /// Die Prüfsumme muss modulo 11 0 ergeben.
        /// </summary>
        /// <returns>Prüfergebnis</returns>
        public static bool CheckIsbn(string isbn)
        {
            throw new NotImplementedException();
        }
    }
}
