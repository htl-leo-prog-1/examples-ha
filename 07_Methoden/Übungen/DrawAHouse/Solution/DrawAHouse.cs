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
    int diffX = x1 - x0;
    int diffY = y1 - y0;
    int mulX = diffX >= 0 ? 1 : -1;
    int mulY = diffY >= 0 ? 1 : -1;

    int diff = Math.Max(Math.Abs(diffX), Math.Abs(diffY));

    for (int i = 0; i <= diff; i++)
    {
        int x = x0 + (i * diffX + mulX * diff / 2) / diff;
        int y = y0 + (i * diffY + mulY * diff / 2) / diff;
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
    FillBox(x, y, x + 4, y + 4, color);
}

void DrawAHouse(int x, int y, ConsoleColor color)
{
    DrawADoor(x + 3, 1, ConsoleColor.DarkRed);
    DrawAWindow(x + 10, 3, ConsoleColor.Gray);
    DrawAWindow(x + 3, 7, ConsoleColor.Gray);
    DrawAWindow(x + 10, 7, ConsoleColor.Gray);
    DrawLine(x - 1, 10, x + 8, 19, ConsoleColor.White);
    DrawLine(x + 9, 19, x + 18, 10, ConsoleColor.White);
    DrawBox(x, 1, x + 17, 11, ConsoleColor.White);
}

Console.WriteLine("Draw a house with our own library ");
Console.WriteLine("**********************************");

Initialize();

DrawLine(0, 0, COLS - 1, 0, ConsoleColor.Green);
DrawAHouse(5, 1, ConsoleColor.White);

DrawAHouse(30, 1, ConsoleColor.White);

Console.ResetColor();
Console.SetCursorPosition(0, ROWS - 1);
Console.WriteLine();