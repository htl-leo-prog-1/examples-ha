//! Diagonale stimmt noch nicht ganz
//! Zählen
//! Methodennamen

using System;
using System.Windows.Forms;

namespace Spiele
{
    class Geometrie
    {

        /// <summary>
        /// Hauptprogramm für Zeichenprogramm
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int h = 0;
            int v = 0;
            int newZ = 0;
            int newS = 0;
            Console.WriteLine("Geometrie");
            Console.WriteLine("=========");
            Board.Init(20, 20, "Geometrie");
            frageZuS(ref h, ref v);
            if (h == v)
            {
                rundQuadrat(h, v, ref newZ, ref newS);
                diagonal1(newS, newZ, h, v);
                diagonal2(newS, newZ);
                rundQuadrat(h, v, ref newZ, ref newS);
                Freiraum(h, v);
            }

            //!

            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }
        private static void frageZuS(ref int horizontal, ref int vertikal)
        {
            Console.Write("Horizontal(Spalte) : ");
            horizontal = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vertikal(Zeile) : ");
            vertikal = Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// methode Umrundet die eingegebenen Felder
        /// </summary>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        /// <param name="newZ"></param>
        /// <param name="newS"></param>
        private static void rundQuadrat(int zeile, int spalte, ref int newZ, ref int newS)
        {
            int feldgroesse = 20;
            int difZ = 0;
            int difS = 0;
            difZ = feldgroesse - zeile;
            difS = feldgroesse - spalte;
            newZ = feldgroesse - difZ;
            newS = feldgroesse - difS;
            for (int z = 0; z < Board.GetLength(0); z++)
            {
                for (int s = 0; s < Board.GetLength(1); s++)
                {
                    if (z <= newZ && s > 0 && s <= newS)
                    {
                        if (s == 1)
                        {
                            Board.SetText(z, s, "*");
                        }
                        if (s == newS)
                        {
                            Board.SetText(z, s, "*");
                        }
                        if (s <= newS && z == newZ)
                        {
                            Board.SetText(z, s, "*");
                        }
                        if (z == 1 && s <= newS)
                        {
                            Board.SetText(z, s, "*");
                        }
                        for (int i = 0; i < Board.GetLength(0); i++)
                        {
                            for (int x = 0; x < Board.GetLength(1); x++)
                            {
                                if (i == 0 && z == 0)
                                {
                                    Board.SetText(i, x, "");
                                }
                            }
                        }


                    }

                }
            }
        }
        /// <summary>
        /// Methode erstell 1 diagonale
        /// </summary>
        /// <param name="newS"></param>
        /// <param name="newZ"></param>
        private static void diagonal1(int newS, int newZ, int horizontal, int vertikal)
        {
            for (int z = 0; z < horizontal; z++)
            {
                for (int s = 0; s < vertikal; s++)
                {
                    if (z <= newZ && s > 0 && s <= newS)
                    {
                        if (z == s)
                        {
                            Board.SetText(z++, s, "x");
                        }


                    }


                }
            }
        }
        /// <summary>
        /// erstellt 2 diagonale
        /// </summary>
        /// <param name="newS"></param>
        /// <param name="newZ"></param>
        private static void diagonal2(int newS, int newZ)
        {

            int s = (newZ - 1);
            int z = 2;

            while (s > 1 && z < newS)
            {
                Board.SetText(z, s, "x");
                s--;
                z++;
            }

        }
        /// <summary>
        /// Analysiert den Freiraum
        /// </summary>
        private static void Freiraum(int h, int v)
        {
            int Freiraum = 0;
            for (int z = 1; z < h; z++)
            {
                for (int s = 1; s < v; s++)
                {
                    if (Board.GetText(z, s) == "")
                    {
                        Freiraum++;
                        Board.SetText(z, s, "o");
                    }
                }
            }
            Console.Write("Freiraum" + Freiraum);
        }
    }
}
