/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: <CLASSNAME>
 *--------------------------------------------------------------
 *              Birgit Schröder
 *--------------------------------------------------------------
 * Description:
 * The program prints a tree with configurable height and center
 * to the console.
 * Random positions are selected and printed in a randomly 
 * coloured character '@'.
 *--------------------------------------------------------------
*/
using System;
using System.Threading;

namespace ChristmasTree
{
    class Program
    {
        static Random rand = new Random();
        static ConsoleColor[] colorArray = {
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Cyan,
                ConsoleColor.Magenta,
                ConsoleColor.Blue
        };
        const int HEIGHT = 15;
        const int CENTER = 20;

        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 24);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            Console.Clear();
            int trunkHeight = HEIGHT / 5;
            int trunkBottomLine = Console.WindowHeight;
            int treeBottomLine = trunkBottomLine - trunkHeight;   
            int leftMargin = CENTER - HEIGHT;
            int rightMargin = CENTER + HEIGHT;
            while (!Console.KeyAvailable)
            {
                /// Print Tree
                int topLine = treeBottomLine - HEIGHT;               
                int blanks = HEIGHT;
                for (int y = topLine; y < treeBottomLine; y++)
                {
                    int leftPos = leftMargin + blanks;
                    int rightPos = rightMargin - blanks;
                    int firstBlinkingPos = rand.Next(leftMargin, rightMargin + 1);
                    int secondBlinkingPos = rand.Next(leftMargin, rightMargin + 1);
                    bool rowIsBlinking = rand.Next(0, 2) == 1;
                    for (int x = leftPos; x <= rightPos; x++)
                    {
                        char c = '#';
                        if (rowIsBlinking && (firstBlinkingPos == x || secondBlinkingPos == x))
                        {
                            int colorIndex = rand.Next(0, colorArray.Length);
                            Console.ForegroundColor = colorArray[colorIndex];
                            c = '@';
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(c);
                    }
                    blanks--;
                }
                /// Print Trunk
                topLine = trunkBottomLine - trunkHeight;
                for (int y = topLine; y < trunkBottomLine; y++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    for (int x = CENTER - 1; x <= CENTER + 1; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write('|');
                    }
                }
                /// Wait for half a second
                Thread.Sleep(500);
            }          
        }
    }
}
