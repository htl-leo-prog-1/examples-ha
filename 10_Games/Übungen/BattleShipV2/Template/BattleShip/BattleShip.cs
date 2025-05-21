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

    /// <summary>
    /// Ask user for board-size (repeat until valid).
    /// Initialize board (GUI).
    /// Call InitBattleField to initialize array.  
    /// </summary>
    /// <returns></returns>
    public static bool[,] InitField()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Initialize the field.
    /// Mark all positions as empty.
    /// </summary>
    /// <param name="boardSize"></param>
    /// <returns>The created and initialized field.</returns>
    public static bool[,] InitBattleField(int boardSize)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Continue read user input and set stone/load/save
    /// </summary>
    /// <param name="battlefield"></param>
    public static void DesignField(bool[,] battlefield)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    /// <summary>
    /// Count all ships on the battlefield.
    /// </summary>
    /// <param name="battlefield"></param>
    /// <returns>Count of stones on the battlefield</returns>
    public static int GetShipCount(bool[,] battlefield)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Save the current field to the specified file (as excel csv).
    /// </summary>
    /// <param name="battlefield">the definition for the current field.</param>
    /// <param name="fileName">The destination filename.</param>
    public static void SaveField(bool[,] battlefield, string fileName)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}