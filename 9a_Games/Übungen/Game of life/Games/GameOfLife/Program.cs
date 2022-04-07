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
            world = CreateWorld(size);
            //WriteWorldConsole(world);
            WriteWorldBoard(world);
            Console.WriteLine();
            Console.Write("Start mit Eingabetaste ... ");
            Console.ReadLine();
            do
            {
                round++;
                Console.Clear();
                Console.WriteLine("Welt nach Runde: {0}", round);
                world = CalculateNextGeneration(world);
                Console.WriteLine();
                //WriteWorldConsole(world);
                WriteWorldBoard(world);
                Console.WriteLine();
                Console.Write("Eingabetaste für nächste Runde oder x für Ende: ");
                input = Console.ReadLine();
            } while (input != "x" && input != "X");
        }

        /// <summary>
        /// Berechnet die Welt in der nächsten Generation
        /// </summary>
        /// <param name="world">aktueller Zustand der Zellen</param>
        /// <returns>Welt nach dem nächsten Schritt</returns>
        private static bool[,] CalculateNextGeneration(bool[,] world)
        {
            int countNeighbours;
            int size = world.GetLength(0);
            bool[,] worldAfter = new bool[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    countNeighbours = CountNeighbours(world, row, col);
                    if (world[row, col]) // Folgezustand für belebte Zellen
                    {
                        worldAfter[row, col] = (countNeighbours == 2) || (countNeighbours == 3);
                    }
                    else  // Folgezustand für unbelebte Zellen
                    {
                        worldAfter[row, col] = (countNeighbours == 3);
                    }
                }
            }
            return worldAfter;
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
            int counter = 0;
            int size = world.GetLength(0);
            // existierenden Bereich rund um die Zelle abgrasen
            int left = Math.Max(0, col - 1);
            int right = Math.Min(size - 1, col + 1);
            int top = Math.Max(0, row - 1);
            int bottom = Math.Min(size - 1, row + 1);
            for (int z = top; z <= bottom; z++)
            {
                for (int s = left; s <= right; s++)
                {
                    if (world[z, s])
                    {
                        counter++;
                    }
                }
            }
            // eigenes Leben abziehen, falls true
            if (world[row, col])
            {
                counter--; // sonst bin ich mein eigener Nachbar
            }
            return counter;
        }

        /// <summary>
        /// Die aktuelle Welt wird auf den Bildschirm ab der aktuellen Position
        /// ausgegeben.
        /// </summary>
        /// <param name="world">Auszugebende Welt</param>
        private static void WriteWorldConsole(bool[,] world)
        {
            Console.WriteLine();
            for (int i = 0; i < world.GetLength(0); i++)
            {
                Console.Write("    ");
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    if (world[i, j])
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Die aktuelle Welt wird auf den Bildschirm ab der aktuellen Position
        /// ausgegeben.
        /// </summary>
        /// <param name="world">Auszugebende Welt</param>
        private static void WriteWorldBoard(bool[,] world)
        {
            Board.Clear();
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    if (world[i, j])
                    {
                        Board.SetText(i, j, "X");
                    }
                }
            }
        }

        /// <summary>
        /// Die Ausgangswelt in der gewünschten Größe wird erzeugt.
        /// Die Zellen werden mit 50% Wahrscheinlichkeit zum Leben erweckt
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static bool[,] CreateWorld(int size)
        {
            bool[,] world = new bool[size, size];
            Random random = new Random(0);
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    if (random.Next(0, 2) > 0)
                    {
                        world[i, j] = true;
                    }
                }
            }
            return world;
        }
    }
}
