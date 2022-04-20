namespace TicTacToe
{
    using System;

    /// <summary>
    /// Implementiert das Spiel TicTacToe mit Methoden der
    /// schrittweisen Verfeinerung
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            int    counter = 0;
            Random random  = new Random();
            int    playerIndex;
            int    winnerIndex = -1; //0, 1 wer hat gewonnen, -1 kein Sieger
            int    position;
            int    row;
            int    col;
            Console.WriteLine("TicTacToe");
            Console.WriteLine("=========");
            playerIndex = random.Next(0, 2);
            Board.Init(3, 3, "TicTacToe");
            InitPositions(); // Spielfeld initialisieren
            do
            {
                position = GetStonePosition(playerIndex);
                row      = GetRowFromPosition(position);
                col      = GetColFromPosition(position, row);
                if (playerIndex == 0)
                {
                    Board.SetText(row, col, "O", "Red");
                }
                else
                {
                    Board.SetText(row, col, "X", "Green");
                }

                counter++;
                if (counter >= 5) // erst dann kann es einen Sieger geben
                {
                    winnerIndex = CheckWinner();
                }

                playerIndex = 1 - playerIndex;
            } while (counter < 9 && winnerIndex == -1);

            if (winnerIndex != -1)
            {
                Console.WriteLine("Gewonnen hat der Spieler mit der Nummer {0}", winnerIndex);
            }
            else
            {
                Console.WriteLine("Das Spiel endete unentschieden");
            }

            Console.Write("Beenden mit der Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Überprüft, ob es bereits einen Sieger gibt.
        /// Liefert die Spielernummer (0,1) oder -1 
        /// falls es noch keinen Sieger gibt.
        /// </summary>
        /// <returns></returns>
        private static int CheckWinner()
        {
            // Diagonale \
            if (Board.GetText(0, 0) == Board.GetText(1, 1) &&
                Board.GetText(1, 1) == Board.GetText(2, 2))
            {
                return GetPlayerIndexFromCell(0, 0);
            }

            // Diagonale /
            if (Board.GetText(0, 2) == Board.GetText(1, 1) &&
                Board.GetText(1, 1) == Board.GetText(2, 0))
            {
                return GetPlayerIndexFromCell(1, 1);
            }

            // Zeilen
            for (int row = 0; row < 3; row++)
            {
                if (Board.GetText(row, 0) == Board.GetText(row, 1) &&
                    Board.GetText(row, 1) == Board.GetText(row, 2))
                {
                    return GetPlayerIndexFromCell(row, 0);
                }
            }

            // Spalten
            for (int col = 0; col < 3; col++)
            {
                if (Board.GetText(0, col) == Board.GetText(1, col) &&
                    Board.GetText(1, col) == Board.GetText(2, col))
                {
                    return GetPlayerIndexFromCell(0, col);
                }
            }

            return -1;
        }

        /// <summary>
        /// Ermittelt für Zeile Spalte den aktuelen Spieler.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private static int GetPlayerIndexFromCell(int row, int col)
        {
            if (Board.GetText(row, col) == "X")
            {
                return 1;
            }
            else if (Board.GetText(row, col) == "O")
            {
                return 0;
            }

            return -1;
        }


        /// <summary>
        /// Liefert für die Position die Zeile
        /// </summary>
        /// <param name="position"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static int GetColFromPosition(int position, int row)
        {
            return position + 3 * row - 7;
        }

        /// <summary>
        /// Liefert für die Position die Spalte
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private static int GetRowFromPosition(int position)
        {
            return 2 - ((position - 1) / 3);
        }


        /// <summary>
        /// Der aktuelle Spieler wird solange aufgefordert,
        /// eine Position einzugeben, bis diese gültig ist.
        /// Eine Position ist ungültig, wenn eine ungültige
        /// Zahl eingebeben wird, oder die Position bereits belegt ist. </summary>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        private static int GetStonePosition(int playerIndex)
        {
            string input;
            int    position;
            do
            {
                Console.Write("Spieler {0}, Position [1-9]: ", playerIndex);
                input    = Console.ReadLine();
                position = Convert.ToInt32(input);
            } while (!CheckPosition(position));

            return position;
        }

        /// <summary>
        /// Eine Position ist ungültig, wenn eine ungültige
        /// Zahl eingebeben wird, oder die Position im Board
        /// bereits belegt ist. 
        /// </summary>
        /// <param name="position">Feldnummer</param>
        /// <returns>Position ist ok?</returns>
        public static bool CheckPosition(int position)
        {
            int row;
            int col;
            if (position > 9 || position < 1)
            {
                return false;
            }

            row = GetRowFromPosition(position);
            col = GetColFromPosition(position, row);
            if (Board.GetText(row, col) != "X" &&
                Board.GetText(row, col) != "O")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Initialisiert die Beschriftung des Boards nach Fabians' Vorstellungen.
        /// </summary>
        public static void InitPositions()
        {
            // Beschriftung des Spielfeldes entsprechend der Nummerntastatur
            // in hellgrau
            int[,] numbers =
            {
                { 7, 8, 9 },
                { 4, 5, 6 },
                { 1, 2, 3 }
            };
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Board.SetText(row, col, numbers[row, col].ToString(), "LightGrey");
                }
            }
        }
    }
}