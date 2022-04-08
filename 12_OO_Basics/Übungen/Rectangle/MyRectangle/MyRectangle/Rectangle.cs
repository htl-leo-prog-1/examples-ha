using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRectangle
{
    public class Rectangle
    {
        private int _width;
        private int _length;
        private ConsoleColor _color = ConsoleColor.White;
        private int _x;
        private int _y;
        private char _drawChar = '#';

        public Rectangle()
        {
            _width = 1;
            _length = 1;
        }

        public Rectangle(int width, int length)
        {
            _width = width;
            _length = length;
        }

        public Rectangle(int width, int length, ConsoleColor color, int x, int y)
        {
            this._width = width;
            this._length = length;
            this._color = color;
            this._x = x;
            this._y = y;
        }

        public void SetWidth(int width)
        {
            this._width = width;
        }

        public void SetLength(int length)
        {
            this._length = length;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetLength()
        {
            return _length;
        }

        public int GetPerimeter()
        {
            return _length * 2 + _width * 2;
        }

        public int GetArea()
        {
            return _length * _width;
        }

        public int CompareTo(Rectangle other)
        {
            if (this.GetArea() < other.GetArea())
            {
                return -1;
            }
            if (this.GetArea() > other.GetArea())
            {
                return 1;
            }
            return 0;
        }

        public void Draw()
        {
            ConsoleColor backup = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            for (int row = 0; row < _length; row++ )
            {
                Console.SetCursorPosition(_x, _y + row);
                for (int col = 0; col < _width; col++)
                {
                    Console.Write(_drawChar);
                }                   
            }
            Console.ForegroundColor = backup;
        }

        public void Rotate()
        {
            int temp = _length;
            _length = _width;
            _width = temp;
        }

        public void Scale(int faktor)
        {
            _length *= faktor;
            _width *= faktor;
        }
    }
}
