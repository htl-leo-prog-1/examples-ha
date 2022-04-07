using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometrie
{
    class Program
    {
        private const int FIELD_SIZE = 20;
        private const string FRAME = "■";
        private const string CIRCLE = "●";
        static void Main(string[] args)
        {
            Console.WriteLine("Geometrie");
            Console.WriteLine("=========");

            Board.Init(FIELD_SIZE, FIELD_SIZE, "Geometrie");
            (int width, int height) = ReadSize();

            while (width > 0 && height > 0)
            {
                Board.Clear();
                if (width == height)
                {
                    DrawSquare(width);
                }
                else
                {
                    DrawRectangle(width, height);
                }
                
                Console.WriteLine("\n\nNächstes Viereck: ");
                (width, height) = ReadSize();

            }


            Console.WriteLine("Taste drücken zum Beenden ...");
            Console.ReadKey();
            
        }

        private static (int, int) ReadSize()
        {
            Console.Write("Wie breit soll das Viereck sein? ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Wie hoch soll das Viereck sein? ");
            int height = Convert.ToInt32(Console.ReadLine());
            return (width, height);
        }

        private static void DrawSquare(int size)
        {
            int offset = (FIELD_SIZE - size) / 2;

            for (int row = offset; row < offset + size; row++)
            {
                if (row == offset || row == offset + size - 1)
                {
                    for (int col = offset; col < offset + size; col++)
                    {
                        Board.SetText(row, col, FRAME);
                    }
                }
                else
                {
                    for (int col = offset; col < offset + size; col++)
                    {
                        if (col == offset || col == offset + size - 1)
                        {
                            Board.SetText(row, col, FRAME);
                        }
                        else
                        {
                            if (row == col)
                            {
                                Board.SetText(row, col, "X", "Red");
                            }
                            else if ((row == (FIELD_SIZE - col - 1)) || (col == (FIELD_SIZE  - row - 1)))
                            {
                                Board.SetText(row, col, "X", "Red");
                            }
                            else
                            {
                                Board.SetText(row, col, CIRCLE, "Green");
                            }
                        }
                    }
                }

            }
        }

        private static void DrawRectangleSimple(int width, int height)
        {
            int colOffset = 0;
            int rowOffset = 0;
            for (int row = rowOffset; row < rowOffset + height; row++)
            {
                if (row == rowOffset || row == rowOffset + height - 1)
                {
                    for (int col = colOffset; col < colOffset + width; col++)
                    {
                        Board.SetText(row, col, FRAME);
                    }
                }
                else
                {
                    for (int col = colOffset; col < colOffset + width; col++)
                    {
                        if (col == colOffset || col == colOffset + width - 1)
                        {
                            Board.SetText(row, col, FRAME);
                        }
                        else
                        {
                            Board.SetText(row, col, CIRCLE, "Green");
                        }
                    }
                }

            }
        }

        private static void DrawRectangle(int width, int height)
        {
            int colOffset = (FIELD_SIZE - width) / 2;
            int rowOffset = (FIELD_SIZE - height) / 2;
            for (int row = rowOffset; row < rowOffset + height; row++)
            {
                if (row == rowOffset || row == rowOffset + height - 1)
                {
                    for (int col = colOffset; col < colOffset + width; col++)
                    {
                        Board.SetText(row, col, FRAME);
                    }
                }
                else
                {
                    for (int col = colOffset; col < colOffset + width; col++)
                    {
                        if (col == colOffset || col == colOffset + width - 1)
                        {
                            Board.SetText(row, col, FRAME);
                        }
                        else
                        {
                            Board.SetText(row, col, CIRCLE, "Green");
                        }
                    }
                }
                
            }
        }
    }
}
