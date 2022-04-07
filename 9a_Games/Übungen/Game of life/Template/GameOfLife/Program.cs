using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool[,] world;
            string input;
            int round = 0;
            int size;
            Console.WriteLine("Game of Life");
            Console.WriteLine("============");
            Console.Write("Größe des Spielfelds: ");
            size = int.Parse(Console.ReadLine());
            Board.Init(size, size, "Game of Life");
            Console.WriteLine();
            Console.WriteLine("Ausgangswelt:");


            ///!
        }

        /// <summary>
        /// Für die aktuelle Position wird ermittelt, wie viele
        /// lebende Nachbarzellen existieren.
        /// </summary>
        /// <param name="world">Welt</param>
        /// <param name="row">aktuelle Zeile</param>
        /// <param name="col">aktuelle Spalte</param>
        /// <returns>Anzahl der lebenden Nachbarzellen</returns>
        public static int CountNeighbours(bool[,] world, int row, int col)
        {
            throw new NotImplementedException();
        }

    }
}
