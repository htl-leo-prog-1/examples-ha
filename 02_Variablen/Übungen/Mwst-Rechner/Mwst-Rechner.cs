using System;

namespace Mwst
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definitionen
            string eingabe;
            double brutto10;
            double brutto5;
            double mwst10;
            double mwst5;
            double netto;
            double ersparnis;
            // Eingabe
            Console.WriteLine("Steuerrechner auf Grundnahrungsmittel");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            Console.Write("Aktueller Verkaufspreis: ");
            eingabe = Console.ReadLine();
            // Verarbeitung
            brutto10 = Convert.ToDouble(eingabe);
            netto = brutto10 / 1.1;
            mwst10 = brutto10 - netto;
            mwst5 = mwst10 / 2;
            brutto5 = netto + mwst5;
            ersparnis = mwst10 - mwst5;
            // Ausgabe
            Console.WriteLine();
            Console.WriteLine("Nettopreis:                {0,20:f2}", netto);
            Console.WriteLine("Derzeitige Mehrwertsteuer: {0,20:f2}", mwst10);
            Console.WriteLine();
            Console.WriteLine("Werte bei 5% Steuer");
            Console.WriteLine("-------------------");
            Console.WriteLine("Mehrwertsteuer:            {0,20:f2}", mwst5);
            Console.WriteLine("Zukünftiger Verkaufspreis: {0,20:f2}", brutto5);
            Console.WriteLine("Ersparnis:                 {0,20:f2}", ersparnis);
            Console.WriteLine();
            Console.Write("Zum Beenden Eingabetaste drücken ...");
            Console.ReadLine();
        }
    }
}
