/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: BattleShip
*--------------------------------------------------------------
*/

namespace BattleShip
{
    using System;

    public class Program
    {
        private const int FieldSize = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("BattleShip Validator");
            Console.WriteLine("=====================");

            string fileName = "Ships.csv";

            if (args.Length >= 1)
            {
                fileName = args[0];
            }

            Console.WriteLine($"Ships from: {fileName}");
            Console.WriteLine();

            var ships = BattleShip.ReadFromCsv(fileName);

            if (BattleShip.IsValid(ships))
            {
                BattleShip.Print(ships);
            }
            else
            {
                Console.WriteLine("The battle-ship definition is invalid!");
            }
        }
    }
}