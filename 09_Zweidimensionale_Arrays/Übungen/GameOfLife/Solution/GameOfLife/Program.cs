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
            bool[,] world;
            string input;
            int round = 0;
            int size;
            Console.WriteLine("Game of Life");
            Console.WriteLine("============");

            Console.WriteLine("Bei einer negativen Größe wird eine zufällige Welt mit der positiven Größe erstellt.");
            size = ReadNumber("Größe des Spielfelds: ", -100, 100);

            if (size < 0)
            {
                size *= -1;
                world = GameOfLife.CreateWorld(size);
            }
            else
            {
                world = GameOfLife.ReadMatrix(size);
            }

            Console.WriteLine();
            Console.WriteLine("Ausgangswelt:");

            GameOfLife.WriteWorldConsole(world);
            Console.WriteLine();
            Console.Write("Start mit Eingabetaste ... ");
            Console.ReadLine();
            do
            {
                round++;
                Console.Clear();
                Console.WriteLine("Welt nach Runde: {0}", round);
                world = GameOfLife.CalculateNextGeneration(world);
                Console.WriteLine();
                GameOfLife.WriteWorldConsole(world);
                Console.WriteLine();
                Console.Write("Eingabetaste für nächste Runde oder x für Ende: ");
                input = Console.ReadLine();
            } while (input != "x" && input != "X");
        }

        private static int ReadNumber(string message, int min, int max)
        {
            int number;
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