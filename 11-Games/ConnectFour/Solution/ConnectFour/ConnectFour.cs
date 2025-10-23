/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: ConnectFour
 *--------------------------------------------------------------
 */

namespace ConnectFour
{
    using System;

    public class ConnectFour
    {
        /// <summary>
        /// Main method to play "ConnectFour"
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Connect Four");
            Console.WriteLine("============");

            var rows = Tools.ReadNumber("Rows    ", 10, 2);
            var cols = Tools.ReadNumber("Columns ", 10, 2);

            Board.Init(rows, cols, "Connect Four");

            var allocation = new int[rows, cols]; // 0 ==> empty, 1 ==> player 1, 2 ==> player 2
            var winner     = PlayGame(allocation);

            if (winner > 0)
            {
                Console.WriteLine($"Player {winner} has won the game!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }

            Board.Exit();
        }

        /// <summary>
        /// Play the game.
        /// Repeat ask user for row.
        /// </summary>
        /// <param name="allocation"></param>
        /// <returns>0: draw, 1: winner is player 1, 2: winner is player 2</returns>
        static int PlayGame(int[,] allocation)
        {
            int rows          = allocation.GetLength(0);
            int cols          = allocation.GetLength(1);
            int playerNumber  = 1;
            int winnerNumber  = 0;
            int stonesCounter = 0;
            int maxStones     = rows * cols;

            do
            {
                Console.Write($"Player {playerNumber}, ");

                var col = Tools.ReadNumber("Column ", cols - 1, 0);
                var row = GetFreeRow(allocation, col);

                if (row >= 0)
                {
                    stonesCounter++;
                    allocation[row, col] = playerNumber;

                    if (playerNumber == 1)
                    {
                        Board.SetText(row, col, "X", "Red");
                        playerNumber = 2;
                    }
                    else
                    {
                        Board.SetText(row, col, "O", "Green");
                        playerNumber = 1;
                    }

                    winnerNumber = IsWinner(allocation, row, col);
                }
                else
                {
                    Console.WriteLine($"Column {col} is full.");
                }
            } while (winnerNumber == 0 && stonesCounter < maxStones);

            return winnerNumber;
        }

        /// <summary>
        /// Search the lowest position in a column.
        /// </summary>
        /// <param name="col">Requested column</param>
        /// <param name="allocation">The game field.</param>
        /// <returns>lowest free position or -1 if full.</returns>
        public static int GetFreeRow(int[,] allocation, int col)
        {
            int row = allocation.GetLength(0) - 1;

            while (row >= 0 && allocation[row, col] != 0)
            {
                row--;
            }

            return row;
        }

        /// <summary>
        /// Check, if after placing a stone, the player has won the game.
        /// Do not check all fields, only the surrounding fields of the new stone.
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="row">Row of the new stone.</param>
        /// <param name="col">Column of the new stone</param>
        /// <returns>0: no winner, 1: winner is player 1, 2: winner is player 2</returns>
        public static int IsWinner(int[,] allocation, int row, int col)
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
                int winner = CheckDirection(allocation, row, col, directions[i, 0], directions[i, 1]);
                if (winner > 0)
                {
                    return winner;
                }
            }

            return 0;
        }

        /// <summary>
        /// Calculates the amount of stones in the specified direction.
        /// </summary>
        /// <param name="allocation">The game field.</param>
        /// <param name="player">Player of the first stone (search for this player).</param>
        /// <param name="row">Starting row.</param>
        /// <param name="col">Starting column.</param>
        /// <param name="deltaRow">-1, 0 or 1</param>
        /// <param name="deltaCol">-1, 0 or 1</param>
        /// <returns>Count of same stones in the specified direction.</returns>
        private static int CountDirection(int[,] allocation, int player, int row, int col, int deltaRow, int deltaCol)
        {
            int counterEqual = 0;
            int actRow       = row + deltaRow;
            int actCol       = col + deltaCol;
            while (IsPossible(allocation, actRow, actCol) && allocation[actRow, actCol] == player)
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
        /// <param name="allocation">The game field.</param>
        /// <param name="row">Starting row.</param>
        /// <param name="col">Starting column.</param>
        /// <param name="deltaRow">-1, 0 or 1</param>
        /// <param name="deltaCol">-1, 0 or 1</param>
        /// <returns>0: no winner, 1: winner is player 1, 2: winner is player 2</returns>
        private static int CheckDirection(int[,] allocation, int row, int col, int deltaRow, int deltaCol)
        {
            int player = allocation[row, col];
            int counterEqual = 1 +                                                                 // this field
                               CountDirection(allocation, player, row, col, deltaRow,  deltaCol) + // direction +
                               CountDirection(allocation, player, row, col, -deltaRow, -deltaCol); // direction -

            return counterEqual >= 4 ? player : 0;
        }

        /// <summary>
        /// Check, if the row and col is within the boundaries
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>true, if row/col is OK, otherwise false.</returns>
        private static bool IsPossible(int[,] allocation, int row, int col)
        {
            return row >= 0 && row < allocation.GetLength(0) &&
                   col >= 0 && col < allocation.GetLength(1);
        }
    }
}