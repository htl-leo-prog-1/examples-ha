/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: PingPong
*--------------------------------------------------------------
*/

using System;

const int COLS = 80;
const int ROWS = 25;

Console.WriteLine("Snake");
Console.WriteLine("****************************");

Console.Write("Number of snakes: ");
int snakeCount = int.Parse(Console.ReadLine());

AnimatePingPong(snakeCount);


void AnimatePingPong(int snakeCount)
{
    ConsoleGraphics.Initialize();

    var rnd = new Random();

    var snakes = new Snake[snakeCount];
    for (int i = 0; i < snakes.Length; i++)
    {
        snakes[i] = new Snake();
        snakes[i].Init(COLS, ROWS, ConsoleColor.DarkYellow, rnd.Next(30, 100));
    }

    ConsoleGraphics.FillBox(0, 0, COLS - 1, ROWS - 1, '.', ConsoleColor.DarkGray);

    while (!Console.KeyAvailable)
    {
        foreach (var snake in snakes)
        {
            snake.Loop();
        }
    }

    ConsoleGraphics.Terminate();
}

class ConsoleGraphics
{
    const int _width = 80;
    const int _height = 25;

    public static void Initialize()
    {
        Console.SetWindowSize(_width, _height);
        Console.CursorVisible = false;
    }

    public static void Terminate()
    {
        Console.ResetColor();
        Console.SetCursorPosition(0, _height - 1);
        Console.WriteLine();
        Console.CursorVisible = true;
    }

    public static void DrawChar(int x, int y, char ch, ConsoleColor color)
    {
        Console.SetCursorPosition(x, _height - y - 1);
        Console.ForegroundColor = color;
        Console.Write(ch);
    }

    public static void DrawDot(int x, int y, ConsoleColor color)
    {
        DrawChar(x, y, '*', color);
    }

    public static void DrawLine(int x0, int y0, int x1, int y1, ConsoleColor color)
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

    public static void DrawBox(int x0, int y0, int x1, int y1, ConsoleColor color)
    {
        DrawLine(x0, y0, x1, y0, color);
        DrawLine(x1, y0, x1, y1, color);
        DrawLine(x1, y1, x0, y1, color);
        DrawLine(x0, y1, x0, y0, color);
    }

    public static void FillBox(int x0, int y0, int x1, int y1, char ch, ConsoleColor color)
    {
        int xStart = Math.Min(x0, x1);
        int xEnd = Math.Max(x0, x1);

        int yStart = Math.Min(y0, y1);
        int yEnd = Math.Max(y0, y1);

        for (int x = xStart; x <= xEnd; x++)
        {
            for (int y = yStart; y <= yEnd; y++)
            {
                DrawChar(x, y, ch, color);
            }
        }
    }

    public static ConsoleColor RgbToConsoleColor(int R, int G, int B)
    {
        int index = (R > 128 | G > 128 | B > 128) ? 8 : 0;
        index |= (R > 64) ? 4 : 0;
        index |= (G > 64) ? 2 : 0;
        index |= (B > 64) ? 1 : 0;
        return (System.ConsoleColor) index;
    }
}

class Snake
{
    const int SNAKELENGTH = 10;
    const int RANDOMXY = 4;

    static int NextPos(ref int pos, ref int d, int MAXSIZE)
    {
        pos += d;

        if (pos >= MAXSIZE)
        {
            d = -1;
            pos = MAXSIZE - 2;
            return 1;
        }

        if (pos < 0)
        {
            d = 1;
            pos = 1;
            return -1;
        }

        return 0;
    }

    private static Random _random = new Random();

    ConsoleColor[] _cols = new ConsoleColor[SNAKELENGTH];
    int[] _last = new int[SNAKELENGTH];

    private ConsoleColor _snakeColorTail;
    int _x = -1;
    int _y = -1;
    int _dx = 1;
    int _dy = 1;
    int _width;
    int _height;

    int _nextTime;

    int _lastidx = 0;
    int _delay;
    int _delay2;

    private int RandomNextD() => _random.Next(0, 2) == 0 ? 1 : -1;
    private bool RandomNextDis0() => _random.Next(0, RANDOMXY) == 0;

    void CalcNextPos()
    {
        int lastx = _x;
        int lasty = _y;

        int res = NextPos(ref _x, ref _dx, _width);
        if (res != 0)
        {
            if (_dy == 0)
            {
                _dy = RandomNextD();
            }
            else if (RandomNextDis0())
            {
                _dy = 0;
            }
        }

        res = NextPos(ref _y, ref _dy, _height);
        if (res != 0)
        {
            if (_dx == 0)
            {
                _dx = RandomNextD();
                NextPos(ref _x, ref _dx, _width);
            }
            else if (RandomNextDis0())
            {
                _x = lastx;
                _dx = 0;
            }
        }
    }

    public void Init(int w, int h, ConsoleColor setColor, int delay)
    {
        _delay = delay;
        _delay2 = (int) (((uint) delay * 100) / 141);
        _height = h;
        _width = w;

        int colrgb = 255;

        _x = _random.Next(0, w);
        _y = _random.Next(0, h);

        int j = 0;

        _cols[j++] = ConsoleGraphics.RgbToConsoleColor(255, 0, 0);
        _cols[j++] = ConsoleGraphics.RgbToConsoleColor(0, 0, 255);

        while (j < SNAKELENGTH - 2)
        {
            _cols[j++] = ConsoleGraphics.RgbToConsoleColor(colrgb - 1, colrgb - 1, colrgb - 1);
            colrgb = Math.Max(colrgb - 20, 31);
        }

        _cols[j++] = ConsoleGraphics.RgbToConsoleColor(0, 255, 0);
        _cols[j++] = setColor;
        _snakeColorTail = setColor;

        for (j = 0; j < SNAKELENGTH - 1; j++)
        {
            _last[j] = -1;
        }

        _nextTime = Environment.TickCount;
    }

    void Restart()
    {
        _nextTime = Environment.TickCount;
    }

    public bool Loop()
    {
        if (_nextTime > Environment.TickCount)
        {
            return false;
        }

        CalcNextPos();

        _nextTime += (_dx == 0 || _dy == 0) ? _delay2 : _delay;

        _last[_lastidx] = _x + _y * _width;
        _lastidx = (_lastidx + 1) % SNAKELENGTH;

        for (int j = 0; j < SNAKELENGTH; j++)
        {
            int idx = _last[(_lastidx + j) % SNAKELENGTH];
            if (idx != -1)
            {
                int x = idx % _width;
                int y = idx / _width;
                var color = _cols[SNAKELENGTH - 1 - j];

                if (color == _snakeColorTail)
                {
                    ConsoleGraphics.DrawChar(x, y, ' ', color);
                }
                else
                {
                    ConsoleGraphics.DrawDot(x, y, color);
                }
            }
        }

        return true;
    }
}