/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: TicTacToe
*--------------------------------------------------------------
*/

namespace TicTacToe;

public static class TicTacToe
{
    private const string GAME = "TicTacToe";
    private const int SIZE = 3;
    private const int MIN_NUM = 1;
    private const int MAX_NUM = 9;
    private const int MAX_TURNS = MAX_NUM;
    private const string X = "X";
    private const string O = "O";
    private static readonly Random random = new();

    /// <summary>
    ///     Executes the Tic Tac Toe program
    /// </summary>
    public static void Run()
    {
        Console.WriteLine($"{GAME}{Environment.NewLine}=========");
        Board.Init(SIZE, SIZE, "TicTacToe");

        var playerIndex = random.Next(0, 2); // randomly decide who starts
        
        InitPositions(); // initialize playing field

        int counter = 0;
        int winnerIndex = -1; // either player 1 (0) or player 2 (1) won, -1 indicates a draw
        do
        {
            int position = GetStonePosition(playerIndex);
            int row = GetRowFromPosition(position);
            int col = GetColFromPosition(position, row);
            if (playerIndex == 0)
            {
                Board.SetText(row, col, O, "Red");
            }
            else
            {
                Board.SetText(row, col, X, "Green");
            }

            counter++;
            if (counter >= 5) // first turn in which there can be a winner
            {
                winnerIndex = CheckWinner();
            }

            playerIndex = 1 - playerIndex;
        } while (counter < MAX_TURNS && winnerIndex == -1);

        Console.WriteLine(winnerIndex != -1
            ? $"The player with number {winnerIndex} has won!"
            : "The game ended in a draw");
    }

    /// <summary>
    ///     Checks which player has won the game or if it ended in a draw.
    /// </summary>
    /// <returns>Index of the winning player or -1 if it is a draw</returns>
    public static int CheckWinner()
    {
        // TODO
        return -1;
    }

    public static string?[,] GetFieldValues()
    {
        // TODO
        return new string?[0, 0];
    }

    /// <summary>
    ///     Based on the supplied row and column (both 0 index based)
    ///     the index (0 for 'O' and 1 for 'X') of the player 'stone' placed in the
    ///     identified cell is returned.
    ///     If the cell is empty or the parameters are out of range (0-2) -1 is returned.
    /// </summary>
    /// <param name="row">Row index of the field</param>
    /// <param name="col">Column index of the field</param>
    /// <returns>Index of the player stone or -1 if invalid/no stone</returns>
    public static int GetPlayerIndexFromCell(int row, int col)
    {
        // TODO
        return -1;
    }

    /// <summary>
    ///     Calculates the col index (0 based) for the supplied position.
    ///     If an invalid position or row is supplied -1 is returned.
    /// </summary>
    /// <param name="position">Position (range 1-9)</param>
    /// <param name="row">Row index (range 0-2)</param>
    /// <returns>The index of the positions column (0 based) if valid; -1 otherwise</returns>
    public static int GetColFromPosition(int position, int row)
    {
        // TODO
        return -1;
    }

    /// <summary>
    ///     Calculates the row index (0 based) for the supplied position.
    ///     If an invalid position is supplied -1 is returned.
    /// </summary>
    /// <param name="position">Position (range 1-9)</param>
    /// <returns>The index of the positions row (0 based) if valid; -1 otherwise</returns>
    public static int GetRowFromPosition(int position)
    {
        // TODO
        return -1;
    }

    /// <summary>
    ///     The player with the supplied <see cref="playerIndex"/> is asked to enter
    ///     a valid position for placing their next 'stone'.
    ///     A position is only valid if it is within range and still empty.
    ///     Repeats the input until a valid position is entered.
    /// </summary>
    /// <param name="playerIndex">Index of the player whose turn it is</param>
    /// <returns>The selected position (1-9)</returns>
    private static int GetStonePosition(int playerIndex)
    {
        // TODO
        return -1;
    }

    /// <summary>
    ///     Checks if the supplied position is valid (within the defined range)
    ///     and if that is the case, also if the field position is empty (= neither X nor O).
    /// </summary>
    /// <param name="position">Field position to check (1-9)</param>
    /// <returns>True if the position is valid and empty; false otherwise</returns>
    public static bool CheckPosition(int position)
    {
        // TODO
        return false;
    }

    /// <summary>
    ///     Checks if the supplied position is valid (within the defined range).
    /// </summary>
    /// <param name="position">Field position to check (1-9)</param>
    /// <returns>True if the position is valid; false otherwise</returns>
    public static bool CheckPositionValid(int position)
    {
        // TODO
        return false;
    }

    /// <summary>
    ///     Initially puts the numbers 1-9 (arranged like on a num block) in the fields
    ///     to indicate which number corresponds to which field.
    /// </summary>
    public static void InitPositions()
    {
        // TODO
    }
}