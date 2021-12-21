using System;

namespace SkiJumpVoter
{
    public class Program
    {
        const double CALCULATIONPOINT = 120;
        const double POINTSPERMETER = 1.8;

        static void Main(string[] args)
        {
            const double MAXIMUMLENGTH = 200;
            double length;
            double[] stylePoints;
            double stylePointsSum;
            double lengthPoints;
            double totalPoints;
            string input;

            Console.WriteLine("Notenermittlung für Skispringer");
            Console.WriteLine("===============================");
            Console.Write("Weite in Metern [0-{0}]: ",MAXIMUMLENGTH);
            input = Console.ReadLine();
            Console.WriteLine();
            length = double.Parse(input);
            lengthPoints = CalculateLengthPoints(length);
            stylePoints = GetStylePoints();
            stylePointsSum = CalculateStylePointsSum(stylePoints);
            totalPoints = lengthPoints + stylePointsSum;
            Console.WriteLine();
            Console.WriteLine($"Weitenpunkte: {lengthPoints:f1} Haltungsnoten: {stylePointsSum:f1} Gesamt: {totalPoints:F1}");
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Berechnet die Summe der Haltungsnoten. Dabei wird die 
        /// höchste und die niedrigste Wertung ignoriert.
        /// </summary>
        /// <param name="stylePoints"></param>
        /// <returns>Summe der Haltungsnoten</returns>
        public static double CalculateStylePointsSum(double[] stylePoints)
        {
            double sum = 0;
            double minimum = 20;
            double maximum = 0;
            double points;
            for (int i = 0; i < stylePoints.Length; i++)
            {
                points = stylePoints[i];
                sum += points;
                if (points < minimum)
                {
                    minimum = points;
                }
                if (points > maximum)
                {
                    maximum = points;
                }
            }
            sum -= minimum;
            sum -= maximum;
            return sum;
        }


        /// <summary>
        /// Es werde fünf Haltungsnoten eingegeben. Jede Haltungsnote
        /// muss im Bereich 0-20 liegen und ganzen oder halben Punkten
        /// entsprechen.
        /// </summary>
        /// <returns>Array mit fünf Haltungsnoten</returns>
        private static double[] GetStylePoints()
        {
            double[] allPoints = new double[5];
            for (int i = 0; i < allPoints.Length; i++)
            {
                allPoints[i] = GetValidPoints(i + 1);
            }
            return allPoints;
        }

        /// <summary>
        /// Eingabe der Punkte eines Wertungsrichters, bis 
        /// sie gültig sind (0-20, 0.5-Schritte)
        /// </summary>
        /// <param name="judgeNumber"></param>
        /// <returns>Punkte des Wertungsrichters</returns>
        private static double GetValidPoints(int judgeNumber)
        {
            double points;
            points = GetPoints(judgeNumber);
            while (!ArePointsValid(points))
            {
                Console.WriteLine("Ungültige Eingabe!");
                points = GetPoints(judgeNumber);
            }
            return points;
        }

        /// <summary>
        /// Sind die eingegebenen Punkte gültig?
        /// Der Wertebereich muss zwische 0 und 20 liegen.
        /// Es sind nur ganze und halbe Punkte erlaubt.
        /// </summary>
        /// <param name="points"></param>
        /// <returns>Eingegebene Punkte sind in Ordnung</returns>
        public static bool ArePointsValid(double points)
        {
            if (points < 0 || points > 20)
            {
                return false;
            }
            double decimalPlaces = points - Math.Floor(points);
            return IsAlmostEqual(decimalPlaces, 0) || IsAlmostEqual(decimalPlaces, 0.5);
        }

        /// <summary>
        /// Sind die beiden Zahlen bis auf Rundungsfehler im
        /// Tausendstelbereich gleich?
        /// </summary>
        /// <param name="valueA"></param>
        /// <param name="valueB"></param>
        /// <returns>die beiden Zahlen sind gleich</returns>
        private static bool IsAlmostEqual(double valueA, double valueB)
        {
            return Math.Abs(valueA - valueB) < 0.001;
        }

        /// <summary>
        /// Kapselt die Eingabe eines
        /// </summary>
        /// <param name="judgeNumber"></param>
        private static double GetPoints(int judgeNumber)
        {
            string input;
            double points;
            Console.Write($"Wertungsrichter {judgeNumber} [0-20]: ");
            input = Console.ReadLine();
            points = double.Parse(input);
            return points;
        }

        /// <summary>
        /// Weitenpunkte werden ermittelt.
        /// Siehe Angabe
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static double CalculateLengthPoints(double length)
        {
            double distanceToCalculationPoint = length - CALCULATIONPOINT;
            return 60.0 + distanceToCalculationPoint*POINTSPERMETER;
        }
    }
}
