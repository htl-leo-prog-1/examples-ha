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

            Board.Clear();
            Console.Clear();
            Console.WriteLine("Schifferl versenken, Zielen");
            Console.WriteLine("===========================");
            Console.WriteLine();


            Console.ReadLine();
            // Spielfeld freigeben
            Board.Exit();
        }
        

        /// <summary>
        /// Es wird versucht, ein Schiff an die gewünschte Position zu setzen.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>Konnte das Schiff positioniert werden?</returns>
        public static bool SetShipToPosition(int row, int col)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

	}
}
