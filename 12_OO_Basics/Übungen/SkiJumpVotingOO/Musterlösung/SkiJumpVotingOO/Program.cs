using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiJumpVotingOO
{
    class Program
    {
        static void Main()
        {
            const double maximumlength = 200;
            double length;
            string input;
            Voting voting = new Voting();

            Console.WriteLine("Notenermittlung für Skispringer");
            Console.WriteLine("===============================");
            Console.Write("Weite in Metern [0-{0}]: ", maximumlength);
            input = Console.ReadLine();
            Console.WriteLine();
            length = double.Parse(input);
            voting.SetLength(length);
            SetStylePoints(voting);

            Console.WriteLine();
            Console.WriteLine($"Weitenpunkte: {voting.GetLengthPoints():f1} Haltungsnoten: {voting.GetStylePointsSum():f1} Gesamt: {voting.GetTotalPoints():F1}");
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Es werden fünf Haltungsnoten eingegeben und an das Voting übertragen.
        ///  Jede Haltungsnote muss im Bereich 0-20 liegen und ganzen oder halben Punkten
        /// entsprechen.
        /// </summary>
        /// <param name="voting"></param>
        private static void SetStylePoints(Voting voting)
        {
            for (int i = 0; i < 5; i++)
            {
                var points = GetPoints(i+1);
                while (!Voting.ArePointsValid(points))
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    points = GetPoints(i+1);
                }
                voting.SetStylePoints(i, points);
            }
        }

        /// <summary>
        /// Kapselt die Eingabe eines
        /// </summary>
        /// <param name="judgeNumber"></param>
        private static double GetPoints(int judgeNumber)
        {
            double points;
            Console.Write($"Wertungsrichter {judgeNumber} [0-20]: ");
            var input = Console.ReadLine();
            points = double.Parse(input);
            return points;
        }


    }
}
