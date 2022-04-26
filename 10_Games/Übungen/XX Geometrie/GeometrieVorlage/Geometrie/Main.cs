using System;
using System.Windows.Forms;

namespace Spiele
{
    class Geometrie
    {

        /// <summary>
        /// Hauptprogramm für Zeichenprogramm
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Geometrie");
            Console.WriteLine("=========");
            Board.Init(20, 20, "Geometrie");

            //!

            Console.WriteLine("Beenden mit Eingabetaste  ...");
            Console.ReadLine();
            Board.Exit();
        }

    }
}
