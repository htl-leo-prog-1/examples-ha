/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: BattleShip
* see https://en.wikipedia.org/wiki/Battleship_(game)
*--------------------------------------------------------------
*/

namespace BattleShip
{
    using System;
    using System.IO;

    public static class BattleShip
    {
        /// <summary>
        /// Constant for squared size of battlefield
        /// </summary>
        private const  int   Size            = 10;
        /// <summary>
        /// Constant for amount of ships.
        /// The index is used as ship-size.
        /// </summary>
        private static int[] ShouldBeAmounts = new int[] { 0, 2, 4, 3, 2, 1 };

        /// <summary>
        /// Read all ships from a csv file into an array of "Ship". 
        /// </summary>
        /// <param name="fileName">Csv file-name</param>
        /// <returns>The array or "Ship".</returns>
        public static Ship[] ReadFromCsv(string fileName)
        {
            //TODO Implement ReadFromCsv 
        }

        /// <summary>
        /// Print the battle-field to the console.
        /// </summary>
        /// <param name="ships"></param>
        public static void Print(Ship[] ships)
        {
            //TODO Implement Print 
        }

        /// <summary>
        /// Create a valid battle-field from a ship array.
        /// </summary>
        /// <param name="ships">The list of ships.</param>
        /// <returns>valid battle-field or null (if invalid).</returns>
        public static bool[,] CreateField(Ship[] ships)
        {
            //TODO Implement CreateField 
        }

        /// <summary>
        /// Arrange (set) a ship on the battle-field.
        /// </summary>
        /// <param name="field">The field where to set the ship.</param>
        /// <param name="ship"></param>
        /// <returns>true if the ship can be arranged, otherwise false</returns>
        public static bool ArrangeShip(bool[,] field, Ship ship)
        {
            //TODO Implement ArrangeShip 
        }
    }
}