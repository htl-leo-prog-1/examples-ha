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
            bool[,] minesBoard;
            string input;
            int size;
            int countMines = 0;
            int row;
            int col;
            int rowsAndCols;
            int counter = 0;

            Console.Title = "MinesSweeper";
            Console.WriteLine("MineSweeper");
            Console.WriteLine("===========");

            do
            {
                Console.Write("Größe des quadratischen Boards (minimal 2, maximal 10) eingeben: ");
                input = Console.ReadLine();
                size = Convert.ToInt32(input);
            } while (size < 2 || size > 10);
            minesBoard = new bool[size, size];

            do                              //ToDo Schleife und Inhalt hinzugefügt(übersehen)
            {
                if (counter == 1)
                {
                    Console.WriteLine("Fehlerhafte Angabe der Minen!");
                }
                Console.Write("Anzahl Minen eingeben (>0, <={0}): ", minesBoard.Length);
                input = Console.ReadLine();
                countMines = Convert.ToInt32(input);
                counter = 1;
            } while (countMines < 0 || countMines > minesBoard.Length);

            row = size;
            col = size;
            rowsAndCols = size;
            Board.Init(size, size, "MineSweeper");
            minesBoard = HideMines(countMines, rowsAndCols);  //den zurückgegebenen Wert auf minesBoard überschrieben

            TryToNotHit(size, minesBoard);

            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        private static void TryToNotHit(int size, bool[,] minesBoard)
        {
            string input;
            int row;
            int col;
            int counter = 0;
            bool gameOver = false;
            int minesAround;

            do
            {
                Console.WriteLine("Minfreie Position suchen");
                Console.Write("Zeile: (0-{0}): ", size - 1);
                input = Console.ReadLine();
                row = Convert.ToInt32(input);

                Console.Write("Spalte: (0-{0}): ", size - 1);
                input = Console.ReadLine();
                col = Convert.ToInt32(input);
                if (Board.GetText(row, col) == "" && !minesBoard[row, col])
                {
                    counter++;
                }
                if (!minesBoard[row, col])
                {
                    minesAround = CountMinesAround(minesBoard, row, col);
                    Board.SetText(row, col, Convert.ToString(minesAround));
                }
                else
                {
                    gameOver = true;
                    SetAllMinesOnBoard(minesBoard);
                }

            } while (!gameOver);
            Console.WriteLine("Anzahl gefundener minenfreier Zellen: {0}", counter);
        }

        private static void SetAllMinesOnBoard(bool[,] minesBoard)
        {
            for (int row = 0; row < minesBoard.GetLength(0); row++)
            {
                for (int col = 0; col < minesBoard.GetLength(1); col++)
                {
                    if (minesBoard[row, col])
                    {
                        Board.SetText(row, col, "X", "Red");
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
        public static bool[,] HideMines(int countMines, int rowsAndCols)
        {
            bool[,] minesBoard = new bool[rowsAndCols, rowsAndCols];
            int randomNumber;
            Random random = new Random();
            bool setMine;
            int currentMines;

            do                              //ToDo dowhileSchleife erzeugt
            {                               //Kommentar: es ist aufwenig/ wollte nicht viel verändern
                setMine = false;
                if (countMines > 0)
                {
                    for (int row = 0; row < minesBoard.GetLength(0) && !setMine; row++)
                    {
                        for (int col = 0; col < minesBoard.GetLength(1) && !setMine; col++)
                        {
                            randomNumber = random.Next(0, minesBoard.Length);
                            if (randomNumber == 0 && !minesBoard[row, col])
                            {
                                minesBoard[row, col] = true;
                                setMine = true;
                            }
                        }
                    }
                }
                else
                {
                    currentMines = countMines;
                }

                currentMines = CountMinesOnBoard(minesBoard);
            } while (currentMines != countMines);

            return minesBoard;
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
                countOfMines++; //Linksoben
            }

            if (row > 0 && minesBoard[row - 1, col])
            {
                countOfMines++; //oben
            }

            if (row > 0 && col + 1 < cols && minesBoard[row - 1, col + 1])
            {
                countOfMines++; // rechtsoben
            }

            if (col > 0 && minesBoard[row, col - 1])
            {
                countOfMines++; //links
            }
            if (col + 1 < cols && minesBoard[row, col + 1])
            {
                countOfMines++; // rechts
            }

            if (row + 1 < rows && col > 0 && minesBoard[row + 1, col - 1]) //TODO
            {
                countOfMines++;//linksunten
            }
            if (row + 1 < rows && minesBoard[row + 1, col])
            {
                countOfMines++; // unten
            }
            if (row + 1 < rows && col + 1 < cols && minesBoard[row + 1, col + 1])
            {
                countOfMines++;// rechtsunten
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
            int counter = 0;
            for (int row = 0; row < minesBoard.GetLength(0); row++)
            {
                for (int col = 0; col < minesBoard.GetLength(1); col++) //TODO In For verschachteln
                {
                    if (minesBoard[row, col])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
