using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Program
    {
        /// <summary>
        /// Hauptprogramm für 4 gewinnt
        /// Spielfeld anlegen und Spiel abwickeln
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] allocation;  // 0 ==> unbelegt, 1 ==> Spieler 1, 2 ==> Spieler 2
            int cols;
            int rows;
            int winner;

            Console.WriteLine("Connect Four");
            Console.WriteLine("============");
            Console.Write("Zeilen: ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Spalten: ");
            cols = Convert.ToInt32(Console.ReadLine());
            Board.Init(rows, cols, "Vier gewinnt");
            allocation = new int[rows, cols];
            winner = PlayGame(allocation);
            if (winner > 0)
            {
                Console.WriteLine("Gewinner ist Spieler {0}!", winner);
            }
            else // Unentschieden
            {
                Console.WriteLine("Unentschieden!");
            }
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
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
            int rows = allocation.GetLength(0);
            int cols = allocation.GetLength(1);
            int row;
            int col;
            int playerNumber = 1;
            int winnerNumber = 0;
            int stonesCounter=0;
            Console.WriteLine();
            // Solange es keinen Sieger gibt und noch ein freier Platz existiert
            do
            {
                // Spieler wechselt bei jedem Durchlauf
                Console.Write(" Spieler {0}, ", playerNumber);
                col = ReadInt("Spalte: ", cols - 1);
                row = GetFreeRow(allocation, col);
                if (row >= 0)  // ist das Setzen überhaupt möglich
                {
                    stonesCounter++;
                    allocation[row, col] = playerNumber;  // In Logik eintragen
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
                    // Prüfen, ob es bereits einen Sieger gibt
                    winnerNumber = IsWinner(allocation, row, col);
                }
                else  // Stein konnte nicht gesetzt werden
                {
                    Console.WriteLine("Spalte {0} ist bereits gefüllt", col);
                }
            }
            while (winnerNumber == 0 && stonesCounter < rows * cols);
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
            // Freie Höhe suchen
            int row = allocation.GetLength(0) - 1; // unten beginnen mit der Suche nach freiem Feld
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
            int winner;
            // deltaRow == 0 ==> Zeile bleibt gleich, deltaCol == 1 ==> nach links und rechts in der Zeile
            if ((winner = CheckOneDirection(allocation, row, col, 0, 1)) > 0)
            {
                return winner;
            }
            // Spalte bleibt gleich ==> rauf und runter in der Spalte
            if ((winner = CheckOneDirection(allocation, row, col, 1, 0)) > 0) 
            {
                return winner;
            }
            // nach rechts oben und links unten
            if ((winner = CheckOneDirection(allocation, row, col, 1, 1)) > 0)
            {
                return winner;
            }
            // nach links oben und rechts unten
            if ((winner = CheckOneDirection(allocation, row, col, -1, 1)) > 0)
            {
                return winner;
            }
            return 0;
        }

        /// <summary>
        /// Für eine der vier Richtungen (horizontal, vertikal, rechts hinauf, links hinauf 
        /// wird überprüft, ob bereits vier gleiche Steine gesetzt sind.
        /// </summary>
        /// <param name="allocation">Spielfeld mit Steinen 0/1/2</param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="deltaRow"></param>
        /// <param name="deltaCol"></param>
        /// <returns>1/2 für den Sieger oder 0 falls kein Sieger existiert</returns>
        private static int CheckOneDirection(int[,] allocation, int row, int col,
            int deltaRow, int deltaCol)
        {
            int player = allocation[row, col];
            int counterEqual = 1;  // Der gerade gesetzte Stein zählt sicher
                                   // Solange Nachbarstein gleichem Spieler gehört und 
                                   // Nachbarposition gültig ist ==> Zähler erhöhen
                                   // Zuerst nach rechts richtige Steine zählen
            int actRow = row + deltaRow;
            int actCol = col + deltaCol;
            while (IsPossible(allocation, actRow, actCol) && allocation[actRow, actCol] == player)
            {
                counterEqual++;
                actRow += deltaRow;
                actCol += deltaCol;
            }
            // Dann nach links richtige Steine zählen
            actRow = row - deltaRow;
            actCol = col - deltaCol;
            while (IsPossible(allocation, actRow, actCol) && allocation[actRow, actCol] == player)
            {
                counterEqual++;
                actRow -= deltaRow;
                actCol -= deltaCol;
            }
            if (counterEqual >= 4)
            {
                return player;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Prüft, ob die Koordinaten überhaupt zulässig sind.
        /// </summary>
        /// <param name="allocation"></param>
        /// <param name="actRow"></param>
        /// <param name="actCol"></param>
        /// <returns>Koordinaten sind im gültigen Bereich</returns>
        private static bool IsPossible(int[,] allocation, int row, int col)
        {
            return row >= 0 && row < allocation.GetLength(0) &&
                    col >= 0 && col < allocation.GetLength(1);
        }


        /// <summary>
        /// Integerziffer wird von der Tastatur eingelesen.
        /// Dabei wird die maximale Zahl berücksichtigt
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxNumber">maximale Zeilen/Spaltennummer</param>
        /// <returns></returns>
        static int ReadInt(string text, int maxNumber)
        {
            int number;
            int i;
            string input;
            do
            {
                Console.Write(text + " (0-{0}): ", maxNumber);
                input = Console.ReadLine();
                // Prüfen, ob alle Zeichen Ziffern darstellen
                i = 0;
                while (i < input.Length && char.IsNumber(input[i]))
                {
                    i++;
                }
                if (i == input.Length)  // alle Zeichen sind Ziffern
                {
                    number = Convert.ToInt32(input);
                }
                else  // fehlerhafte Zeichen eingegeben
                {
                    number = -1;
                }
            }
            while (number < 0 || number > maxNumber);
            return number;
        }
    }
}
