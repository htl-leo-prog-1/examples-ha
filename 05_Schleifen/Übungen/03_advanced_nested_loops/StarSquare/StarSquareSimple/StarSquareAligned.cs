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

	    const int CONSOLE_WITH = 80;
            const int CONSOLE_LENGTH = 24;
            Console.Write("Länge? ");
            int length = Convert.ToInt32(Console.ReadLine());

            Console.Write("Breite? ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetWindowSize(CONSOLE_WITH,CONSOLE_LENGTH);

            Console.CursorVisible = false;
            Console.Clear();

            for (int y = (CONSOLE_LENGTH-length)/2; y < (CONSOLE_LENGTH-length)/2 + length; y++)
            {
                for (int x = (CONSOLE_WITH-width)/2; x < (CONSOLE_WITH-width)/2 + width; x++)
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
