/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MineSweeper
* https://de.wikipedia.org/wiki/Minesweeper
*--------------------------------------------------------------
*/

namespace MineSweeper;

using System;

public class MineSweeper
{
    private static readonly string _emptyField   = "\u2593";
    private static readonly string _markedAsMine = "\u25B6";
    private static readonly string _hitMine      = "\u2B59";
    private static readonly string _notFoundMine = "\u2B24";

    public static void Run()
    {
        Console.WriteLine("MineSweeper");
        Console.WriteLine("===========");

        var size  = Tools.ReadNumber("Size of (squared) board ", 20,          2);
        var mines = Tools.ReadNumber("Count of mines ",          size * size, 1);

        InitBoard(size, size);

        Console.WriteLine("Clear field with e.g.: 4,4");
        Console.WriteLine("Set as mine with e.g.: *3,4");
        Console.WriteLine("End game with !");

        var mineField = CreateMineField(mines, size, size);

        PlayGame(mineField);
        ShowMines(mineField);

        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
        Board.Exit();
    }

    /// <summary>
    /// Initialize the board.
    /// Set all fields to \u2593
    /// </summary>
    /// <param name="rows">Rows of the mine-field</param>
    /// <param name="cols">Cols of the mine-field</param>
    private static void InitBoard(int rows, int cols)
    {
        Board.Init(rows, cols, "MineSweeper");

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Board.SetText(row, col, _emptyField, "LightGray");
            }
        }
    }

    /// <summary>
    /// Play game: Repeat ask user and set mine (or mark as mine) on board.
    /// </summary>
    /// <param name="mineField"></param>
    private static void PlayGame(bool[,] mineField)
    {
        int rows = mineField.GetLength(0);
        int cols = mineField.GetLength(1);

        bool mineOrEnd = false;

        do
        {
            int row;
            int col;

            switch (ReadRowCol(rows, cols, out row, out col))
            {
                case 0: // ClearField
                    mineOrEnd = !ClearField(mineField, row, col);
                    break;
                case 1: // mark as mine
                    MarkAsMine(mineField, row, col);
                    break;
                case 2:
                    mineOrEnd = true;
                    ClearAllFields(mineField);
                    break;
            }
        } while (!mineOrEnd);
    }

    /// <summary>
    /// Ask the user for the next move.  
    /// </summary>
    /// <param name="rows">Max count of rows.</param>
    /// <param name="cols">Max count of columns.</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>0 clear row/col, 1 set mine on row/col, 2 end game</returns>
    static int ReadRowCol(int rows, int cols, out int row, out int col)
    {
        int  result = 0; // assume clear field
        bool isOk;
        do
        {
            row = 0;
            col = 0;

            Console.Write("=>");
            string input = Console.ReadLine() ?? "".Trim();

            bool needRowCol = true;
            isOk = true;

            if (input.Length > 0)

            {
                if (input[0] == '*')
                {
                    result = 1;
                    input  = input.Substring(1);
                }
                else if (input == "!")
                {
                    result     = 2;
                    needRowCol = false;
                }
            }

            if (needRowCol)
            {
                var rowCol = input.Split(',');

                isOk = rowCol.Length == 2 &&
                       Tools.TryParse(rowCol[0], out row, rows - 1, 0) &&
                       Tools.TryParse(rowCol[1], out col, cols - 1, 0);
            }
        } while (!isOk);

        return result;
    }

    /// <summary>
    /// Mark a field as a mine.
    /// </summary>
    /// <param name="mineField">Our mine-field</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    static void MarkAsMine(bool[,] mineField, int row, int col)
    {
        Board.SetText(row, col, _markedAsMine, "Red");
    }

    /// <summary>
    /// Clear a field on the mine-field.
    /// If a mine is hit, false is returned.
    /// </summary>
    /// <param name="mineField">Our mine-field</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>true if on mine is hit, otherwise false</returns>
    static bool ClearField(bool[,] mineField, int row, int col)
    {
        if (mineField[row, col])
        {
            // hit a mine!
            Board.SetText(row, col, _hitMine, "Red");
            return false;
        }

        ClearSurroundingFields(mineField, row, col);

        return true;
    }

    /// <summary>
    /// Clear field and all surrounding (if mine-count == 0)
    /// </summary>
    /// <param name="mineField">Our mine-field</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    static void ClearSurroundingFields(bool[,] mineField, int row, int col)
    {
        int rows = mineField.GetLength(0);
        int cols = mineField.GetLength(1);

        if (Tools.InRange(row, rows - 1, 0) && Tools.InRange(col, cols - 1, 0))
        {
            if (Board.GetText(row, col) == _emptyField)
            {
                int mines = CountMinesAround(mineField, row, col);
                if (mines == 0)
                {
                    Board.SetText(row, col, "");
                    ClearSurroundingFields(mineField, row + 1, col);
                    ClearSurroundingFields(mineField, row - 1, col);
                    ClearSurroundingFields(mineField, row,     col + 1);
                    ClearSurroundingFields(mineField, row,     col - 1);
                }
                else
                {
                    var colors = new[] { "", "Blue", "Green", "Red", "DarkBlue", "DarkRed", "BlueViolet", "Black", "Black" };
                    Board.SetText(row, col, mines.ToString(), colors[mines]);
                }
            }
        }
    }

    /// <summary>
    /// User end the game. Clear all fields
    /// </summary>
    /// <param name="mineField"></param>
    static void ClearAllFields(bool[,] mineField)
    {
        int rows = mineField.GetLength(0);
        int cols = mineField.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (Board.GetText(row, col) == _emptyField)
                {
                    ClearField(mineField, row, col);
                }
            }
        }
    }

    /// <summary>
    /// After an error (the user has hit a mine),
    /// we show the hidden mines.
    /// </summary>
    /// <param name="mineField"></param>
    static void ShowMines(bool[,] mineField)
    {
        int rows = mineField.GetLength(0);
        int cols = mineField.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (mineField[row, col])
                {
                    if (Board.GetText(row, col) != _hitMine)
                    {
                        Board.SetText(row, col, _notFoundMine, "Red");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Count the mines around a given position.
    /// </summary>
    /// <param name="mineField">Our mine-field</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>Count of mine excluded th current position.</returns>
    public static int CountMinesAround(bool[,] mineField, int row, int col)
    {
        int rows = mineField.GetLength(0);
        int cols = mineField.GetLength(1);

        int count   = 0;
        int rowFrom = Math.Max(0, row - 1);
        int rowTo   = Math.Min(rows - 1, row + 1);
        int colFrom = Math.Max(0, col - 1);
        int colTo   = Math.Min(cols - 1, col + 1);

        for (int myRow = rowFrom; myRow <= rowTo; myRow++)
        {
            for (int myCol = colFrom; myCol <= colTo; myCol++)
            {
                if (mineField[myRow, myCol])
                {
                    count++;
                }
            }
        }

        if (mineField[row, col])
        {
            count--;
        }

        return count;
    }

    /// <summary>
    /// Count all mines in the mine-field
    /// </summary>
    /// <param name="mineField"></param>
    /// <returns>Count of all mines in the mine-field.</returns>
    public static int CountMinesOnBoard(bool[,] mineField)
    {
        int rows  = mineField.GetLength(0);
        int cols  = mineField.GetLength(1);
        
        int count = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (mineField[row, col])
                {
                    count++;
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Create a mine-field with mines on random positions.
    /// </summary>
    /// <param name="countMines">Count of mines to be place on the mine-field</param>
    /// <param name="rows">Mine-Field rows</param>
    /// <param name="cols">Mine-Field columns</param>
    /// <returns>Created mine-field, if not valid (e.g. to many mines) throw exception</returns>
    public static bool[,] CreateMineField(int countMines, int rows, int cols)
    {
        var random = new Random();

        if (countMines > (rows * cols))
        {
            throw new ArgumentException();
        }

        var mineField = new bool[rows, cols];

        while (countMines > 0)
        {
            var row = random.Next(rows);
            var col = random.Next(cols);
            
            if (!mineField[row, col])
            {
                mineField[row, col] = true;
                countMines--;
            }
        }

        return mineField;
    }
}