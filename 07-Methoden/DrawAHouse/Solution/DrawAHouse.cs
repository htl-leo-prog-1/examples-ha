/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Draw A House
*--------------------------------------------------------------
*/

using System;

const int COLS = 80;
const int ROWS = 25;

void Initialize()
{
    Console.SetWindowSize(COLS, ROWS);
}

void DrawDot(int x, int y, ConsoleColor color)
{
    Console.SetCursorPosition(x, ROWS - y - 1);
    Console.ForegroundColor = color;
    Console.Write('*');
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

void DrawAWindow(int x, int y, ConsoleColor color)
{
    FillBox(x, y, x + 4, y + 2, color);
}

void DrawADoor(int x, int y, ConsoleColor color)
{
    FillBox(x, y+1, x + 4, y + 4, color);
}

void DrawAHouse(int x, int y, ConsoleColor color)
{
    DrawADoor(x + 3, y + 0, ConsoleColor.DarkRed);
    DrawAWindow(x + 10, y + 2, ConsoleColor.Gray);
    DrawAWindow(x + 3, y + 6, ConsoleColor.Gray);
    DrawAWindow(x + 10, y + 6, ConsoleColor.Gray);
    DrawLine(x - 1, y + 9, x + 8, y + 18, color);
    DrawLine(x + 9, y + 18, x + 18, y + 9, color);
    DrawBox(x, y, x + 17, y + 10, color);
}

Console.WriteLine("Draw a house with our own library ");
Console.WriteLine("**********************************");

Initialize();

DrawLine(0, 0, COLS - 1, 0, ConsoleColor.Green);
DrawAHouse(5, 1, ConsoleColor.White);
DrawAHouse(30, 2, ConsoleColor.Magenta);
DrawAHouse(55, 3, ConsoleColor.Yellow);

Console.ResetColor();
Console.SetCursorPosition(0, ROWS - 1);
Console.WriteLine();
Console.ReadLine();