using System;
using System.Collections.Generic;
using System.Text;

namespace Spiele
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            int minen;
            Console.WriteLine("MineSweeper");
            Console.WriteLine("===========");
            do
            {
                Console.Write("Größe des quadratischen Boards (minimal 2, maximal 10) eingeben: ");
                size = int.Parse(Console.ReadLine());
            } while (size < 2 || size > 10);
            Board.Init(size, size,"MineSweeper");
            do
            {
                Console.Write(string.Format("Anzahl Minen eingeben (>= 0, <= {0} ): ", size * size));
                minen = int.Parse(Console.ReadLine());
            } while (minen < 1 || minen > size * size);
            bool[,] minenFeld = VerteileMinen(minen, size);
            int anzahl = PlayGame(minenFeld);
            ShowMinen(minenFeld);
            Console.WriteLine("Anzahl gefundener minenfreier Zellen: {0}", anzahl);
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Der Spieler versucht im Minenfeld möglichst viele freie Plätze zu finden.
        /// </summary>
        /// <param name="minenFeld"></param>
        /// <returns>Anzahl von gefundenen freien Feldern</returns>
        private static int PlayGame(bool[,] minenFeld)
        {
            int zeile;
            int spalte;
            int anzahl = 0;
            int minen;
            do
            {
                Console.WriteLine("Minenfreie Position suchen");
                zeile = ReadInt("Zeile: ", minenFeld.GetLength(0)-1);
                spalte = ReadInt("Spalte: ", minenFeld.GetLength(1)-1);
                if (!minenFeld[zeile,spalte])
                {
                    minen = ZaehleMinenRundherum(minenFeld, zeile, spalte);
                    if (Board.GetText(zeile,spalte).Length == 0)  // damit ein bereits aufgedecktes Feld nicht doppelt gezählt wird
                    {
                        anzahl++;
                    }
                    Board.SetText(zeile, spalte, minen.ToString());
                }
            } while (!minenFeld[zeile,spalte]);
            return anzahl;
        }


        /// <summary>
        /// Alle Minen auf den Bildschirm ausgeben
        /// </summary>
        /// <param name="minenFeld"></param>
        static void ShowMinen(bool[,] minenFeld)
        {
            for (int i = 0; i < minenFeld.GetLength(0); i++)
            {
                for (int j = 0; j < minenFeld.GetLength(1); j++)
                {
                    if (minenFeld[i, j])
                    {
                        Board.SetText(i, j, "X", "Red");
                    }
                }

            }
        }

        /// <summary>
        /// Wieviele Minen befinden sich rund um die gegebene Position
        /// </summary>
        /// <param name="minenFeld">Versteckte Minen</param>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        /// <returns>Anzahl der Minen um die gesuchte Position</returns>
        static int ZaehleMinenRundherum(bool[,] minenFeld, int zeile, int spalte)
        {
            int anzahl = 0;
            int zeileVon = Math.Max(0, zeile - 1);
            int zeileBis = Math.Min(minenFeld.GetLength(0) - 1, zeile + 1);
            int spalteVon = Math.Max(0, spalte - 1);
            int spalteBis = Math.Min(minenFeld.GetLength(1) - 1, spalte +1);
            for (int z = zeileVon; z <= zeileBis; z++)
            {
                for (int s = spalteVon; s <= spalteBis; s++)
                {
                    if (minenFeld[z,s])
                    {
                        anzahl++;
                    }
                }
            }
            if (minenFeld[zeile,spalte])
            {
                anzahl--;
            }
            return anzahl;
        }

        /// <summary>
        /// Einlesen einer Posítionsangabe und überprüfen
        /// ob an dieser Position noch zu erratende Zeichen stehen.
        /// </summary>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        /// <returns>gibt es an der Position noch nicht erratene Zeichen</returns>
        static bool ReadPos(int zeilen, out int zeile, out int spalte)
        {
            zeile = ReadInt("Zeile ", zeilen - 1);
            spalte = ReadInt("Spalte ", zeilen - 1);
            return Board.GetText(zeile, spalte) == "?";
        }

        /// <summary>
        /// Zählt die Anzahl der Minen im quadratischen Minenfeld
        /// </summary>
        /// <param name="minenFeld"></param>
        /// <returns>Anzahl der Minen</returns>
        static int ZaehleMinenImFeld(bool[,] minenFeld)
        {
            int anzahl = 0;
            for (int i = 0; i < minenFeld.GetLength(0); i++)
            {
                for (int j = 0; j < minenFeld.GetLength(1); j++)
                {
                    if (minenFeld[i,j])
                    {
                        anzahl++;
                    }
                }
                
            }
            return anzahl;
        }

        /// <summary>
        /// Verteile Minen zufällig auf das Spielfeld. Auf einer Position
        /// darf maximal eine Mine liegen
        /// </summary>
        /// <param name="anzahl">Anzahl der zu verteilenden Minen</param>
        /// <param name="zeilen">zeilen und Spalten des quadratischen Boards</param>
        /// <returns>Mit Minen belegtes Board oder null, falls nicht alle Minen Platz hatten</returns>
        static bool[,] VerteileMinen(int anzahl, int zeilen)
        {
            Random zufall = new Random();
            int zeile;
            int spalte;
            if (anzahl > (zeilen*zeilen))
            {
                return null;
            }
            bool[,] minenFeld = new bool[zeilen, zeilen];
            for (int i = 0; i < anzahl; i++)
            {
                do
                {
                    zeile = zufall.Next(zeilen);
                    spalte = zufall.Next(zeilen);
                }
                while (minenFeld[zeile, spalte]); // solange die Position bereits belegt ist
                minenFeld[zeile, spalte] = true;
            }
            return minenFeld;
        }


        /// <summary>
        /// Integerziffer wird von der Tastatur eingelesen.
        /// Dabei wird die maximale Zahl berücksichtig
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxNumber">maximale Zeilen/Spaltennummer</param>
        /// <returns></returns>
        static int ReadInt(string text, int maxNumber)
        {
            int zahl;
            int i;
            string eingabe;
            do
            {
                Console.Write(text + " (0-{0}): ", maxNumber);
                eingabe = Console.ReadLine();
                // Prüfen, ob alle Zeichen Ziffern darstellen
                i = 0;
                while (i < eingabe.Length && char.IsNumber(eingabe[i]))
                {
                    i++;
                }
                if (i == eingabe.Length)  // alle Zeichen sind Ziffern
                {
                    zahl = Convert.ToInt32(eingabe);
                }
                else  // fehlerhafte Zeichen eingegeben
                {
                    zahl = -1;
                }
            }
            while (zahl < 0 || zahl > maxNumber);
            return zahl;
        }


/*        
        /// <summary>
        /// Integerziffer wird von der Tastatur eingelesen.
        /// Dabei wird die maximale Zahl berücksichtig
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxNumber">maximale Zeilen/Spaltennummer</param>
        /// <returns></returns>
        static int ReadInt(string text, int maxNumber)
        {
            int zahl;
            int i;
            string eingabe;
            do
            {
                Console.Write(text + " (0-{0}): ", maxNumber);
                eingabe = Console.ReadLine();
                // Prüfen, ob alle Zeichen Ziffern darstellen
                i = 0;
                while (i < eingabe.Length && char.IsNumber(eingabe[i]))
                {
                    i++;
                }
                if (i == eingabe.Length)  // alle Zeichen sind Ziffern
                {
                    zahl = Convert.ToInt32(eingabe);
                }
                else  // fehlerhafte Zeichen eingegeben
                {
                    zahl = -1;
                }
            }
            while (zahl < 0 || zahl > maxNumber);
            return zahl;
        }
*/
    
    }
}
