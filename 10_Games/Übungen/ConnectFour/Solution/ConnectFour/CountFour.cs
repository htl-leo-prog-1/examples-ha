/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CountFour
*--------------------------------------------------------------
*/

namespace ConnectFour
{
    using System;

    public class CountFour
    {
        /// <summary>
        /// Hauptprogramm für 4 gewinnt
        /// Spielfeld anlegen und Spiel abwickeln
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Connect Four");
            Console.WriteLine("============");

            var rows = Tools.ReadNumber("Zeilen  ", 10, 2);
            var cols = Tools.ReadNumber("Spalten ", 10, 2);

            Board.Init(rows, cols, "Vier gewinnt");

            var allocation = new int[rows, cols]; // 0 ==> unbelegt, 1 ==> Spieler 1, 2 ==> Spieler 2
            var winner     = PlayGame(allocation);

            if (winner > 0)
            {
                Console.WriteLine($"Gewinner ist Spieler {winner}!");
            }
            else
            {
                Console.WriteLine("Unentschieden!");
            }

            Board.Exit();
        }

        /// <summary>
        /// Spiel abwickeln bis es einen Sieger gibt oder alle
        /// Felder besetzt sind.
        /// </summary>
        /// <param name="allocation"></param>
        /// <returns></returns>
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
                // Spieler wechselt bei jedem Durchlauf

                Console.Write($"Spieler {playerNumber}, ");

                var col = Tools.ReadNumber("Spalte ", cols - 1, 0);
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
                else // Stein konnte nicht gesetzt werden
                {
                    Console.WriteLine($"Spalte {col} ist bereits gefüllt");
                }
            } while (winnerNumber == 0 && stonesCounter < maxStones);

            return winnerNumber;
        }

        /// <summary>
        /// Für die gegebene Spalte die tiefste noch freie Zeile suchen
        /// und zurückgeben
        /// </summary>
        /// <param name="col">Spalte, in der Stein platziert werden soll</param>
        /// <param name="allocation"></param>
        /// <returns>tiefste freie Position oder -1 falls nichts mehr frei ist</returns>
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
        /// Hat sich durch die Belegung eines Feldes ein Sieger ergeben.
        /// Nicht alle Felder überprüfen, sondern nur die an die neu
        /// gesetzte Position angrenzenden.
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="row">Zeile, die zuletzt belegt wurde</param>
        /// <param name="col">Spalte, die zuletzt belegt wurde</param>
        /// <returns>0 falls kein Gewinner, sonst 1/2</returns>
        public static int IsWinner(int[,] allocation, int row, int col)
        {
            var directions = new int[,]
            {
                { 0, 1 },  // nach links und rechts in der Zeile
                { 1, 0 },  // rauf und runter in der Spalte
                { 1, 1 },  // nach rechts oben und links unten
                { -1, 1 }, // nach links oben und rechts unten
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
        /// Berechnet, wie viele Steine in eine Richtung (z.B. rechts) gespeichert sind.
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="player"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="deltaRow"></param>
        /// <param name="deltaCol"></param>
        /// <returns></returns>
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
        /// Für eine der vier Richtungen (horizontal, vertikal, rechts hinauf, links hinauf 
        /// wird überprüft, ob bereits vier gleiche Steine gesetzt sind.
        /// Es wird immer in zwei Richtungen geprüft, z.B. rechts + links.
        /// </summary>
        /// <param name="allocation">Spielfeld mit Steinen 0/1/2</param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="deltaRow"></param>
        /// <param name="deltaCol"></param>
        /// <returns>1/2 für den Sieger oder 0 falls kein Sieger existiert</returns>
        private static int CheckDirection(int[,] allocation, int row, int col, int deltaRow, int deltaCol)
        {
            int player = allocation[row, col];
            int counterEqual = 1 + // this field
                               CountDirection(allocation, player, row, col, deltaRow,  deltaCol) + // direction 1
                               CountDirection(allocation, player, row, col, -deltaRow, -deltaCol); // direction -1

            return counterEqual >= 4 ? player : 0;
        }

        /// <summary>
        /// Prüft, ob die Koordinaten überhaupt zulässig sind.
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>Koordinaten sind im gültigen Bereich</returns>
        private static bool IsPossible(int[,] allocation, int row, int col)
        {
            return row >= 0 && row < allocation.GetLength(0) &&
                   col >= 0 && col < allocation.GetLength(1);
        }
    }
}