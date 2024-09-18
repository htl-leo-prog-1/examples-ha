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
using System.Threading.Tasks;
using Avalonia.Media;

using SimpleXPlatDrawing;

const int COLS = 997;
const int ROWS = 273;

void Initialize()
{
    SimpleDrawing.Init(COLS, ROWS);
}

void Terminate()
{
}

void DrawDot(int x, int y, IBrush color)
{
    DrawChar(x,y,'*',color);
}

void DrawChar(int x, int y, char ch, IBrush color)
{
    SimpleDrawing.DrawText(new(x, y), ch.ToString(), 10, color);
}

async Task  AnimationPingPong()
{
    int delayInMs = 100;

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

        DrawDot(x, y, Brushes.Red);
        Thread.Sleep(TimeSpan.FromMilliseconds(delayInMs));
        DrawDot(x, y, Brushes.White);
        await SimpleDrawing.Render();
    }
}

Initialize();
await AnimationPingPong();
Terminate();
