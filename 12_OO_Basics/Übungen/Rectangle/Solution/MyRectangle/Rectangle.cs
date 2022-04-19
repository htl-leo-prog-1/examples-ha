/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Rectangle
*--------------------------------------------------------------
*/

namespace MyRectangle
{
    using System;

    public class Rectangle
    {
        private ConsoleColor _color = ConsoleColor.White;
        private int _x;
        private int _y;
        private char _drawChar = '#';

        public Rectangle()
        {
            Width = 1;
            Length = 1;
        }

        public Rectangle(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public Rectangle(int width, int length, ConsoleColor color, int x, int y)
        {
            Width = width;
            Length = length;
            _color = color;
            _x = x;
            _y = y;
        }

        public int Width { get; set; }
        public int Length { get; set; }

        public int Perimeter
        {
            get { return Length * 2 + Width * 2; }
        }

        public int Area
        {
            get { return Length * Width; }
        }

        public int CompareTo(Rectangle other)
        {
            if (Area < other.Area)
            {
                return -1;
            }

            if (Area > other.Area)
            {
                return 1;
            }

            return 0;
        }

        public void Draw()
        {
            ConsoleColor backup = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            for (int row = 0; row < Length; row++)
            {
                Console.SetCursorPosition(_x, _y + row);
                for (int col = 0; col < Width; col++)
                {
                    Console.Write(_drawChar);
                }
            }

            Console.ForegroundColor = backup;
        }

        public void Rotate()
        {
            var temp = Length;
            Length = Width;
            Width = temp;
        }

        public void Scale(double faktor)
        {
            Length = (int) (Length * faktor + 0.5);
            Width = (int) (Width * faktor + 0.5);
        }
    }
}