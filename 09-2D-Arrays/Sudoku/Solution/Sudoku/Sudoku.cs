/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-MK
*--------------------------------------------------------------
* Description: Sudoku
*--------------------------------------------------------------
*/

namespace Sudoku;

using System;

public static class Sudoku
{
    private const int SIDE = 9;
    private const int SEGMENT = 3;
    private const int X_DIM = 0;
    private const int Y_DIM = 1;

    private static readonly int[,] sudokuStartState =
    {
        {0, 0, 1, 2, 0, 0, 8, 7, 0},
        {0, 0, 6, 0, 8, 0, 0, 2, 4},
        {0, 8, 0, 0, 7, 3, 0, 0, 5},
        {6, 2, 0, 1, 3, 0, 0, 8, 0},
        {8, 0, 0, 9, 4, 0, 0, 5, 2},
        {5, 9, 4, 0, 0, 8, 3, 0, 6},
        {3, 0, 9, 0, 0, 0, 5, 4, 0},
        {1, 0, 0, 0, 9, 0, 2, 0, 8},
        {0, 0, 0, 0, 5, 7, 0, 0, 0}
    };

    /// <summary>
    ///     Executes the sudoku program.
    /// </summary>
    public static void Run()
    {
        int[,] sudoku = Clone2DArray(sudokuStartState);

        while (!IsSudokuComplete(sudoku))
        {
            PrintSudokuField(sudoku);
            int[] number = EnterNumber(sudoku);

            if (!IsSudokuValid(SetNumberDryRun(sudoku, number)))
            {
                Console.WriteLine("The number you entered is not valid (at this position)!");
                if (!AskContinueGame())
                {
                    break;
                }

                continue;
            }

            SetNumber(sudoku, number);
        }

        if (IsSudokuComplete(sudoku))
        {
            Console.WriteLine("Congratulations, you did it!");
            PrintSudokuField(sudoku);
            return;
        }

        Console.WriteLine("Better luck next time!");
    }

    /// <summary>
    ///     If the user entered an invalid number this method is used to ask them if they want to end the game or continue.
    ///     Only 'y' (yes) and 'n'(no) are allowed inputs.
    /// </summary>
    /// <returns>True if the user entered 'y'; false otherwise</returns>
    private static bool AskContinueGame()
    {
        const char YES = 'y';
        const char NO = 'n';
        const char INVALID = '?';

        char choice;
        do
        {
            Console.Write("Do you want to continue the game (y/n)? ");
            string? input = Console.ReadLine();
            choice = input != null ? input[0] : INVALID;
        } while (choice != YES && choice != NO);

        return choice == YES;
    }

    /// <summary>
    ///     Reads a number and its position from the console.
    ///     The number has to be in the range of possible numbers (e.g. 1-9).
    ///     This method does not verify if the number is already present in a sequence, which would lead to a duplicate.
    ///     The position is given as row and column (1 based), identifying the cell in which the number should be placed.
    /// </summary>
    /// <param name="sudoku">The sudoku playing field</param>
    /// <returns>An array containing (in order) row, column and number</returns>
    private static int[] EnterNumber(int[,] sudoku)
    {
        int rowColRangeStart = 1;
        int rowColRangeEnd = sudoku.GetLength(X_DIM);
        int selectedRow = ReadNumberInRange("selected row", rowColRangeStart, rowColRangeEnd);
        int selectedCol = ReadNumberInRange("selected col", rowColRangeStart, rowColRangeEnd);
        int number = ReadNumberInRange("number to enter", 1, SIDE);

        return new[] {selectedRow, selectedCol, number};
    }

    /// <summary>
    ///     Read a valid number in the given range from the console (the user).
    ///     If the range start & end parameters are passed in the wrong order the method will correct for it.
    /// </summary>
    /// <param name="valueName">Name of the value to read</param>
    /// <param name="rangeStart">Lowest possible value</param>
    /// <param name="rangeEnd">Highest possible value</param>
    /// <returns>The valid number read from the console.</returns>
    private static int ReadNumberInRange(string valueName, int rangeStart, int rangeEnd)
    {
        if (rangeEnd < rangeStart)
        {
            (rangeStart, rangeEnd) = (rangeEnd, rangeStart);
        }

        int number;
        do
        {
            Console.Write($"Enter {valueName} in range [{rangeStart},{rangeEnd}]: ");
            if (!int.TryParse(Console.ReadLine(), out number) || number < rangeStart || number > rangeEnd)
            {
                Console.WriteLine("Invalid input, try again...");
                number = rangeStart - 1;
            }
        } while (number < rangeStart);

        return number;
    }

    /// <summary>
    ///     Prints the sudoku playing field to the console.
    ///     This allows the user to see which cells have already been filled with a number and which remain empty.
    /// </summary>
    /// <param name="sudoku">The sudoku field to print</param>
    private static void PrintSudokuField(int[,] sudoku)
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
            Console.Write($"   {col + 1}");
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
    ///     Sets a number in a 2D array similar to <see cref="SetNumber"/> but performs this operation on a copy.
    ///     This copy is returned.
    ///     The purpose is to test the result of a number set operation in a sudoku field without altering the
    ///     original playing field.
    /// </summary>
    /// <param name="sudoku">The sudoku on which the copy is based in which the value will be set</param>
    /// <param name="number">The number to set together with position (row & col)</param>
    /// <returns>The copy of the 2D array with the number set - if possible, otherwise an unchanged copy of the passed 2D array</returns>
    public static int[,] SetNumberDryRun(int[,] sudoku, int[] number)
    {
        int[,] copy = Clone2DArray(sudoku);
        SetNumber(copy, number);
        return copy;
    }

    /// <summary>
    ///     Sets a number in a provided 2D array.
    ///     The number to set is defined by the <see cref="number"/> parameters which
    ///     contains row & column (1 index based) and the value to set - in that order.
    /// </summary>
    /// <param name="sudoku">The sudoku in which the value will be set</param>
    /// <param name="number">The value and its position</param>
    /// <returns>True if the value was set successfully; false if the value cannot be set (position out of range)</returns>
    public static bool SetNumber(int[,] sudoku, int[] number)
    {
        int row = number[0] - 1;
        int col = number[1] - 1;

        if ((row < 0 || row >= sudoku.GetLength(Y_DIM))
            || (col < 0 || col >= sudoku.GetLength(X_DIM)))
        {
            return false;
        }

        sudoku[row, col] = number[2];
        return true;
    }

    /// <summary>
    ///     Checks if the given sudoku is complete.
    /// </summary>
    /// <param name="sudoku">The sudoku 2D array to check</param>
    /// <returns>True if the sudoku is complete; false otherwise</returns>
    public static bool IsSudokuComplete(int[,] sudoku)
    {
        return CheckSudoku(sudoku, false);
    }

    /// <summary>
    ///     Checks if the given sudoku is valid.
    /// </summary>
    /// <param name="sudoku">The sudoku 2D array to check</param>
    /// <returns>True if the sudoku is valid; false otherwise</returns>
    public static bool IsSudokuValid(int[,] sudoku)
    {
        return CheckSudoku(sudoku, true);
    }

    /// <summary>
    ///     Checks a given sudoku 2D array for either validity or completeness.
    /// </summary>
    /// <param name="sudoku">The sudoku to check</param>
    /// <param name="checkValid">A flag indicating if the check should be for validity (true) or completeness (false)</param>
    /// <returns>True if the sudoku is valid/complete; false otherwise</returns>
    public static bool CheckSudoku(int[,] sudoku, bool checkValid)
    {
        int length = sudoku.GetLength(X_DIM);
        if (length != sudoku.GetLength(Y_DIM) || length != SIDE)
        {
            return false;
        }

        if (!CheckSequences(sudoku, checkValid)
            || !CheckSegments(sudoku, checkValid, length))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Converts the 2D array into an array containing every row and column (first rows, then columns).
    /// </summary>
    /// <param name="sudoku">The 2D array to process</param>
    /// <returns>An array containing the rows and columns</returns>
    public static int[][] GetRowsAndColumns(int[,] sudoku)
    {
        int rows = sudoku.GetLength(Y_DIM);
        int columns = sudoku.GetLength(X_DIM);
        int totalSequences = rows + columns;
        int[][] rowsAndColumns = new int[totalSequences][];

        for (int r = 0; r < rows; r++)
        {
            int[] row = new int[columns];
            for (int c = 0; c < columns; c++)
            {
                row[c] = sudoku[r, c];
            }

            rowsAndColumns[r] = row;
        }

        for (int c = 0; c < columns; c++)
        {
            int[] column = new int[rows];
            for (int r = 0; r < rows; r++)
            {
                column[r] = sudoku[r, c];
            }

            rowsAndColumns[c + rows] = column;
        }

        return rowsAndColumns;
    }

    /// <summary>
    ///     Checks if a segment of the sudoku is valid.
    ///     Validity is defined as it containing no duplicates and only meaningful numbers (e.g. for a 3x3 segment 1-9 or 0).
    /// </summary>
    /// <param name="sudoku">The sudoku field</param>
    /// <param name="startRow">Start row of the segment (0 based)</param>
    /// <param name="startColumn">Start column of the segment (0 based)</param>
    /// <param name="sideLength">The side length of the segment</param>
    /// <returns>True if the segment is complete; false otherwise</returns>
    public static bool IsSegmentValid(int[,] sudoku, int startRow, int startColumn, int sideLength)
    {
        return IsSequenceValid(GetNumbersInSegment(sudoku, startRow, startColumn, sideLength));
    }

    /// <summary>
    ///     Checks if a segment of the sudoku is complete.
    ///     Completeness is defined as it containing all expected numbers (e.g. for a 3x3 segment 1-9).
    ///     Duplicates can implicitly not occur.
    /// </summary>
    /// <param name="sudoku">The sudoku field</param>
    /// <param name="startRow">Start row of the segment (0 based)</param>
    /// <param name="startColumn">Start column of the segment (0 based)</param>
    /// <param name="sideLength">The side length of the segment</param>
    /// <returns>True if the segment is complete; false otherwise</returns>
    public static bool IsSegmentComplete(int[,] sudoku, int startRow, int startColumn, int sideLength)
    {
        return IsSequenceComplete(GetNumbersInSegment(sudoku, startRow, startColumn, sideLength));
    }

    /// <summary>
    ///     Retrieves all numbers in a specific segment of the sudoku.
    ///     The segment is defined by the starting row & column (left upper corner) and the side length of the segment.
    /// </summary>
    /// <param name="sudoku">The sudoku field</param>
    /// <param name="startRow">Start row of the segment (0 based)</param>
    /// <param name="startColumn">Start column of the segment (0 based)</param>
    /// <param name="sideLength">The side length of the segment</param>
    /// <returns>All numbers contained in the segment, may contain duplicates and 0</returns>
    public static int[] GetNumbersInSegment(int[,] sudoku, int startRow, int startColumn, int sideLength)
    {
        int[] containedNumbers = CreateArrayToContainSegmentNumbers(sideLength);
        int containedIndex = 0;
        for (int row = startRow; row < startRow + sideLength; row++)
        {
            for (int column = startColumn; column < startColumn + sideLength; column++)
            {
                containedNumbers[containedIndex++] = sudoku[row, column];
            }
        }

        return containedNumbers;
    }

    /// <summary>
    ///     Creates an array of sufficient size to contain all numbers in a segment of the sudoku.
    /// </summary>
    /// <param name="sideLength">Side length of a segment</param>
    /// <returns>An array of sufficient size to hold all numbers in the segment</returns>
    public static int[] CreateArrayToContainSegmentNumbers(int sideLength)
    {
        int maxValue = sideLength * sideLength;
        return new int[maxValue];
    }

    /// <summary>
    ///     Verifies if the given sequence (array) is complete.
    ///     Completeness is defined as containing every number from 1..sequence.Length.
    ///     Duplicate numbers must implicitly not occur.
    /// </summary>
    /// <param name="sequence">The sequence to check</param>
    /// <returns>True if the sequence contains all required numbers; false otherwise</returns>
    public static bool IsSequenceComplete(int[] sequence)
    {
        for (int i = 1; i <= sequence.Length; i++)
        {
            if (!ContainsExceptZero(sequence, i))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Verifies if the given sequence does not contain duplicate numbers.
    ///     It may also only contain 0 or numbers in the range 1..sequence.Length.
    /// </summary>
    /// <param name="sequence">Sequence to check</param>
    /// <returns>True if the sequence does not contain duplicate numbers; false otherwise</returns>
    public static bool IsSequenceValid(int[] sequence)
    {
        int containedIdx = 0;
        int[] containedNumbers = new int[sequence.Length];
        foreach (var number in sequence)
        {
            if (ContainsExceptZero(containedNumbers, number))
            {
                return false;
            }

            containedNumbers[containedIdx++] = number;
        }

        foreach (var number in containedNumbers)
        {
            if (number < 0 || number > sequence.Length)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Checks if the passed array contains the passed number.
    ///     If the number is 0 this method always returns false, effectively ignoring zeros in the array.
    /// </summary>
    /// <param name="array">The array containing numbers</param>
    /// <param name="number">The number for which should be evaluated if it is contained in the array</param>
    /// <returns>True if the number is contained; false otherwise - always false for 0</returns>
    public static bool ContainsExceptZero(int[] array, int number)
    {
        if (number == 0)
        {
            return false;
        }

        foreach (int n in array)
        {
            if (n == number)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Creates a deep copy of a 2D array.
    /// </summary>
    /// <param name="array">The array to clone</param>
    /// <returns>The cloned array</returns>
    private static int[,] Clone2DArray(int[,] array)
    {
        int[,] copy = (array.Clone() as int[,])!;
        return copy;
    }

    private static bool CheckSegments(int[,] sudoku, bool checkValid, int length)
    {
        int segColIdx = 0;
        int segRowIdx = 0;
        while (segColIdx < length)
        {
            if (segRowIdx >= SIDE)
            {
                segRowIdx = 0;
                segColIdx += SEGMENT;
                if (segColIdx == length)
                {
                    continue;
                }
            }

            if ((checkValid && !IsSegmentValid(sudoku, segRowIdx, segColIdx, SEGMENT))
                || (!checkValid && !IsSegmentComplete(sudoku, segRowIdx, segColIdx, SEGMENT)))
            {
                return false;
            }

            segRowIdx += SEGMENT;
        }

        return true;
    }

    private static bool CheckSequences(int[,] sudoku, bool checkValid)
    {
        int[][] rowsAndColumns = GetRowsAndColumns(sudoku);
        foreach (int[] sequence in rowsAndColumns)
        {
            if ((checkValid && !IsSequenceValid(sequence))
                || (!checkValid && !IsSequenceComplete(sequence)))
            {
                return false;
            }
        }

        return true;
    }
}