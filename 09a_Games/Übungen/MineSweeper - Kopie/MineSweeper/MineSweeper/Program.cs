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


            int maxRow;
            int maxCol;
            string input;
            int size;

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
                Console.Write($"Anzahl Minen eingeben (> 0, <= {size * size} ): ");
                maxRow = int.Parse(Console.ReadLine());
            } while (mines < 1 || mines > size * size);
            bool[,] minenFeld = HideMines(mines, size);
            freeCellsFound = PlayGame(minenFeld);
            Console.WriteLine("Anzahl gefundener minenfreier Zellen: {0}", maxCol);
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();


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
            int countOfMines = 0;
            int rows = minesBoard.GetLength(0);
            int cols = minesBoard.GetLength(1);

            if (row > 0 && col > 0 && minesBoard[row - 1, col - 1])
            {
                countOfMines++;
            }
            if (row > 0 && minesBoard[row - 1, col])
            {
                countOfMines++;
            }
            if (row > 0 && col + 1 < cols && minesBoard[row - 1, col + 1])
            {
                countOfMines++;
            }
            if (col > 0 && minesBoard[row, col - 1])
            {
                countOfMines++;
            }
            if (col + 1 < cols && minesBoard[row, col + 1])
            {
                countOfMines++;
            }
            if (row + 1 < rows && col > 0 && minesBoard[row + 1, col - 1])
            {
                countOfMines++;
            }
            if (row + 1 < rows && minesBoard[row + 1, col])
            {
                countOfMines++;
            }
            if (row + 1 < rows && col + 1 < cols && minesBoard[row + 1, col + 1])
            {
                countOfMines++;
            }
            return countOfMines;
        }

        /// <summary>
        /// Zählt die Anzahl der Minen im quadratischen Minenfeld
        /// </summary>
        /// <param name="minesBoard"></param>
        /// <returns>Anzahl der Minen</returns>
        public static int CountMinesOnBoard(bool[,] minesBoard)
        {
            int countMines = 0;
            int row1 = minesBoard.GetLength(0);
            int col1 = minesBoard.GetLength(1);

            for (int row = 0; row < minesBoard.GetLength(0); row++)
            {
                for (int col = 0; col < minesBoard.GetLength(1); col++)
                {
                    if (minesBoard[row, col] == false)
                    {
                        countMines++;
                    }
                }
            }
        }

        /// <summary>
        /// Verteile Minen zufällig auf das Spielfeld. Auf einer Position
        /// darf maximal eine Mine liegen
        /// </summary>
        /// <param name="countMines">Anzahl der zu verteilenden Minen</param>
        /// <param name="rowsAndCols">rows und Spalten des quadratischen Boards</param>
        /// <returns>Mit Minen belegtes Board oder null, falls nicht alle Minen Platz hatten</returns>
        public static bool[,] HideMines(bool[] mine, int countMines, int rowsAndCols)
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
                while (minesBoard[row, col]);
                minesBoard[row, col] = true;
            }
            return minesBoard;

        }
    }
}
