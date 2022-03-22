/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: GameOfLife
* see: https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
*--------------------------------------------------------------
*/

namespace GameOfLife
{
    using System;

    public class GameOfLife
    {
        /// <summary>
        /// Berechnet die Welt in der nächsten Generation
        /// </summary>
        /// <param name="world">aktueller Zustand der Zellen</param>
        /// <returns>Welt nach dem nächsten Schritt</returns>
        public static bool[,] CalculateNextGeneration(bool[,] world)
        {
            int size = world.GetLength(0);
            bool[,] worldAfter = new bool[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int countNeighbours = CountNeighbours(world, row, col);
                    if (world[row, col])
                    {
                        worldAfter[row, col] = (countNeighbours == 2) || (countNeighbours == 3);
                    }
                    else
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
            int neighbourCount = 0;
            int size = world.GetLength(0);

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
                        neighbourCount++;
                    }
                }
            }

            // eigenes Leben abziehen, falls true, sonst bin ich mein eigener Nachbar
            if (world[row, col])
            {
                neighbourCount--;
            }

            return neighbourCount;
        }

        /// <summary>
        /// Die aktuelle Welt wird auf den Bildschirm ab der aktuellen Position
        /// ausgegeben.
        /// </summary>
        /// <param name="world">Auszugebende Welt</param>
        public static void WriteWorldConsole(bool[,] world)
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
        /// Die Ausgangswelt in der gewünschten Größe wird erzeugt.
        /// Die Zellen werden mit 50% Wahrscheinlichkeit zum Leben erweckt
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool[,] CreateWorld(int size)
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
        
        /// <summary>
        /// Einlesen (von der Konsole) einer welt.
        /// </summary>
        /// <param name="size">Größe der Welt</param>
        /// <returns></returns>
        public static bool[,] ReadMatrix(int size)
        {
            var world = new bool[size, size];

            for (int row = 0; row < size; row++)
            {
                Console.Write($"{row + 1,2}. Row: ");
                var text = Console.ReadLine();

                for (int col = 0; col < size && col < text.Length; col++)
                {
                    if (text[col] == '1')
                    {
                        world[row, col] = true;
                    }
                }
            }

            return world;
        }
    }
}