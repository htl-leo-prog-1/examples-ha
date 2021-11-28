using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSquareSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Länge? ");
            int length = Convert.ToInt32(Console.ReadLine());

            Console.Write("Breite? ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            Console.Clear();

            for (int y = 12; y < 12 + length; y++)
            {
                for (int x = 40; x < 40 + width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('*');
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
