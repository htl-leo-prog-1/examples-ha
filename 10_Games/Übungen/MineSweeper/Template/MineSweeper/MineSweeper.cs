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

        //TODO Initialize, start and run game

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
        //TODO Initialize board 
    }

    /// <summary>
    /// Play game: Repeat ask user and set mine (or mark as mine) on board.
    /// </summary>
    /// <param name="mineField"></param>
    private static void PlayGame(bool[,] mineField)
    {
        //TODO Read User-input and update board 
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
        // TODO implement CreateMineField
        throw new NotImplementedException();
    }

    /// <summary>
    /// Count all mines in the mine-field
    /// </summary>
    /// <param name="mineField"></param>
    /// <returns>Count of all mines in the mine-field.</returns>
    public static int CountMinesOnBoard(bool[,] mineField)
    {
        // TODO implement CreateMineField
        throw new NotImplementedException();
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

        // TODO implement CreateMineField
        throw new NotImplementedException();
    }
}