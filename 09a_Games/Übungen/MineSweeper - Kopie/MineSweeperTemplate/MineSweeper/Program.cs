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
            Console.WriteLine("MineSweeper");
            Console.WriteLine("===========");

            ///!

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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Zählt die Anzahl der Minen im quadratischen Minenfeld
        /// </summary>
        /// <param name="minesBoard"></param>
        /// <returns>Anzahl der Minen</returns>
        public static int CountMinesOnBoard(bool[,] minesBoard)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
