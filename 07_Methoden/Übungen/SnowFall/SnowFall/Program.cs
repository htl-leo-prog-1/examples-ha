using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFall
{
    class Program
    {
        static char[,] landscape = new char[Console.WindowWidth, Console.WindowHeight];
        static Random random = new Random();
            
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            // tree height = 15, tree center position = 40
            BuildTreeIntoLandscape(15, 40);                         
            while (!Console.KeyAvailable)
            {
                GenerateNewSnowflake();
                // from left to right
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    // from bottom to top
                    for (int y = Console.WindowHeight - 2; y >= 0; y--)
                    {
                        MoveSnowFlakeDown(x, y);
                        WriteLandscapePosition(x, y);                       
                    }
                }
            }
        }

        static void BuildTreeIntoLandscape(int treeHeight, int treeCenter)
        {
            int trunkHeight = treeHeight / 5;
            int trunkBottomLine = Console.WindowHeight - 1;
            int treeBottomLine = trunkBottomLine - trunkHeight;

            BuildTrunk(trunkBottomLine, trunkHeight, treeCenter);
            BuildTree(treeBottomLine, treeHeight, treeCenter);
            
        }

        static void BuildTree(int bottomLine, int height, int center)
        {
            int topLine = bottomLine - height;
            int leftMargin = center - height;
            int rightMargin = center + height;
            int blanks = height;
            for (int y = topLine; y < bottomLine; y++)
            {
                int leftPos = leftMargin + blanks;
                int rightPos = rightMargin - blanks;
                for (int x = leftPos; x <= rightPos; x++)
                {
                    landscape[x, y] = '#';
                }
                blanks--;
            }
        }

        static void BuildTrunk(int bottomLine, int height, int center)
        {
            int topLine = bottomLine - height;
            for (int y = topLine; y < bottomLine; y++)
            {
                landscape[center - 1, y] =
                landscape[center, y] =
                landscape[center + 1, y] = '|';
            }
        }

        static void GenerateNewSnowflake()
        {
            int snowFlakePos = random.Next(Console.WindowWidth - 1);
            landscape[snowFlakePos, 0] = '*';
            WriteLandscapePosition(snowFlakePos, 0);
        }

        static void MoveSnowFlakeDown(int x, int y)
        {
            if (y > 0 && landscape[x, y - 1] == '*' && landscape[x, y] == '\0')
            {
                // Move snowflake from higher (y - 1) to lower (y) line
                landscape[x, y - 1] = '\0';
                landscape[x, y] = '*';
            }
        }

        static void WriteLandscapePosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            switch (landscape[x, y])
            {
                case '#':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case '|':
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case '*':
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.Write(landscape[x, y]);
        }
    }
}
