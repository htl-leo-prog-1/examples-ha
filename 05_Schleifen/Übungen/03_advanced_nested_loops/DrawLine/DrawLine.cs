/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: DrawLine
 * Draw a line from on point to an other
 *--------------------------------------------------------------
 */

using System;

Console.WriteLine("Draw a line");
Console.WriteLine("************************");

Console.Write("Please enter start position x: ");
int x1 = int.Parse(Console.ReadLine());

Console.Write("Please enter start position y: ");
int y1 = int.Parse(Console.ReadLine());

Console.Write("Please enter end position x: ");
int x2 = int.Parse(Console.ReadLine());

Console.Write("Please enter end position y: ");
int y2 = int.Parse(Console.ReadLine());

const int MAX_X = 80;
const int MAX_Y = 25;

Console.SetWindowSize(MAX_X, MAX_Y);
Console.Clear();

//draw grid x

Console.SetCursorPosition(0, 0);
Console.Write('0');
for (int x = 1; x < MAX_X; x++)
{
    if (x % 10 == 0)
    {
        Console.Write($"{x / 10}");
    }
    else if (x % 5 == 0)
    {
        Console.Write($"{x % 10}");
    }
    else
    {
        Console.Write('-');
    }
}

//draw grid y

for (int y = 1; y < MAX_Y; y++)
{
    Console.SetCursorPosition(0, y);
    if (y % 5 == 0)
    {
        Console.Write($"{y % 10}");
    }
    else
    {
        Console.Write('|');
    }
}

// draw line

int diffX = x2 - x1;
int diffY = y2 - y1;

int diff = Math.Max(Math.Abs(diffX), Math.Abs(diffY));

int mulX = diffX >= 0 ? 1 : -1;
int mulY = diffY >= 0 ? 1 : -1;
int roundX = mulX * diff / 2;
int roundY = mulY * diff / 2;

for (int i = 0; i <= diff; i++)
{
    int x = x1 + (i * diffX + roundX) / diff;
    int y = y1 + (i * diffY + roundY) / diff;

    Console.SetCursorPosition(x, y);
    Console.Write('*');
}

Console.SetCursorPosition(0, MAX_Y - 1);
Console.WriteLine();