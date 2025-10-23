/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: BattleShipGame
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
            var lines = File.ReadAllLines(fileName);
            var ships = new Ship[lines.Length - 1]; // -1 because of header

            for (int i = 1; i < lines.Length; i++)
            {
                ships[i - 1] = ReadShipFromCsvLine(lines[i]);
            }

            return ships;
        }

        public static Ship ReadShipFromCsvLine(string line)
        {
            var cols = line.Split(';');
            var ship = new Ship();

            ship.Row        = int.Parse(cols[0]);
            ship.Col        = int.Parse(cols[1]);
            ship.ShipSize   = int.Parse(cols[2]);
            ship.IsVertical = cols[3].ToUpper() == "V";

            return ship;
        }

        /// <summary>
        /// Print the battle-field to the console.
        /// </summary>
        /// <param name="ships"></param>
        public static void Print(Ship[] ships)
        {
            var field = CreateField(ships);

            string line = "   +";
            Console.Write("   ");
            for (int col = 0; col < field.GetLength(1); col++)
            {
                line += "-+";
                Console.Write($" {(char)('A' + col)}");
            }

            Console.WriteLine();
            Console.WriteLine(line);

            for (int row = 0; row < field.GetLength(0); row++)
            {
                Console.Write($"{row + 1,3}|");
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    var ch = field[row, col] ? 'x' : ' ';
                    Console.Write($"{ch}|");
                }

                Console.WriteLine();
                Console.WriteLine(line);
            }
        }

        public static bool IsValid(Ship[] ships)
        {
            return CreateField(ships) != null;
        }

        public static bool IsValidShipAmount(Ship[] ships)
        {
            int[] amounts = new int[ShouldBeAmounts.Length];
            foreach (var ship in ships)
            {
                if (!Tools.InRange(ship.ShipSize, ShouldBeAmounts.Length - 1, 0))
                {
                    return false;
                }

                amounts[ship.ShipSize]++;
            }

            return Tools.IsEqual(amounts, ShouldBeAmounts);
        }

        /// <summary>
        /// Create a valid battle-field from a ship array.
        /// </summary>
        /// <param name="ships">The list of ships.</param>
        /// <returns>valid battle-field or null (if invalid).</returns>
        public static bool[,] CreateField(Ship[] ships)
        {
            if (!IsValidShipAmount(ships))
            {
                return null;
            }

            var field = new bool[Size, Size];

            foreach (var ship in ships)
            {
                if (!ArrangeShip(field, ship))
                {
                    return null;
                }
            }

            return field;
        }

        public static bool CanArrangeShip(bool[,] field, Ship ship)
        {
            int row = ship.Row;
            int col = ship.Col;

            for (int i = 0; i < ship.ShipSize; i++)
            {
                if (!IsInRange(field, row, col) || !IsFree(field, row, col))
                {
                    return false;
                }

                if (ship.IsVertical)
                {
                    row++;
                }
                else
                {
                    col++;
                }
            }

            return true;
        }

        /// <summary>
        /// Arrange (set) a ship on the battle-field.
        /// </summary>
        /// <param name="field">The field where to set the ship.</param>
        /// <param name="ship"></param>
        /// <returns>true if the ship can be arranged, otherwise false</returns>
        public static bool ArrangeShip(bool[,] field, Ship ship)
        {
            if (!CanArrangeShip(field, ship))
            {
                return false;
            }

            int row = ship.Row;
            int col = ship.Col;

            for (int i = 0; i < ship.ShipSize; i++)
            {
                field[row, col] = true;
                if (ship.IsVertical)
                {
                    row++;
                }
                else
                {
                    col++;
                }
            }

            return true;
        }

        public static bool IsFree(bool[,] field, int row, int col)
        {
            int fromRow = Math.Max(row - 1, 0);
            int toRow   = Math.Min(row + 1, field.GetLength(0) - 1);

            int fromCol = Math.Max(col - 1, 0);
            int toCol   = Math.Min(col + 1, field.GetLength(1) - 1);

            for (int i = fromRow; i <= toRow; i++)
            {
                for (int j = fromCol; j <= toCol; j++)
                {
                    if (field[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsInRange(bool[,] field, int row, int col)
        {
            return Tools.InRange(row, field.GetLength(0) - 1, 0) &&
                   Tools.InRange(col, field.GetLength(1) - 1, 0);
        }
    }
}