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
    #region print

    const ConsoleColor NUMBER_COLOR   = ConsoleColor.DarkGreen;
    const ConsoleColor POSSIBLE_COLOR = ConsoleColor.Yellow;

    /// <summary>
    ///     Prints the sudoku playing field to the console.
    ///     This allows the user to see which cells have already been filled with a number and which remain empty.
    /// </summary>
    /// <param name="sudoku">The sudoku field to print</param>
    /// <param name="showHelp"></param>
    public static void PrintSudoku(int[,] sudoku, bool showHelp)
    {
        var possibleNos = GetPossibleNumbers(sudoku);

        Console.WriteLine(GetLine(" ", '╔', '═', '╦', '═', '╗'));

        for (int row = 0; row < 9; row++)
        {
            if (row > 0)
            {
                bool is3x3Row = row % 3 == 0;

                if (is3x3Row)
                {
                    Console.WriteLine(GetLine(" ", '╠', '═', '╬', '═', '╣'));
                }
                else
                {
                    Console.WriteLine(GetLine(" ", '║', '┼', '║', '─', '║'));
                }
            }

            PrintLine(sudoku, possibleNos, row, false, showHelp, 1, 2, 3);
            PrintLine(sudoku, possibleNos, row, true,  showHelp, 4, 5, 6);
            PrintLine(sudoku, possibleNos, row, false, showHelp, 7, 8, 9);
        }

        Console.WriteLine(GetLine(" ", '╚', '═', '╩', '═', '╝'));

        for (int col = 0; col < 9; col++)
        {
            Console.Write($"     {(char)('A' + col)}");
        }

        Console.WriteLine();
    }

    private static string GetLine(string pre, char firstCh, char midCh, char mid3x3Ch, char mid, char lastCh)
    {
        string midStr = new string(mid, 5);
        string line   = pre + firstCh + midStr;

        for (int row = 0; row < 8; row++)
        {
            line += row % 3 == 2 ? mid3x3Ch : midCh;
            line += midStr;
        }

        line += lastCh;

        return line;
    }

    private static void PrintLine(int[,] sudoku, int[,][] possibleNos, int row, bool printNo, bool showHelp, int p1, int p2, int p3)
    {
        int side = sudoku.GetLength(0);
        Console.Write($"{(printNo ? (row+1).ToString() : " ")}║");

        for (int col = 0; col < side; col++)
        {
            int number = sudoku[row, col];
            if (number > 0)
            {
                if (printNo)
                {
                    Console.ForegroundColor = NUMBER_COLOR;
                    Console.Write($"  {number}  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("     ");
                }
            }
            else if (showHelp)
            {
                Console.ForegroundColor = POSSIBLE_COLOR;
                Console.Write(
                    $"{GetPossible(possibleNos[row, col], p1)} {GetPossible(possibleNos[row, col], p2)} {GetPossible(possibleNos[row, col], p3)}");
                Console.ResetColor();
            }
            else
            {
                Console.Write("     ");
            }

            Console.Write(col % 3 == 2 ? '║' : '│');
        }

        Console.WriteLine();
    }


    private static string GetPossible(int[] possible, int printNo)
    {
        return CommonTools.Contains(possible, printNo) ? printNo.ToString() : " ";
    }

    #endregion

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
                isValid = !CommonTools.Contains(GetCols(sudoku, col),         no) &&
                          !CommonTools.Contains(GetRows(sudoku, row),         no) &&
                          !CommonTools.Contains(GetSegment(sudoku, row, col), no);
            }

            if (isValid)
            {
                sudoku[row, col] = no;
            }
        }

        return isValid;
    }

    /// <summary>
    /// Calculate the possible numbers for each field.
    /// Possible numbers are the numbers which are not in the column, row or segment.
    /// </summary>
    /// <param name="sudoku"></param>
    /// <returns></returns>
    public static int[,][] GetPossibleNumbers(int[,] sudoku)
    {
        var result          = new int[9, 9][];
        var allValidNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku[row, col] == 0)
                {
                    var validNoRowColSegment = new int[][]
                    {
                        CommonTools.Except(allValidNumbers, GetCols(sudoku, col)),
                        CommonTools.Except(allValidNumbers, GetRows(sudoku, row)),
                        CommonTools.Except(allValidNumbers, GetSegment(sudoku, row, col)),
                    };

                    var validFieldNos = allValidNumbers;
                    foreach (var valid in validNoRowColSegment)
                    {
                        validFieldNos = CommonTools.Intersect(valid, validFieldNos);
                    }

                    result[row, col] = validFieldNos;
                }
            }
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

    private static void ConvertToSegment(int row, int col, out int rowSegment, out int colSegment)
    {
        var rowX3 = (row / 3) * 3;
        var colX3 = (row % 3) * 3;

        var dRow = col / 3;
        var dCol = col % 3;

        rowSegment = rowX3 + dRow;
        colSegment = colX3 + dCol;
    }

    private static void ConvertFromSegment(int rowSegment, int colSegment, out int row, out int col)
    {
        row = (rowSegment / 3) * 3 + colSegment / 3;
        col = (rowSegment % 3) * 3 + (colSegment % 3);
    }
}