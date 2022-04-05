/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sudoku
*--------------------------------------------------------------
*/

namespace Sudoku;

using System;

public static class Sudoku
{
    /// <summary>
    ///     Prints the sudoku playing field to the console.
    ///     This allows the user to see which cells have already been filled with a number and which remain empty.
    /// </summary>
    /// <param name="sudoku">The sudoku field to print</param>
    public static void PrintSudoku(int[,] sudoku)
    {
        const ConsoleColor NUMBER_COLOR = ConsoleColor.DarkGreen;

        int side = sudoku.GetLength(0);

        Console.WriteLine(GetLine(" ", '╔', '═', '╦', '═', '╗'));

        for (int row = 0; row < side; row++)
        {
            bool is3x3Row = row % 3 == 0;
            if (row > 0)
            {
                if (is3x3Row)
                {
                    Console.WriteLine(GetLine(" ", '╠', '═', '╬', '═', '╣'));
                }
                else
                {
                    Console.WriteLine(GetLine(" ", '║', '┼', '║', '─', '║'));
                }
            }

            Console.Write($"{row + 1}║");
            for (int col = 0; col < side; col++)
            {
                int number = sudoku[row, col];
                if (number > 0)
                {
                    Console.ForegroundColor = NUMBER_COLOR;
                    Console.Write($" {number} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                }

                Console.Write(col % 3 == 2 ? '║' : '│');
            }

            Console.WriteLine();
        }

        Console.WriteLine(GetLine(" ", '╚', '═', '╩', '═', '╝'));

        for (int col = 0; col < side; col++)
        {
            Console.Write($"   {(char) ('A' + col)}");
        }

        Console.WriteLine();
    }

    private static string GetLine(string pre, char firstCh, char midCh, char mid3x3Ch, char mid, char lastCh)
    {
        string midStr = new string(mid, 3);
        string line = pre + firstCh + midStr;

        for (int row = 0; row < 8; row++)
        {
            line += row % 3 == 2 ? mid3x3Ch : midCh;
            line += midStr;
        }

        line += lastCh;

        return line;
    }

    /// <summary>
    /// Test if the sudoku is finished, if all fields are different to 0
    /// </summary>
    /// <param name="sudoku"></param>
    /// <returns></returns>
    public static bool IsSudokuComplete(int[,] sudoku)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku[row, col] == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Try to set the specified field.
    /// Use no with 0 to clear the field.
    /// </summary>
    /// <param name="sudoku"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="no"></param>
    /// <returns>true if succeeded, false if not valid</returns>
    public static bool SetField(int[,] sudoku, int row, int col, int no)
    {
        bool isValid = no >= 0 && no <= 9;

        if (isValid)
        {
            if (no > 0)
            {
                isValid = !Contains(GetCols(sudoku, col), no) &&
                          !Contains(GetRows(sudoku, row), no) &&
                          !Contains(GetSegment(sudoku, row, col), no);
            }

            if (isValid)
            {
                sudoku[row, col] = no;
            }
        }

        return isValid;
    }

    public static int[,][] GetPossibleNumbers(int[,] sudoku)
    {
        var result = new int[9, 9][];
        var validNos = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku[row, col] == 0)
                {
                    var allValidNos = new int[][]
                    {
                        Except(validNos, GetCols(sudoku, col)),
                        Except(validNos, GetRows(sudoku, row)),
                        Except(validNos, GetSegment(sudoku, row, col)),
                    };

                    var validFieldNos = validNos;
                    foreach (var valid in allValidNos)
                    {
                        validFieldNos = Intersect(valid, validFieldNos);
                    }

                    result[row, col] = validFieldNos;
                }
            }
        }

        return result;
    }

    public static int[] Intersect(int[] numbersA, int[] numbersB)
    {
        var result = new int[numbersA.Length];
        int count = 0;

        for (int i = 0; i < numbersA.Length; i++)
        {
            if (!Contains(numbersA, numbersA[i], i) && Contains(numbersB, numbersA[i]))
            {
                result[count] = numbersA[i];
                count++;
            }
        }

        return CopyArray(result, count);
    }

    private static bool Contains(int[] ar, int value)
    {
        foreach (var val in ar)
        {
            if (value == val)
            {
                return true;
            }
        }

        return false;
    }

    private static bool Contains(int[] ar, int value, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (value == ar[i])
            {
                return true;
            }
        }

        return false;
    }

    private static int[] Except(int[] from, int[] except)
    {
        var result = new int[from.Length];
        int count = 0;

        foreach (var val in from)
        {
            if (!Contains(except, val))
            {
                result[count] = val;
                count++;
            }
        }

        return CopyArray(result, count);
    }

    private static int[] CopyArray(int[] ar, int length)
    {
        var result = new int[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = ar[i];
        }

        return result;
    }

    private static int[] GetCols(int[,] sudoku, int col)
    {
        var cols = new int[9];
        for (int row = 0; row < 9; row++)
        {
            cols[row] = sudoku[row, col];
        }

        return cols;
    }

    private static int[] GetRows(int[,] sudoku, int row)
    {
        var rows = new int[9];
        for (int col = 0; col < 9; col++)
        {
            rows[col] = sudoku[row, col];
        }

        return rows;
    }

    private static int[] GetSegment(int[,] sudoku, int row, int col)
    {
        int rowSegment;
        int colSegment;

        ConvertToSegment(row, col, out rowSegment, out colSegment);

        var segment = new int[9];
        for (colSegment = 0; colSegment < 9; colSegment++)
        {
            ConvertFromSegment(rowSegment, colSegment, out row, out col);
            segment[colSegment] = sudoku[row, col];
        }

        return segment;
    }

    public static void ConvertToSegment(int row, int col, out int rowSegment, out int colSegment)
    {
        var rowX3 = (row / 3) * 3;
        var colX3 = (row % 3) * 3;

        var dRow = col / 3;
        var dCol = col % 3;

        rowSegment = rowX3 + dRow;
        colSegment = colX3 + dCol;
    }

    public static void ConvertFromSegment(int rowSegment, int colSegment, out int row, out int col)
    {
        row = (rowSegment / 3) * 3 + colSegment / 3;
        col = (rowSegment % 3) * 3 + (colSegment % 3);
    }
}