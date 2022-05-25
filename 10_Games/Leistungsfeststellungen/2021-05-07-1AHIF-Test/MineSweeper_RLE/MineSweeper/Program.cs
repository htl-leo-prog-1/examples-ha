using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Program
    {
        public const string BOMB = "💣";
        private static bool[,] field;
        private static int count = 0;
        private static bool gameIsOver = false;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("MineSweeper");
            Console.WriteLine("===========");

            
            int fieldSize = ReadFieldSize();
            Console.Write($"Wieviele Minen sollen gesetzt werden? (> 0, <= { fieldSize * fieldSize}) ");
            int numberMines = Convert.ToInt32(Console.ReadLine());
            field = CreateMines(numberMines, fieldSize);
            Board.Init(fieldSize, fieldSize, "MineSweeper");
            
            Board.CellClicked += OnCellClicked;

            //DisplayAllMines(field);

            //PlayGame(field);
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Wird nach einem Mouse-Click im Board aufgerufen und kann verwendet werden,
        /// um die Auswahl einer Position auszuwerten.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private static void OnCellClicked(int row, int col)
        {
            if (gameIsOver) return;
            //Console.WriteLine($"You clicked in {row}/{col}.");
            if (field[row, col])
            {
                DisplayAllMines(field);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Anzahl gefundener minenfreier Positionen: {count}");
                gameIsOver = true;
                Console.ResetColor();
                Console.WriteLine("\nBeenden mit Eingabetaste  ...");

            }
            else
            {
                if (String.IsNullOrEmpty(Board.GetText(row, col)))
                {
                    int neighborBombs = CountMinesAround(field, row, col);
                    Board.SetText(row, col, neighborBombs.ToString(), "Green");
                    count++;
                }
            }
        }

        /// <summary>
        /// Old-School sequentieller Programmablauf mit händischer Eingabe
        /// einer Position über Tastatur
        /// </summary>
        /// <param name="field"></param>
        private static void PlayGame(bool[,] field)
        {
            int fieldSize = field.GetLength(0);
            int count = 0;
            bool gameIsOver = false;
            do
            {
                Console.WriteLine("Minenfreie Position suchen");
                Console.Write($"Zeile  (0 - {fieldSize - 1}): ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Spalte (0 - {fieldSize - 1}): ");
                int col = Convert.ToInt32(Console.ReadLine());
                if (field[row, col])
                {
                    DisplayAllMines(field);
                    gameIsOver = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(Board.GetText(row, col)))
                    {
                        int neighborBombs = CountMinesAround(field, row, col);
                        Board.SetText(row, col, neighborBombs.ToString(), "Green");
                        count++;
                    }
                }
            }
            while (!gameIsOver);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Anzahl gefundener minenfreier Positionen: {count}");
            Console.ResetColor();
        }

        private static void DisplayAllMines(bool[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col])
                    {
                        Board.SetText(row, col, BOMB);
                    }
                    else
                    {
                        int neighborBombs = CountMinesAround(field, row, col);
                        if (neighborBombs > 0 && String.IsNullOrEmpty(Board.GetText(row, col) ))
                        {
                            Board.SetText(row, col, neighborBombs.ToString(), "Red");
                        }
                        
                    }
                }
            }
        }

        private static int ReadFieldSize()
        {
            int size = 0;
            do
            {
                Console.Write("Größe des Spielfeldes (minimal 2, maximal 10): ");
                size = Convert.ToInt32(Console.ReadLine());
            } while (size < 2 || size > 10);

            return size;
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
            int count = 0;
            for (int r = Math.Max(row - 1, 0); r <= row + 1 && r < minesBoard.GetLength(0); r++)
            {
                for (int c = Math.Max(col - 1, 0); c <= col + 1 && c < minesBoard.GetLength(1); c++)
                {
                    if (!(row == r && col == c) && minesBoard[r, c])
                    {
                        count++;
                    }
                }
            }
            return count;
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
                for (int j = 0; j < minesBoard.GetLength((1)); j++)
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
        /// <param name="fieldsize">Seitenlänge des quadratischen Boards</param>
        /// <returns>Mit Minen belegtes Board oder null, falls nicht alle Minen Platz hatten</returns>
        public static bool[,] CreateMines(int countMines, int fieldsize)
        {
            bool[,] field = new bool[fieldsize, fieldsize];
            if (countMines > fieldsize * fieldsize)
            {
                countMines = fieldsize * fieldsize;
            }
            int count = 0;
            Random rand = new Random();

            while (count < countMines)
            {
                int row = rand.Next(0, fieldsize);
                int col = rand.Next(0, fieldsize);
                if (field[row, col] == false)
                {
                    count++;
                    field[row, col] = true;
                }
            }
            return field;
        }
    }
}
