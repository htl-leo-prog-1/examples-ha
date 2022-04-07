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

            //!


            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Die Zeile wird gelöscht und alle darüber
        /// liegenden Zeilen werden um eins nach unten verschoben.
        /// </summary>
        /// <param name="allocation"></param>
        public static bool[,] DeleteLastRow(bool[,] allocation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ist die Zeile bereits gefüllt
        /// </summary>
        /// <param name="allocation"></param>
        /// <returns></returns>
        public static bool IsLastRowFilled(bool[,] allocation)
        {
            throw new NotImplementedException();
        }

    }
}
