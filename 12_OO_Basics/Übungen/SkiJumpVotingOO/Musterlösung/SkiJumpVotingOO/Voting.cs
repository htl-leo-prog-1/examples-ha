using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiJumpVotingOO
{
    /// <summary>
    /// Verwaltet ein Voting eines Skispringers für einen Durchgang.
    /// </summary>
    public class Voting
    {
        private const double CalculationPoint = 120;
        const double PointsPerMeter = 1.8;


        private double[] _stylePoints = new double[5];
        private double _length;

        public void SetLength(double length)
        {
            _length = length;
        }

        /// <summary>
        /// Übergibt für einen Wertungsrichter die Haltungsnoten
        /// </summary>
        /// <param name="judge">Wertungsrichter 0-4</param>
        /// <param name="points">Haltungsnoten 0-20 in 0,5-er Schritten</param>
        /// <returns>false, falls Wertungsrichter oder Note nicht stimmt</returns>
        public bool SetStylePoints(int judge, double points)
        {
            if (judge <0 || judge >= 5)
            {
                return false;
            }
            if (!ArePointsValid(points))
            {
                return false;
            }
            _stylePoints[judge] = points;
            return true;
        }

        /// <summary>
        /// Berechnet die Summe der Haltungsnoten. Dabei wird die 
        /// höchste und die niedrigste Wertung ignoriert.
        /// </summary>
        /// <returns>Summe der Haltungsnoten</returns>
        public double GetStylePointsSum()
        {
            double sum = 0;
            double minimum = 20;
            double maximum = 0;
            double points;
            for (int i = 0; i < _stylePoints.Length; i++)
            {
                points = _stylePoints[i];
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
        /// Weitenpunkte werden ermittelt.
        /// Siehe Angabe
        /// </summary>
        /// <returns></returns>
        public double GetLengthPoints()
        {
            double distanceToCalculationPoint = _length - CalculationPoint;
            return 60.0 + distanceToCalculationPoint * PointsPerMeter;
        }

        /// <summary>
        /// Liefert die Gesamtpunkte des Votings
        /// </summary>
        /// <returns></returns>
        public double GetTotalPoints()
        {
            return GetLengthPoints() + GetStylePointsSum();
        }
    }
}
