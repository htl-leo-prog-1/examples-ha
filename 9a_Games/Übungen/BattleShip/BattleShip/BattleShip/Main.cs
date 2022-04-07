using System;

namespace BattleShip
{
	public class Program
	{
		const int MAX_SHOTS = 10;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main()
        {   
            Console.WriteLine("Schifferl versenken, Positionieren");
            Console.WriteLine("==================================");
            Console.Write("Feldgröße: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.Write("Anzahl Schiffe: ");
            int shipsCount = Convert.ToInt32(Console.ReadLine());
            // Spielfeld anlegen und Titel vergeben
            Board.Init(size, size, "Schiffe versenken");
            Console.WriteLine();

            // Schiffe setzen
            bool[,] positions = SetShipPositions(shipsCount);
            Console.WriteLine("Weiter zum Schiffe versenken mit Enter-Taste!");
            Console.ReadKey();

            // Spielfeld löschen
            Board.Clear();
            Console.Clear();
            Console.WriteLine("Schifferl versenken, Zielen");
            Console.WriteLine("===========================");
            Console.WriteLine();
            int tries;
            if (SinkShips(positions, shipsCount, out tries))
            {
                Console.WriteLine("Bravo, du hast {0} Versuche benötigt!", tries);
            }
            else
            {
                Console.WriteLine("Leider nicht alle Schiffe versenkt!");
            }

            Console.ReadLine();

            // Spielfeld freigeben
            Board.Exit();
        }
        
        /// <summary>
        /// Die Positionen der Schiffe setzen
        /// </summary>
        /// <param name="countShips">Schiffe zu setzen</param>
        /// <returns>Positionen, an denen Schiffe gesetzt sind</returns>
		public static bool[,] SetShipPositions(int countShips)
		{
            bool[,] positions = new bool[Board.GetLength(0), Board.GetLength(1)];

			Console.WriteLine(countShips + " Schiffe positionieren (Zeile/Spalte 0-{0}", 
                Board.GetLength(0) - 1);
            int count = 1;
            do
			{
				Console.WriteLine();
				Console.WriteLine(count + ". Schiff");
				int row = ReadInt("Zeile " + count, Board.GetLength(0) - 1);
				int col = ReadInt("Spalte " + count, Board.GetLength(1) - 1);
				if (SetShipToPosition(row, col))				
				{
					count++;
				}
				else
				{
					Console.WriteLine("Position {0}/{1} ist bereits belegt!",row,col);
				}
			}
			while (count <= countShips);
            // Positionen in bool-Array übernehmen
            for (int y = 0; y < Board.GetLength(0); y++)
            {
                for (int x = 0; x < Board.GetLength(1); x++)
                {
                    positions[x, y] = Board.GetText(y, x).Length > 0;
                }
            }
            return positions;
		}

        /// <summary>
        /// Es wird versucht, ein Schiff an die gewünschte Position zu setzen.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>Konnte das Schiff positioniert werden?</returns>
        public static bool SetShipToPosition(int row, int col)
        {
            // Ist Zeile und Spalte überhaupt gültig
            if (row < 0 || row >= Board.GetLength(0) || col < 0 || col >= Board.GetLength(1))
            {
                return false;
            }
            if (Board.GetText(row, col).Length == 0)
            {
                // Zeichen auf Board ausgeben
                Board.SetText(row, col, "x");
                return true;
            }
            else
            {
                return false;
            }
        }

	    /// <summary>
	    /// Zweiter Spieler versucht, die Schiffe zu treffen.
	    /// </summary>
	    /// <param name="positions">Wo liegen die Schiffe</param>
	    /// <param name="countShips">Anzahl zu versenkender Schiffe</param>
	    /// <param name="attempts"></param>
	    /// <returns>Alle Schiffe wurden versenkt</returns>
	    /// <summary/>
	    static bool SinkShips(bool[,] positions, int countShips, out int attempts)
		{
			int sinkedShips = 0;
			attempts = 0;
			do
			{
				attempts++;
				Console.WriteLine();
				Console.WriteLine(attempts + ". Versuch");
				int row = ReadInt("Zeile ", Board.GetLength(0) - 1);
                int col = ReadInt("Spalte ", Board.GetLength(1) - 1);
				if (Board.GetText(row, col) != "X") // Nur wenn ein Ziel nicht bereits anvisiert wird
				{
					Board.SetText(row, col, "?");
                    System.Threading.Thread.Sleep(1000);
                    if (positions[col, row])  // Treffer
                    {
                        sinkedShips++;
                        Console.WriteLine("Gut gemacht!");
                        Board.SetText(row, col, "X", "Green");
                    }
                    else  // kein Treffer
                    {
                        Console.WriteLine("Leider daneben!");
                        Board.SetText(row, col, "");
                    }
                }
			}
			while (sinkedShips < countShips && attempts < MAX_SHOTS);
			return (sinkedShips == countShips);
		}

        /// <summary>
        /// Integerziffer wird von der Tastatur eingelesen.
        /// Dabei wird der maximale Wert der Zahl berücksichtigt
        /// </summary>
        /// <param name="text">Aufforderungstext an den Benutzer</param>
        /// <param name="maxNumber">maximale Zeilen/Spaltennummer</param>
        /// <returns></returns>
        static int ReadInt(string text, int maxNumber)
        {
            int number;
            do
            {
                Console.Write("{0} (0-{1}): ", text, maxNumber);
                string input = Console.ReadLine();
                // Prüfen, ob alle Zeichen Ziffern darstellen
                int i = 0;
                while (input != null && i < input.Length && char.IsNumber(input[i]))
                {
                    i++;
                }
                if (input != null && i == input.Length)  // alle Zeichen sind Ziffern
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

        /// <summary>
        /// Der minimale Abstand zwischen dem Mittelpunkt der gefragten Zelle
        /// und dem Mittelpunkt des nächstgelegenen Schiffs (in Kästchen) am Board wird
        /// ermittelt und zurückgegeben. Existiert noch kein Schiff am Board
        /// wird double.MaxValue retourniert
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>Minimaler Abstand</returns>
        public static double GetMinDistanceToNextShip(int row, int col)
        {
            double minDistance = double.MaxValue;
            // Ist Zeile und Spalte überhaupt gültig
            if (row < 0 || row >= Board.GetLength(0) || col < 0 || col >= Board.GetLength(1))
            {
                return minDistance;
            }
            double distance;
            for (int y = 0; y < Board.GetLength(0); y++)
            {
                for (int x = 0; x < Board.GetLength(1); x++)
                {
                    if (Board.GetText(y, x).Length > 0)
                    {

                        distance = GetDistance(row, col, y, x);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                        }
                    }
                }
            }
            return minDistance;
        }

        /// <summary>
        /// Distanz zweier Positionen am Board ermitteln
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        /// <returns></returns>
        private static double GetDistance(int row1, int col1, int row2, int col2)
        {
            return Math.Sqrt((row1 - row2) * (row1 - row2) + (col1 - col2) * (col1 - col2));
        }


	}
}
