using System;
using System.Threading;

namespace MovingSquare
{
    class Program
    {
        static Random rand = new Random();

        static ConsoleColor[] colorArray = {
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkYellow,
                ConsoleColor.White
                                         };

        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            char c = '@';
            int width = 8;
            int height = 5;
            int maxStartCol = Math.Max(0, Console.WindowWidth - width);
            int maxStartRow = Math.Max(0, Console.WindowHeight - height);
            
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                int startRow = rand.Next(0, maxStartRow + 1);
                int startCol = rand.Next(0, maxStartCol + 1);
                Console.ForegroundColor = colorArray[rand.Next(0, colorArray.Length)];
                for (int y = startRow; y < startRow + height; y++)
                {
                    for (int x = startCol; x < startCol + width; x++)
                    {                        
                        Console.SetCursorPosition(x, y);
                        Console.Write(c);
                    }
                }
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }
    }
}
