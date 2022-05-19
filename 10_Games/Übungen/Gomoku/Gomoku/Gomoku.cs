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

public static class Gomoku
{
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
        } while (!Tools.Contains(new[] {15, 17, 19}, boardSize));

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
        int maxStones = field.GetLength(0) * field.GetLength(1);
        int stonesSet = 0;

        int winnerIndex = -1; // either player 1 (0) or player 2 (1) won, 2 indicates a draw, -1 not set

        do
        {
            int row;
            int col;

            switch (GetUserInput(playerIndex, field, out row, out col))
            {
                case 0:     // set stone on position row/col
                    if (SetStone(field, row, col, playerIndex))
                    {
                        winnerIndex = playerIndex;
                    }

                    playerIndex = 1 - playerIndex;
                    stonesSet++;
                    break;
                case 1: // surrender
                    winnerIndex = 2;
                    break;
            }
        } while (stonesSet < (maxStones) && winnerIndex < 0);

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
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
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
    /// Return 0 if the user has entered a valid row/col (see out parameters). The position must be empty.
    /// Return 1 if the user surrenders.
    /// </summary>
    /// <param name="player">the current player</param>
    /// <param name="field">the game field</param>
    /// <param name="row">input from user</param>
    /// <param name="col">input from user</param>
    /// <returns>0 or 1</returns>
    public static int GetUserInput(int player, int[,] field, out int row, out int col)
    {
        int result = 0;
        bool isOk;
        row = col = 0;

        int rows = field.GetLength(0);
        int cols = field.GetLength(1);

        do
        {
            isOk = false;

            Console.Write($"Next move for player {player + 1}:");
            var input = Console.ReadLine() ?? "".Trim();

            if (input.Length > 0)
            {
                if (input[0] == '!')
                {
                    result = 1;
                    isOk = true;
                }
                else
                {
                    result = 0;

                    var rowCol = input.Split(',');

                    isOk = rowCol.Length == 2 &&
                           Tools.TryParse(rowCol[0], out row, rows - 1, 0) &&
                           Tools.TryParse(rowCol[1], out col, cols - 1, 0) &&
                           field[row, col] == -1;
                }
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
            {0, 1}, // left/right
            {1, 0}, // up/down
            {1, 1}, // diagonalUp
            {-1, 1}, // diagonalDown
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
        int actRow = row + deltaRow;
        int actCol = col + deltaCol;
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
        int counterEqual = 1 + // this field
                           CountDirection(field, player, row, col, deltaRow, deltaCol) + // direction +
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
}