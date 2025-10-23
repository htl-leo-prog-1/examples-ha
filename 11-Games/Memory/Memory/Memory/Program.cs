using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Program
    {
        static int cols;  // static, damit nicht immer die gültigen Dimensionen mitgegeben werden müssen
        static int rows;  // wird nur einmal geändert, sonst nur gelesen!

        static void Main(string[] args)
        {
            int[] points = { 0, 0 };
            int playerNUmber = 0;
            int pairsCounter;
            string color;
            bool ok;
            int row1;
            int col1;
            int row2 = -1;
            int col2 = -1;
            string word;

            Console.WriteLine("Memory");
            Console.WriteLine("======");
            cols = ReadInt("Spieler 1, Spalten eingeben: ", 10);
            rows = ReadInt("Spieler 1, Zeilen eingeben: ", 10);
            Board.Init(rows, cols, "Memory");
            Console.Write("Spieler 2, bitte Wort eingeben: ");
            word = Console.ReadLine();
            char[,] allocation = new char[rows, cols];
            HideWordTwice(allocation, word);
            pairsCounter = word.Length;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Eingabe Spieler {0}, erste Position", playerNUmber + 1);
                ok = ReadPos(out row1, out col1);
                if (ok)
                {
                    Console.WriteLine("Eingabe Spieler {0}, zweite Position", playerNUmber + 1);
                    ok = ReadPos(out row2, out col2);
                }
                if (ok && (row1 != row2 || col1 != col2))  // beide Felder enthielten nicht erratene Zeichen
                {
                    if (allocation[row1, col1] == allocation[row2, col2])  // Erraten
                    {
                        if (playerNUmber == 0)
                        {
                            color = "Red";
                        }
                        else
                        {
                            color = "Green";
                        }
                        Board.SetText(row1, col1, allocation[row1, col1].ToString(), color);
                        Board.SetText(row2, col2, allocation[row2, col2].ToString(), color);
                        points[playerNUmber]++;
                    }
                    else
                    {
                        Board.SetText(row1, col1, allocation[row1, col1].ToString());
                        Board.SetText(row2, col2, allocation[row2, col2].ToString());
                        System.Threading.Thread.Sleep(1000);
                        Board.SetText(row1, col1, "?");
                        Board.SetText(row2, col2, "?");
                        // Anderer Spieler
                        playerNUmber = (playerNUmber + 1) % 2;
                    }

                }
                else  // Fehlerhafte Position
                {
                    Console.WriteLine("Spieler {0}, Position ist ungültig!", playerNUmber + 1);
                    playerNUmber = (playerNUmber + 1) % 2;
                }
            }
            while (points[0] + points[1] < pairsCounter);
            Console.WriteLine("Ergebnis");
            Console.WriteLine("Spieler 1: {0} Punkte", points[0]);
            Console.WriteLine("Spieler 2: {0} Punkte", points[1]);
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Einlesen einer Positionsangabe und überprüfen
        /// ob an dieser Position noch zu erratende Zeichen stehen.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>gibt es an der Position noch nicht erratene Zeichen</returns>
        static bool ReadPos(out int row, out int col)
        {
            row = ReadInt("Zeile ", rows - 1);
            col = ReadInt("Spalte ", cols - 1);
            return Board.GetText(row, col) == "?";
        }

        /// <summary>
        /// Verteile Wort zufällig auf das Spielfeld.
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="word"></param>
        static void HideWordTwice(char[,] allocation, string word)
        {
            Random random = new Random();
            string doppelWort = word + word;
            int zeile;
            int spalte;
            for (int i = 0; i < doppelWort.Length; i++)
            {
                do
                {
                    zeile = random.Next(rows);
                    spalte = random.Next(cols);
                }
                while (allocation[zeile, spalte] > 0);
                allocation[zeile, spalte] = doppelWort[i];
                Board.SetText(zeile, spalte, "?");
            }
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
            int number;
            int i;
            string input;
            do
            {
                Console.Write(text + " (0-{0}): ", maxNumber);
                input = Console.ReadLine();
                // Prüfen, ob alle Zeichen Ziffern darstellen
                i = 0;
                while (i < input.Length && char.IsNumber(input[i]))
                {
                    i++;
                }
                if (i == input.Length)  // alle Zeichen sind Ziffern
                {
                    number = Convert.ToInt32(input);
                }
                else  // fehlerhafte Zeichen eingegeben
                {
                    number = -1;
                }
            }
            while (number < 0 || number > maxNumber);
            return number;
        }

    }
}
