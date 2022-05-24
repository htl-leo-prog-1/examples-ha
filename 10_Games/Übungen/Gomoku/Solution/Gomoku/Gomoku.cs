/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Gomoku
*--------------------------------------------------------------
*/

namespace Gomoku;

using System;
using System.IO;

public static class Gomoku
{
    public const string _fileName = "game.csv";

    /// <summary>
    ///     Executes the Gomoku program
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Gomoku ");
        Console.WriteLine("=========");

        int boardSize;

        do
        {
            boardSize = Tools.ReadNumber("Board size [15,17 or 19]: ");
        } while (!Tools.Contains(new[] { 15, 17, 19 }, boardSize));

        Board.Init(boardSize, boardSize, "Gomoku");

        var field = InitField(boardSize);

        var winnerIndex = PlayGame(field, 0);

        if (winnerIndex == 2)
        {
            Console.WriteLine("The game ended in a draw");
        }
        else
        {
            Console.WriteLine($"The player {winnerIndex + 1} has won!");
        }
    }

    /// <summary>
    /// Continue read user input and set stone
    /// </summary>
    /// <param name="field"></param>
    /// <param name="playerIndex"></param>
    /// <returns><0 if player 1 won, 1 if player 2, 2 if draw.</returns>
    public static int PlayGame(int[,] field, int playerIndex)
    {
        Console.WriteLine("\"row,col\" to set stone, e.g. 5,7");
        Console.WriteLine("! to give up game (quit program)");
        Console.WriteLine("s to save the game (and continue)");
        Console.WriteLine("l give up the current game and load the store game - continue with the stored game.");

        int maxStones = field.GetLength(0) * field.GetLength(1);

        int winnerIndex = -1; // either player 1 (0) or player 2 (1) won, 2 indicates a draw, -1 not set

        do
        {
            int row;
            int col;

            switch (GetUserInput(playerIndex, field, out row, out col))
            {
                case 0: // set stone on position row/col
                    if (SetStone(field, row, col, playerIndex))
                    {
                        winnerIndex = playerIndex;
                    }

                    playerIndex = 1 - playerIndex;
                    break;
                case 1: // give up
                    winnerIndex = 2;
                    break;
                case 2: // storegame
                    SaveGame(field, _fileName);
                    Console.WriteLine("Game saved.");
                    break;

                case 3: // loadgame
                    field       = LoadGame(field.GetLength(0), _fileName);
                    playerIndex = GetStoneCount(field) % 2;
                    Console.WriteLine("Game loaded.");
                    break;
            }
        } while (GetStoneCount(field) < (maxStones) && winnerIndex < 0);

        return winnerIndex;
    }

    /// <summary>
    /// Initialize the (game-)field.
    /// Mark all positions as empty (-1)
    /// </summary>
    /// <param name="boardSize"></param>
    /// <returns>The created and initialized game-field</returns>
    public static int[,] InitField(int boardSize)
    {
        var field = new int[boardSize, boardSize];
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                Board.SetText(row, col, "");
                field[row, col] = -1;
            }
        }

        return field;
    }

    /// <summary>
    /// Set a stone on the (game-)field.
    /// Row and col must be a empty position.
    /// </summary>
    /// <param name="field">The game field</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="player">The player (0,1= who set the stone</param>
    /// <returns>true, if the user won the game, false otherwise</returns>
    public static bool SetStone(int[,] field, int row, int col, int player)
    {
        if (field[row, col] != -1)
        {
            return false;
        }

        field[row, col] = player;

        if (player == 0)
        {
            Board.SetText(row, col, "O", "Red");
        }
        else
        {
            Board.SetText(row, col, "X", "Green");
        }

        return IsWinner(field, row, col);
    }

    /// <summary>
    /// Read the user input.
    /// Possible inputs: set stone, give up, load or save the game 
    ///
    /// /// </summary>
    /// <param name="player">the current player</param>
    /// <param name="field">the game field</param>
    /// <param name="row">input from user</param>
    /// <param name="col">input from user</param>
    /// <returns>Return 0 if the user has entered a valid row/col (see out parameters). The position must be empty.
    /// Return 1 if the user gives up.
    /// Return 2 to save the game
    /// Return 3 to load a game.
    /// </returns>
    public static int GetUserInput(int player, int[,] field, out int row, out int col)
    {
        int  result;
        bool isOk;
        row = col = 0;

        int rows = field.GetLength(0);
        int cols = field.GetLength(1);

        do
        {
            isOk = true;

            Console.Write($"Player {player + 1}: ");
            var input = (Console.ReadLine() ?? "").Trim();

            switch (input)
            {
                case "!":
                    result = 1;
                    break;
                case "s":
                    result = 2;
                    break;
                case "l":
                    result = 3;
                    break;
                default:
                    result = 0;

                    var rowCol = input.Split(',');

                    isOk = rowCol.Length == 2 &&
                           Tools.TryParse(rowCol[0], out row, rows - 1, 0) &&
                           Tools.TryParse(rowCol[1], out col, cols - 1, 0) &&
                           field[row, col] == -1;
                    break;
            }

            if (!isOk)
            {
                Console.WriteLine("Illegal input, please try again");
            }
        } while (!isOk);

        return result;
    }

    /// <summary>
    /// Check, if after placing a stone, the player has won the game.
    /// Do not check all fields, only the surrounding fields of the new stone.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="row">Row of the new stone.</param>
    /// <param name="col">Column of the new stone</param>
    /// <returns>true if 5 in any directions</returns>
    public static bool IsWinner(int[,] field, int row, int col)
    {
        var directions = new int[,]
        {
            { 0, 1 },  // left/right
            { 1, 0 },  // up/down
            { 1, 1 },  // diagonalUp
            { -1, 1 }, // diagonalDown
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            if (IsWinnerDirection(field, row, col, directions[i, 0], directions[i, 1]))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Calculates the amount of stones in the specified direction.
    /// </summary>
    /// <param name="field">The game field.</param>
    /// <param name="player">Player of the first stone (search for this player).</param>
    /// <param name="row">Starting row.</param>
    /// <param name="col">Starting column.</param>
    /// <param name="deltaRow">-1, 0 or 1</param>
    /// <param name="deltaCol">-1, 0 or 1</param>
    /// <returns>Count of same stones in the specified direction.</returns>
    public static int CountDirection(int[,] field, int player, int row, int col, int deltaRow, int deltaCol)
    {
        int counterEqual = 0;
        int actRow       = row + deltaRow;
        int actCol       = col + deltaCol;
        while (IsInRange(field, actRow, actCol) && field[actRow, actCol] == player)
        {
            counterEqual++;
            actRow += deltaRow;
            actCol += deltaCol;
        }

        return counterEqual;
    }

    /// <summary>
    /// Calculate for a given position (the new stone) if the player has won the game now.
    /// Only one direction (delta) is checked: up,own,diagonalUp and diagonalDown.
    /// </summary>
    /// <param name="field">The game field.</param>
    /// <param name="row">Starting row.</param>
    /// <param name="col">Starting column.</param>
    /// <param name="deltaRow">-1, 0 or 1</param>
    /// <param name="deltaCol">-1, 0 or 1</param>
    /// <returns>true if >= 5 in this direction</returns>
    public static bool IsWinnerDirection(int[,] field, int row, int col, int deltaRow, int deltaCol)
    {
        int player = field[row, col];
        int counterEqual = 1 +                                                            // this field
                           CountDirection(field, player, row, col, deltaRow,  deltaCol) + // direction +
                           CountDirection(field, player, row, col, -deltaRow, -deltaCol); // direction -

        return counterEqual >= 5;
    }

    /// <summary>
    /// Check, if the row and col is within the boundaries
    /// </summary>
    /// <param name="field"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>true, if row/col is OK, otherwise false.</returns>
    public static bool IsInRange(int[,] field, int row, int col)
    {
        return row >= 0 && row < field.GetLength(0) &&
               col >= 0 && col < field.GetLength(1);
    }

    /// <summary>
    /// Count all stones on the field, independent of the player.
    /// </summary>
    /// <param name="field"></param>
    /// <returns>Count of stones on the field</returns>
    public static int GetStoneCount(int[,] field)
    {
        int rows = field.GetLength(0);
        int cols = field.GetLength(1);

        int count = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (field[row, col] >= 0)
                {
                    count++;
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Save the current game to the specified file (as excel csv).
    /// </summary>
    /// <param name="field">the definition for the current game.</param>
    /// <param name="fileName">The destination filename.</param>
    public static void SaveGame(int[,] field, string fileName)
    {
        var lines = new string[1 + GetStoneCount(field)]; // +1 because of header

        int rows  = field.GetLength(0);
        int cols  = field.GetLength(1);
        int count = 0;

        lines[count++] = "No;Row;Col;Player";

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (field[row, col] >= 0)
                {
                    lines[count] = $"{count};{row};{col};{field[row, col]}";
                    count++;
                }
            }
        }

        File.WriteAllLines(fileName, lines);
    }

    /// <summary>
    /// Load a stored game from a file (csv format).
    /// The file must be in a correct format (no validation check)
    /// and the boardSize must match.
    /// Errors are ignored
    /// </summary>
    /// <param name="boardSize">16,17 or 19</param>
    /// <param name="fileName">Source file-name.</param>
    /// <returns></returns>
    public static int[,] LoadGame(int boardSize, string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        var field = InitField(boardSize);

        if (lines.Length > 0)
        {
            for (int i = 1; i < lines.Length; i++)
            {
                var part   = lines[i].Split(';');
                int row    = int.Parse(part[1]);
                int col    = int.Parse(part[2]);
                int player = int.Parse(part[3]);

                SetStone(field, row, col, player);
            }
        }

        return field;
    }
}