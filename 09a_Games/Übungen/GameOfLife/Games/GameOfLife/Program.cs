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

    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            int    round = 0;

            Console.WriteLine("Game of Life");
            Console.WriteLine("============");

            bool[,] world = CreateOrReadWorld();

            PrintWorld(world, "Ausgangswelt:", "Start mit Eingabetaste...");

            do
            {
                world = GameOfLife.CalculateNextGeneration(world);
                round++;

                input = PrintWorld(world, $"Welt nach Runde: {round}",
                    "Eingabetaste für nächste Runde oder x für Ende: ");
            } while (input != "x" && input != "X");
        }

        private static bool[,] CreateOrReadWorld()
        {
            bool[,] world;

            Console.WriteLine("Bei einer negativen Größe wird eine zufällige Welt mit der positiven Größe erstellt.");
            int size = ReadNumber("Größe des Spielfelds: ", -100, 100);

            if (size < 0)
            {
                size  *= -1;
                world =  GameOfLife.CreateWorld(size);
            }
            else
            {
                world = GameOfLife.ReadMatrix(size);
            }

            Board.Init(size, size, "Game of Life");

            return world;
        }

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

        private static string PrintWorld(bool[,] world, string title, string message)
        {
            Console.Clear();
            Console.WriteLine(title);
            WriteWorldBoard(world);
            GameOfLife.WriteWorldConsole(world);
            Console.WriteLine();
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }

        private static int ReadNumber(string message, int min, int max)
        {
            int  number;
            bool isOk;
            do
            {
                Console.Write($"{message} [{min}..{max}]: ");
                isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
            } while (!isOk);

            return number;
        }
    }
}