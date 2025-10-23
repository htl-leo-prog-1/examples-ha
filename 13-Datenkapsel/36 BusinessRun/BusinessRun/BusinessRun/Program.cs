using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BussinessRun
{
    class Program
    {
        public struct Laeufer
        {
            public string nummer;
            public string name;
            public string Jahrgang;
            public string Nation;
            public string Team;
            public string Zeit;
            public double ZeitInSekunden;
        }

        static void Main(string[] args)
        {
            string fileName = "BusinessRun.csv";
            string[] zeile;
            Laeufer[] laeufer;
            string[] elemente;
            Laeufer tempLaeufer;

            Console.Write("*******************************************************");
            Console.WriteLine("\n* Bussines-Run - Die zuverlÀssige Software fÌr LÀufer *");
            Console.Write("* von Daniel Hofbauer                                 *");
            Console.Write("\n*******************************************************");

            zeile = File.ReadAllLines(fileName, Encoding.Default);

            laeufer = new Laeufer[zeile.Length];
            for (int i = 0; i < zeile.Length; i++)
            {
                elemente = zeile[i].Split(';');
                laeufer[i].nummer = elemente[0];
                laeufer[i].name = elemente[1];
                laeufer[i].Jahrgang = elemente[2];
                laeufer[i].Nation = elemente[3];
                laeufer[i].Team = elemente[4];
                laeufer[i].Zeit = elemente[6];
                laeufer[i].ZeitInSekunden = BerechneZeitInSekunden(laeufer[i].Zeit);
            }


            Console.Write("\nBeenden mit Eingabe...");
            Console.ReadLine();
        }

        /// <summary>
        /// Berechnet Zeit in Sekunden.
        /// </summary>
        /// <param name="Zeit"></param>
        /// <returns></returns>
        public static double BerechneZeitInSekunden(string Zeit)
        {
            double minuten = 0;
            double sekunden = 0;
            double sekundenGesamt = 0;
            string[] element;

            element = Zeit.Split(':');
            minuten = Convert.ToInt32(element[0]);
            sekunden = Convert.ToDouble(element[1]);

            sekundenGesamt = sekundenGesamt + minuten * 60;
            sekundenGesamt = sekundenGesamt + sekunden;

            return sekundenGesamt;
        }
    }
}
