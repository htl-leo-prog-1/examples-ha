using System;

namespace SkiJumpVoter
{
    public class Program
    {
        const double CALCULATIONPOINT = 120;
        const double POINTSPERMETER = 1.8;

        static void Main(string[] args)
        {
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Weitenpunkte werden ermittelt.
        /// Siehe Angabe
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static double CalculateLengthPoints(double length)
        {
            throw new NotImplementedException();
        }
    }
}
