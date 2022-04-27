using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size;
            int mines;
            string input;
            int freeCellsFound;
            Console.WriteLine("MineSweeper");
            Console.WriteLine("===========");
            do
            {
                Console.Write("Größe des quadratischen Boards (minimal 2, maximal 10) eingeben: ");
                input = Console.ReadLine();
                size = int.Parse(input);
            } while (size < 2 || size > 10);
            Board.Init(size, size, "MineSweeper");
            do
            {
                Console.Write($"Anzahl Minen eingeben (> 0, <= {size*size} ): ");
                mines = int.Parse(Console.ReadLine());
            } while (mines < 1 || mines > size * size);
            bool[,] minenFeld = HideMines(mines, size);
            freeCellsFound = PlayGame(minenFeld);
            ShowMines(minenFeld);
            Console.WriteLine("Anzahl gefundener minenfreier Zellen: {0}", freeCellsFound);
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Der Spieler versucht im Minenfeld möglichst viele freie Plätze zu finden.
        /// </summary>
        /// <param name="minesBoard"></param>
        /// <returns>Anzahl von gefundenen freien Feldern</returns>
        private static int PlayGame(bool[,] minesBoard)
        {
            int row;
            int col;
            int count = 0;
            int mines;
            do
            {
                Console.WriteLine("Minenfreie Position suchen");
                row = ReadInt("Zeile: ", minesBoard.GetLength(0) - 1);
                col = ReadInt("Spalte: ", minesBoard.GetLength(1) - 1);
                if (!minesBoard[row, col])
                {
                    mines = CountMinesAround(minesBoard, row, col);
                    if (Board.GetText(row, col).Length == 0)  // damit ein bereits aufgedecktes Feld nicht doppelt gezählt wird
                    {
                        count++;
                    }
                    Board.SetText(row, col, mines.ToString());
                }
            } while (!minesBoard[row, col]);
            return count;
        }

        /// <summary>
        /// Alle Minen auf den Bildschirm ausgeben
        /// </summary>
        /// <param name="minesBoard"></param>
        static void ShowMines(bool[,] minesBoard)
        {
            for (int i = 0; i < minesBoard.GetLength(0); i++)
            {
                for (int j = 0; j < minesBoard.GetLength(1); j++)
                {
                    if (minesBoard[i, j])
                    {
                        Board.SetText(i, j, "X", "Red");
                    }
                }

            }
        }

        /// <summary>
        /// Wieviele Minen befinden sich rund um die gegebene Position
        /// </summary>
        /// <param name="minesBoard">Versteckte Minen</param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>Anzahl der Minen um die gesuchte Position</returns>
        public static int CountMinesAround(bool[,] minesBoard, int row, int col)
        {
            int anzahl = 0;
            int zeileVon = Math.Max(0, row - 1);
            int zeileBis = Math.Min(minesBoard.GetLength(0) - 1, row + 1);
            int spalteVon = Math.Max(0, col - 1);
            int spalteBis = Math.Min(minesBoard.GetLength(1) - 1, col + 1);
            for (int z = zeileVon; z <= zeileBis; z++)
            {
                for (int s = spalteVon; s <= spalteBis; s++)
                {
                    if (minesBoard[z, s])
                    {
                        anzahl++;
                    }
                }
            }
            if (minesBoard[row, col])
            {
                anzahl--;
            }
            return anzahl;
        }

        /// <summary>
        /// Zählt die Anzahl der Minen im quadratischen Minenfeld
        /// </summary>
        /// <param name="minesBoard"></param>
        /// <returns>Anzahl der Minen</returns>
        public static int CountMinesOnBoard(bool[,] minesBoard)
        {
            int count = 0;
            for (int i = 0; i < minesBoard.GetLength(0); i++)
            {
                for (int j = 0; j < minesBoard.GetLength(1); j++)
                {
                    if (minesBoard[i, j])
                    {
                        count++;
                    }
                }

            }
            return count;
        }

        /// <summary>
        /// Verteile Minen zufällig auf das Spielfeld. Auf einer Position
        /// darf maximal eine Mine liegen
        /// </summary>
        /// <param name="countMines">Anzahl der zu verteilenden Minen</param>
        /// <param name="rowsAndCols">rows und Spalten des quadratischen Boards</param>
        /// <returns>Mit Minen belegtes Board oder null, falls nicht alle Minen Platz hatten</returns>
        public static bool[,] HideMines(int countMines, int rowsAndCols)
        {
            Random random = new Random();
            int row;
            int col;
            if (countMines > (rowsAndCols * rowsAndCols))
            {
                return null;
            }
            bool[,] minesBoard = new bool[rowsAndCols, rowsAndCols];
            for (int i = 0; i < countMines; i++)
            {
                do
                {
                    row = random.Next(rowsAndCols);
                    col = random.Next(rowsAndCols);
                }
                while (minesBoard[row, col]); // solange die Position bereits belegt ist
                minesBoard[row, col] = true;
            }
            return minesBoard;
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
