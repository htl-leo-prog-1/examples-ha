using System;

namespace Spiele
{
    class Snake
    {
        static int spalten;
        static int zeilen;
        static int[,] spur;  // Positionen des Schlangenkörpers in Form eines zirkulären Arrays
        static int head;
        static int tail;

        /// <summary>
        /// Hauptprogramm für Snake
        /// Spielfeld anlegen und Spiel abwickeln
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Variablendeklaration
            int punkte;
            int spalte;
            int zeile;
            Console.WriteLine("Snake");
            Console.WriteLine("=====");
            // Spielfeld anlegen
            Console.Write("Zeilen: ");
            zeilen = int.Parse(Console.ReadLine());
            Console.Write("Spalten: ");
            spalten = int.Parse(Console.ReadLine());
            Board.Init(zeilen, spalten, "Snake");
            zeile = zeilen / 2;
            spalte = spalten / 2;
            spur = new int[zeilen * spalten, 2];
            head = 0;
            tail = 0;
            Board.SetText(zeile, spalte, "X");
            StoreSnakeHead(zeile, spalte);
            Console.WriteLine("Spiel starten mit einer Cursortaste!");
            punkte = PlayGame(zeile, spalte);
            Console.WriteLine("Sie haben " + punkte + " Punkte erreicht!");
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Das Spiel läuft so lange, bis die Schlange auf ihren
        /// eigenen Körper trifft.
        /// </summary>
        /// <param name="zeile">Startzeile</param>
        /// <param name="spalte">Startspalte</param>
        /// <returns>Punkteanzahl</returns>
        private static int PlayGame(int zeile, int spalte)
        {
            int msPause = 200;
            ConsoleKey key = ConsoleKey.DownArrow;  // Standardmäßig nach unten
            int punkte = 0;
            bool ok = true;
            do
            {
                ReadCursorKey(ref key);
                ok = MoveSnake(key, ref spalte, ref zeile, msPause);
                if (ok)
                {
                    punkte++;
                    StoreSnakeHead(zeile, spalte);
                    if (punkte % 2 == 1)
                    {
                        DeleteSnakeTail();
                    }
                }
            }
            while (ok);
            return punkte;
        }

        /// <summary>
        /// Kontrolliert die Richtung, die aktuell ist und setzt den
        /// Kopf der Schlange weiter in diese Richtung.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="spalte"></param>
        /// <param name="zeile"></param>
        /// <param name="msPause"></param>
        /// <returns></returns>
        static bool MoveSnake(ConsoleKey key, ref int spalte, ref int zeile, int msPause)
        {
            System.Threading.Thread.Sleep(msPause);
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    {
                        spalte = (spalte + 1) % spalten;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        spalte = (spalte - 1 + spalten) % spalten;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        zeile = (zeile - 1 + zeilen) % zeilen;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        zeile = (zeile + 1) % zeilen;
                        break;
                    }
            }
            if (Board.GetText(zeile, spalte) != "X")
            {
                Board.SetText(zeile, spalte, "X");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gültige Cursortaste einlegen
        /// </summary>
        /// <param name="key"></param>
        private static void ReadCursorKey(ref ConsoleKey key)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.RightArrow || keyPressed.Key == ConsoleKey.LeftArrow ||
                    keyPressed.Key == ConsoleKey.UpArrow || keyPressed.Key == ConsoleKey.DownArrow)
                {
                    key = keyPressed.Key;
                }
            }
        }

        /// <summary>
        /// Am Ende der Schlange wird eine Position gelöscht
        /// </summary>
        private static void DeleteSnakeTail()
        {
            Board.SetText(spur[tail, 0], spur[tail, 1], ".");
            tail = (tail+ 1) % spur.GetLength(0);
        }

        /// <summary>
        /// Die aktuelle Position der Schlange wird gespeichert
        /// </summary>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        private static void StoreSnakeHead(int zeile, int spalte)
        {
            spur[head, 0] = zeile;
            spur[head, 1] = spalte;
            head = (head+1) % spur.GetLength(0);
        }

    }
}
