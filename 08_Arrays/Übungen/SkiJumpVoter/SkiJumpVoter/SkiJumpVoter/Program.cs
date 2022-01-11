using System;

namespace SkiJumpVoter
{
    public class Program
    {
        const double CALCULATIONPOINT = 120;
        const double POINTSPERMETER = 1.8;
        const double MAXIMUMLENGTH = 200;

        static void Main(string[] args)
        {
            string input;
            double length;
            double stylePointsSum=0;
            double lengthPoints;
            double totalPoints;
            double[] stylePoints = new double[5];
            double points;
            bool arePointsValid;
            double decimalPlaces;
            double sum = 0;
            double minimum = 20;
            double maximum = 0;

            Console.WriteLine("Notenermittlung für Skispringer");
            Console.WriteLine("===============================");
            Console.Write("Weite in Metern [0-{0}]: ",MAXIMUMLENGTH);
            input = Console.ReadLine();
            Console.WriteLine();
            length = double.Parse(input);
            // Weitenpunkte ermitteln
            double distanceToCalculationPoint = length - CALCULATIONPOINT;
            lengthPoints = 60.0 + distanceToCalculationPoint * POINTSPERMETER;
            // Stylepoints für 5 Wertungsrichter erheben lassen
            for (int i = 0; i < stylePoints.Length; i++)
            {
                do
                {
                    arePointsValid = true;
                    Console.Write("Wertungsrichter {0} [0-20]: ", i+1);
                    input = Console.ReadLine();
                    points = double.Parse(input);
                    if (points < 0 || points > 20)
                    {
                        arePointsValid = false;
                    }
                    else
                    {
                        decimalPlaces = points - Math.Floor(points);
                        if (!(decimalPlaces == 0 || decimalPlaces == 0.5))
                        {
                            arePointsValid = false;
                        }
                    }
                    if (!arePointsValid)
                    {
                        Console.WriteLine("Ungültige Eingabe!");
                    }

                } while (!arePointsValid);
                stylePoints[i] = points;
            }
            // Höchste und niedrigste Wertung streichen
            for (int i = 0; i < stylePoints.Length; i++)
            {
                points = stylePoints[i];
                stylePointsSum += points;
                if (points < minimum)
                {
                    minimum = points;
                }
                if (points > maximum)
                {
                    maximum = points;
                }
            }
            stylePointsSum -= minimum;
            stylePointsSum -= maximum;
            totalPoints = lengthPoints + stylePointsSum;
            Console.WriteLine();
            Console.WriteLine("Weitenpunkte: {0:f1} Haltungsnoten: {1:f1} Gesamt: {2:F1}",
                lengthPoints, stylePointsSum, totalPoints);
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
