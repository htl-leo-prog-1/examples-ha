using System;

namespace Tetris
{
    public class Tetris
    {
        static readonly Random random = new Random();

        /// <summary>
        /// Hauptprogramm für Tetris
        /// Spielfeld anlegen und Spiel abwickeln
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            int maxRow = 5;
            int maxCol = 5;
            bool[,] allocation;
            Console.WriteLine("Tetris");
            Console.WriteLine("======");
            // Spielfeld anlegen
            Board.Init(maxCol, maxRow, "Tetris");
            allocation = new bool[maxCol, maxRow];
            Console.WriteLine("Spiel starten mit Enter!");
            Console.ReadLine();
            PlayGame(allocation);
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Der Hauptablauf des Spiels wird abgewickelt
        /// </summary>
        public static void PlayGame(bool[,] allocation)
        {
            int msPause = 500;
            int counter = 0;
            int row;
            int col;
            bool isFinished = false;
            int maxRow = allocation.GetLength(1) - 1;

            // Geschwindigkeit initialisieren
            // Bis Spielende erreicht wird (eine Spalte ist voll)
            while (!isFinished)
            {
                // Neuen Stein erzeugen und Zähler erhöhen
                col = random.Next(maxRow);
                row = 0;
                if (allocation[row, col]) // oberste Zeile belegt
                {
                    isFinished = true;
                }
                else
                {
                    counter++;
                    allocation[row, col] = true;
                    Board.SetText(row, col, "O");
                    // Solange nicht unten angelangt
                    do
                    {
                        System.Threading.Thread.Sleep(msPause);
                        // nichts zu tun ausser warten
                    }
                    while (MoveStone(allocation, ref row, ref col));
                    // liefert Zeile zurück, in der Stein gelandet ist
                }
                // Zeile mit Stein vollständig gefüllt
                if (IsLastRowFilled(allocation))
                {
                    // Zeile löschen
                    DeleteLastRow(allocation);
                }
                // Geschwindigkeit erhöhen
                msPause = Math.Max(msPause - 20, 100);
            }
            Console.WriteLine("Du hast {0} Steine geschafft!", counter);
        }

        /// <summary>
        /// Die Zeile wird gelöscht und alle darüber
        /// liegenden Zeilen werden um eins nach unten verschoben.
        /// </summary>
        /// <param name="allocation"></param>
        public static bool[,] DeleteLastRow(bool[,] allocation)
        {
            int maxRow = allocation.GetLength(1) - 1;
            int rowFrom;
            // Darüber liegende Zeilen nach unten verschieben
            rowFrom = allocation.GetLength(0) - 2;
            while (rowFrom >= 0)
            {
                for (int i = 0; i <= maxRow; i++)
                {
                    allocation[rowFrom + 1, i] = allocation[rowFrom, i];
                    if (allocation[rowFrom + 1, i])
                    {
                        Board.SetText(rowFrom + 1, i, "O");
                    }
                    else
                    {
                        Board.SetText(rowFrom + 1, i, "");
                    }
                }
                rowFrom--;
            }
            // erste Zeile löschen
            for (int i = 0; i <= maxRow; i++)
            {
                allocation[0, i] = false;
                Board.SetText(0, i, "");
            }
            return allocation;
        }

        /// <summary>
        /// Der Stein fällt um eine Zeile tiefer, falls dort
        /// noch frei ist.
        /// Die Tastensteuerung LINKS/RECHTS wird ebenfalls in dieser
        /// Methode realisiert.
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>Wurde der Stein bewegt</returns>
        public static bool MoveStone(bool[,] allocation, ref int row, ref int col)
        {
            int maxCol = allocation.GetLength(1) - 1;
            ConsoleKeyInfo key;
            int colNew;
            bool isFree;
            colNew = col;
            // Von Tastatur einlesen
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                // Stein horizontal bewegen
                if (key.Key == ConsoleKey.RightArrow)
                {
                    colNew = Math.Min(col + 1, maxCol);
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    colNew = Math.Max(col - 1, 0);
                }
            }
            if (MoveStone(allocation, row, col, row, colNew))
            {
                col = colNew;
            }
            isFree = MoveStone(allocation, row, col, row + 1, col);
            if (isFree)
            {
                row = row + 1;
            }
            return isFree;
        }

        /// <summary>
        /// Ist die Zeile bereits gefüllt
        /// </summary>
        /// <param name="allocation"></param>
        /// <returns></returns>
        public static bool IsLastRowFilled(bool[,] allocation)
        {
            int col = 0;
            int row = allocation.GetLength(0) - 1;
            int maxRow = allocation.GetLength(1);
            while (col < maxRow && allocation[row, col])
            {
                col++;
            }
            return col == maxRow;
        }

        /// <summary>
        /// Der Stein wird, wenn möglich waagrecht verschoben
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowNew"></param>
        /// <param name="colNew"></param>
        /// <returns>war möglich, noch nicht am Rand</returns>
        static bool MoveStone(bool[,] allocation, int row, int col, int rowNew, int colNew)
        {
            int maxRow = allocation.GetLength(0) - 1;
            int maxCol = allocation.GetLength(1) - 1;
            if (rowNew > maxRow || colNew > maxCol || allocation[rowNew, colNew])
            {
                return false;
            }
            Board.SetText(row, col, "");
            Board.SetText(rowNew, colNew, "O");
            allocation[row, col] = false;
            allocation[rowNew, colNew] = true;
            return true;
        }
    }
}
