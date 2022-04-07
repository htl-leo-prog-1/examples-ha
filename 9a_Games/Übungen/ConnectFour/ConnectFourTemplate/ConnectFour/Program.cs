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

            //!

            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}
