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
        throw new NotImplementedException();
    }

    #endregion

    /// <summary>
    /// Test if the sudoku is finished, if all fields are different to 0
    /// </summary>
    /// <param name="sudoku"></param>
    /// <returns></returns>
    public static bool IsSudokuComplete(int[,] sudoku)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    /// <summary>
    /// Calculate the possible numbers for each field.
    /// Possible numbers are the numbers which are not in the column, row or segment.
    /// </summary>
    /// <param name="sudoku"></param>
    /// <returns></returns>
    public static int[,][] GetPossibleNumbers(int[,] sudoku)
    {
        throw new NotImplementedException();
    }

    // private static int[] GetCols(int[,] sudoku, int col)
    // private static int[] GetRows(int[,] sudoku, int row)
    // private static int[] GetSegment(int[,] sudoku, int row, int col)
}