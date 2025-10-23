/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: PingPong
*--------------------------------------------------------------
*/

using System;
using System.Threading;

const int COLS = 80;
const int ROWS = 25;

void Initialize()
{
    Console.SetWindowSize(COLS, ROWS);
    Console.CursorVisible = false;
}

void Terminate()
{
    Console.ResetColor();
    Console.SetCursorPosition(0, ROWS - 1);
    Console.WriteLine();
    Console.CursorVisible = true;
}

void DrawDot(int x, int y, ConsoleColor color)
{
    DrawChar(x,y,'*',color);
}

void DrawChar(int x, int y, char ch, ConsoleColor color)
{
    Console.SetCursorPosition(x, ROWS - y - 1);
    Console.ForegroundColor = color;
    Console.Write(ch);
}

void AnimationPingPong()
{
    int delayInMs = 50;

    int dx = -1;
    int dy = -1;
    int x = 0;
    int y = 0;

    while (!Console.KeyAvailable)
    {
        if (x == 0 || x == COLS - 1)
        {
            dx = -dx;
        }
        if (y == 0 || y == ROWS - 1)
        {
            dy = -dy;
        }

        x += dx;
        y += dy;

        DrawDot(x, y, ConsoleColor.Red);
        Thread.Sleep(TimeSpan.FromMilliseconds(delayInMs));
        DrawChar(x, y, ' ', ConsoleColor.Black);
    }
}

Initialize();
AnimationPingPong();
Terminate();
