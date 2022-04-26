using System;

namespace Games
{
    public class DriveCar
    {
        /// <summary>
        /// Hauptprogramm für DriveCar
        /// Spielfeld anlegen und Spiel abwickeln
        /// </summary>
        [STAThread]
        private static void Main()
        {
            int maxRow = 10;
            int maxCol = 10;
            int currentRow;
            int currentCol;
            ConsoleKey currentKey;
            DateTime startTime;
            int delayMilliSeconds = 500;
            ConsoleKey readKey;
            double duration;

            Console.WriteLine("DriveCar");
            Console.WriteLine("========");
            // Spielfeld anlegen
            Board.Init(maxCol, maxRow, "Drive Car");
            Console.WriteLine("Spiel starten mit Cursortaste!");
            //init Game
            //col = Board.GetLength(1) - Board.GetLength(1)/2;
            currentCol = maxCol/2;
            currentRow = maxRow/2;
            currentKey = StartGame();
            Board.SetText(currentRow, currentCol, "O");
            startTime = DateTime.Now;
            do
            {
                Board.SetText(currentRow, currentCol, ""); //altes Auto löschen
                switch (currentKey)
                {
                    case ConsoleKey.RightArrow:
                        currentCol++;
                        break;
                    case ConsoleKey.LeftArrow:
                        currentCol--;
                        break;
                    case ConsoleKey.UpArrow:
                        currentRow--;
                        break;
                    case ConsoleKey.DownArrow:
                        currentRow++;
                        break;
                }
                Board.SetText(currentRow,currentCol,"O");
                //neue Richtung erkennen
                if (Console.KeyAvailable)
                {
                    readKey = Console.ReadKey().Key;
                    if (IsKeyValid(readKey))
                    {
                        currentKey = readKey;
                    }
                }
                System.Threading.Thread.Sleep(delayMilliSeconds);

            } while (!IsBorderReached(currentRow, currentCol));
            duration = (DateTime.Now - startTime).TotalSeconds;
            Console.WriteLine("Du bist {0:f2} Sekunden gefahren",duration);
            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

        /// <summary>
        /// Überprüft, ob die gegebene Position gültig ist
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>true wenn ungültig</returns>
        public static bool IsBorderReached(int row, int col)
        {
            if (row >= Board.GetLength(0)||row < 0)
            {
                return true;
            }
            if (col >= Board.GetLength(1) || col < 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Wartet darauf, dass der Spieler
        /// durch Drücken einer Cursortaste startet.
        /// </summary>
        /// <returns>gedrückte Cursortaste</returns>
        private static ConsoleKey StartGame()
        {
            ConsoleKey key;
            do
            {
              key = Console.ReadKey().Key;
            } while (!IsKeyValid(key));
            return key;
        }

        /// <summary>
        /// Ist die Taste eine gültige Cursortaste
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool IsKeyValid(ConsoleKey key)
        {
            return key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow ||
             key == ConsoleKey.RightArrow || key == ConsoleKey.LeftArrow;

        }
    }

}
