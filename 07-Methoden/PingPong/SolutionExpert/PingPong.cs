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

void DrawChar(int x, int y, char ch, ConsoleColor color)
{
    Console.SetCursorPosition(x, ROWS - y - 1);
    Console.ForegroundColor = color;
    Console.Write(ch);
}

void DrawDot(int x, int y, ConsoleColor color)
{
    DrawChar(x,y,'*',color);
}

void DrawLine(int x0, int y0, int x1, int y1, ConsoleColor color)
{
    int distanceX = x1 - x0;
    int distanceY = y1 - y0;

    int distance = Math.Max(Math.Abs(distanceX), Math.Abs(distanceY));

    int roundOffsetX = distanceX >= 0 ? distance / 2 : -distance / 2;
    int roundOffsetY = distanceY >= 0 ? distance / 2 : -distance / 2;

    for (int i = 0; i <= distance; i++)
    {
        int x = x0 + (i * distanceX + roundOffsetX) / distance;
        int y = y0 + (i * distanceY + roundOffsetY) / distance;
        DrawDot(x, y, color);
    }
}

void DrawBox(int x0, int y0, int x1, int y1, ConsoleColor color)
{
    DrawLine(x0, y0, x1, y0, color);
    DrawLine(x1, y0, x1, y1, color);
    DrawLine(x1, y1, x0, y1, color);
    DrawLine(x0, y1, x0, y0, color);
}

void FillBox(int x0, int y0, int x1, int y1, ConsoleColor color)
{
    int xStart = Math.Min(x0, x1);
    int xEnd = Math.Max(x0, x1);

    int yStart = Math.Min(y0, y1);
    int yEnd = Math.Max(y0, y1);

    for (int x = xStart; x <= xEnd; x++)
    {
        for (int y = yStart; y <= yEnd; y++)
        {
            DrawDot(x, y, color);
        }
    }
}

void AnimatePingPong(int x0, int y0, int x1, int y1, int delayInMs)
{
    DrawBox(x0,y0,x1,y1,ConsoleColor.Green);

    x0++;
    x1--;
    y0++;
    y1--;

    FillBox(x0, y0, x1, y1, ConsoleColor.DarkGray);

    int dx = -1;
    int dy = -1;
    int x = x0;
    int y = y0;

    while (!Console.KeyAvailable)
    {
        if (x <= x0 || x >= x1)
        {
            dx = -dx;
        }
        if (y <= y0 || y >= y1)
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

AnimatePingPong(0,0,COLS-1, ROWS-1, 50);

Terminate();

