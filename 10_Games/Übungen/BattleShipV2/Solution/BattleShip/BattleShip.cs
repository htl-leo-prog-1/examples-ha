/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung
 *--------------------------------------------------------------
 * Description: BattleShip
 *--------------------------------------------------------------
 */

namespace BattleShip;

using System;
using System.IO;

public static class BattleShip
{
    /// <summary>
    /// Executes the BattleShip program
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("BattleShip ");
        Console.WriteLine("=========");

        bool[,] battlefield = InitField();

        DesignField(battlefield);
    }

    public static bool[,] InitField()
    {
        int  boardSize;
        bool isOk;

        do
        {
            boardSize = Tools.ReadNumber("Board size [10,15 or 20]: ");
            isOk = Tools.Contains(new[] { 10, 15, 20 }, boardSize);
            if (!isOk)
            {
                Console.WriteLine("Ungültige Größe");
            }
        } while (!isOk);

        Board.Init(boardSize, boardSize, "BattleShip");

        return InitBattleField(boardSize);
    }

    /// <summary>
    /// Initialize the field.
    /// Mark all positions as empty.
    /// </summary>
    /// <param name="boardSize"></param>
    /// <returns>The created and initialized field.</returns>
    public static bool[,] InitBattleField(int boardSize)
    {
        var field = new bool[boardSize, boardSize];
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                Board.SetText(row, col, "");
            }
        }

        return field;
    }

    /// <summary>
    /// Continue read user input and set stone
    /// </summary>
    /// <param name="battlefield"></param>
    public static void DesignField(bool[,] battlefield)
    {
        Console.WriteLine("\"row,col\" to set a ship, e.g. 5,7");
        Console.WriteLine("\"!row,col\" to clear a ship, e.g. !5,7");
        Console.WriteLine("\"exit\" to quit program");
        Console.WriteLine("\"save filename\" to save the field (and continue)");
        Console.WriteLine("\"load filename\" revert and load the field from a file.");

        bool isEnd = false;

        do
        {
            int    row;
            int    col;
            string fileName;

            switch (GetUserInput(battlefield, out row, out col, out fileName))
            {
                case 0: // set ship on position row/col
                    if (!SetShip(battlefield, row, col))
                    {
                        Console.WriteLine("Cannot set ship at {row}:{col}");
                    }

                    break;

                case 1: // clear ship on position row/col

                    if (!ClearShip(battlefield, row, col))
                    {
                        Console.WriteLine("No ship at {row}:{col}");
                    }

                    break;
                case 3: // store
                    SaveField(battlefield, fileName);
                    Console.WriteLine($"Field saved to '{fileName}'.");
                    break;

                case 2: // load
                    var field = LoadField(battlefield.GetLength(0), fileName);
                    if (field == null)
                    {
                        Console.WriteLine("Illegal field!");
                        Console.WriteLine("Load failed.");
                        isEnd = true;
                    }
                    else
                    {
                        battlefield = field;
                        Console.WriteLine($"Field loaded from '{fileName}'.");
                    }

                    break;

                case 4: // quit
                    isEnd = true;
                    break;
            }
        } while (!isEnd);
    }

    /// <summary>
    /// Set a ship on the battlefield.
    /// Row and col must be an empty position.
    /// </summary>
    /// <param name="battlefield">The battlefield</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>true, the ship can be set, false otherwise</returns>
    public static bool SetShip(bool[,] battlefield, int row, int col)
    {
        if (!CanSetShip(battlefield, row, col))
        {
            return false;
        }

        battlefield[row, col] = true;
        Board.SetText(row, col, "o");

        return true;
    }

    /// <summary>
    /// Check, if the ship can be set at the given position.
    /// </summary>
    /// <param name="battlefield"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>true if ship can be set, otherwise false.</returns>
    public static bool CanSetShip(bool[,] battlefield, int row, int col)
    {
        if (battlefield[row, col])
        {
            return false;
        }

        int minRow = Math.Max(0, row - 1);
        int maxRow = Math.Min(battlefield.GetLength(0)-1, row + 1);

        int minCol = Math.Max(0, col - 1);
        int maxCol = Math.Min(battlefield.GetLength(1)-1, col + 1);

        int count = 0;

        for (int r = minRow; r <= maxRow; r++)
        {
            for (int c = minCol; c <= maxCol; c++)
            {
                if (battlefield[r, c])
                {
                    count++;
                }
            }
        }

        return count == 0;
    }

    /// <summary>
    /// Clear a ship on the battlefield.
    /// </summary>
    /// <param name="battlefield">The battlefield</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>true, the ship can be cleared, false otherwise</returns>
    public static bool ClearShip(bool[,] battlefield, int row, int col)
    {
        if (!battlefield[row, col])
        {
            return false;
        }

        battlefield[row, col] = false;
        Board.SetText(row, col, "");

        return true;
    }

    /// <summary>
    /// Show menu and read user input.
    /// Repeat until valid input.
    /// </summary>
    /// <param name="battlefield"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="filename"></param>
    /// <returns>0 set ship, 1 clear ship, 2 load, 3 save, 4 exit</returns>
    public static int GetUserInput(bool[,] battlefield, out int row, out int col, out string filename)
    {
        int  result;
        bool isOk;
        row      = col = 0;
        filename = string.Empty;

        int rows = battlefield.GetLength(0);
        int cols = battlefield.GetLength(1);

        do
        {
            isOk = true;

            Console.Write("=> ");
            string input = (Console.ReadLine() ?? "").Trim();

            if (input == "exit")
            {
                result = 4;
            }
            else if (input.StartsWith("load "))
            {
                result   = 2;
                filename = input.Substring("load".Length).Trim();
                isOk     = !string.IsNullOrEmpty(filename);
            }
            else if (input.StartsWith("save "))
            {
                result   = 3;
                filename = input.Substring("save".Length).Trim();
                isOk     = !string.IsNullOrEmpty(filename);
            }
            else
            {
                if (input.StartsWith("!"))
                {
                    result = 1;
                    input  = input.Substring(1).Trim();
                }
                else
                {
                    result = 0;
                }

                string[] rowCol = input.Split(',');

                isOk = rowCol.Length == 2 &&
                       Tools.TryParse(rowCol[0], out row, 0, rows - 1) &&
                       Tools.TryParse(rowCol[1], out col, 0, cols - 1);
            }

            if (!isOk)
            {
                Console.WriteLine("Illegal input, please try again");
            }
        } while (!isOk);

        return result;
    }

    /// <summary>
    /// Count all ships on the battlefield.
    /// </summary>
    /// <param name="battlefield"></param>
    /// <returns>Count of stones on the battlefield</returns>
    public static int GetShipCount(bool[,] battlefield)
    {
        int rows = battlefield.GetLength(0);
        int cols = battlefield.GetLength(1);

        int count = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (battlefield[row, col])
                {
                    count++;
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Save the current field to the specified file (as excel csv).
    /// </summary>
    /// <param name="battlefield">the definition for the current field.</param>
    /// <param name="fileName">The destination filename.</param>
    public static void SaveField(bool[,] battlefield, string fileName)
    {
        var lines = new string[1 + GetShipCount(battlefield)]; // +1 because of header

        int rows  = battlefield.GetLength(0);
        int cols  = battlefield.GetLength(1);
        int count = 0;

        lines[count++] = "No;Row;Col;Player";

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (battlefield[row, col])
                {
                    lines[count] = $"{count};{row};{col}";
                    count++;
                }
            }
        }

        if (File.Exists(fileName))
        {
            string bakFileName = $"{Path.GetFileNameWithoutExtension(fileName)}.bak";

            if (File.Exists(bakFileName))
            {
                File.Delete(bakFileName);
            }
            File.Move(fileName, bakFileName);
        }

        File.WriteAllLines(fileName, lines);
    }

    /// <summary>
    /// Load a stored field from a file (csv format).
    /// The file must be in a correct format (no validation check)
    /// and the boardSize must match.
    /// Errors are ignored
    /// </summary>
    /// <param name="boardSize">10,15 or 20</param>
    /// <param name="fileName">Source file-name.</param>
    /// <returns></returns>
    public static bool[,]? LoadField(int boardSize, string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        var field = InitBattleField(boardSize);

        if (lines.Length > 0)
        {
            bool first = true;

            foreach (var line in lines)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    var part = line.Split(';');
                    int row  = int.Parse(part[1]);
                    int col  = int.Parse(part[2]);

                    if (!SetShip(field, row, col))
                    {
                        return null;
                    }
                }
            }
        }

        return field;
    }
}