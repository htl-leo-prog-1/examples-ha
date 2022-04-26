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


        public void SetLength(double length)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Übergibt für einen Wertungsrichter die Haltungsnoten
        /// </summary>
        /// <param name="judge">Wertungsrichter 0-4</param>
        /// <param name="points">Haltungsnoten 0-20 in 0,5-er Schritten</param>
        /// <returns>false, falls Wertungsrichter oder Note nicht stimmt</returns>
        public bool SetStylePoints(int judge, double points)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Berechnet die Summe der Haltungsnoten. Dabei wird die 
        /// höchste und die niedrigste Wertung ignoriert.
        /// </summary>
        /// <returns>Summe der Haltungsnoten</returns>
        public double GetStylePointsSum()
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
        /// <returns></returns>
        public double GetLengthPoints()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liefert die Gesamtpunkte des Votings
        /// </summary>
        /// <returns></returns>
        public double GetTotalPoints()
        {
            throw new NotImplementedException();
        }
    }
}
