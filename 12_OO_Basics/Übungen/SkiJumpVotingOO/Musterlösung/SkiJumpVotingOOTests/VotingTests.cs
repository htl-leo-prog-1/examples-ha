using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiJumpVotingOO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiJumpVotingOO.Tests
{
    [TestClass()]
    public class VotingTests
    {
        [TestMethod()]
        public void T01_ArePointsValid_Simple()
        {
            Assert.IsTrue(Voting.ArePointsValid(19), "Ganze Zahlen sind zulässig");
            Assert.IsTrue(Voting.ArePointsValid(19.5), "Halbe Punkte sind zulässig");
        }

        [TestMethod()]
        public void T02_ArePointsValid_Range()
        {
            Assert.IsFalse(Voting.ArePointsValid(20.01), "Zu hoch");
            Assert.IsFalse(Voting.ArePointsValid(-0.1), "Zu niedrig");
        }

        [TestMethod()]
        public void T03_ArePointsValid_Value()
        {
            Assert.IsFalse(Voting.ArePointsValid(19.1), "Nur ganze und halbe erlaubt");
            Assert.IsFalse(Voting.ArePointsValid(1.6), "Nur ganze und halbe erlaubt");
        }

        [TestMethod()]
        public void T11_CalculateLengthPointsTest_Simple()
        {
            Voting voting = new Voting();
            voting.SetLength(125);
            Assert.AreEqual(69, voting.GetLengthPoints(), 0.001, "125 Meter ergibt 69 Weitenpunkte");
        }

        [TestMethod()]
        public void T12_CalculateLengthPointsTest_Minimum()
        {
            Voting voting = new Voting();
            voting.SetLength(50);
            Assert.AreEqual(-66, voting.GetLengthPoints(), 0.001, "50 Meter ergibt -66 Weitenpunkte");
        }

        [TestMethod()]
        public void T21_CalculateStylePointsSumTest_Simple()
        {
            Voting voting = new Voting();
            double[] points = { 17.5, 18.5, 19, 18.5, 19 };
            for (int i = 0; i < points.Length; i++)
            {
                voting.SetStylePoints(i, points[i]);
            }
            double result = voting.GetStylePointsSum();
            Assert.AreEqual(56, result, 0.001, "Siehe Angabe");
        }

        [TestMethod()]
        public void T22_CalculateStylePointsSumTest_Same()
        {
            double[] points = { 17.5, 17.5, 17.5, 17.5, 17.5 };
            Voting voting = new Voting();
            for (int i = 0; i < points.Length; i++)
            {
                voting.SetStylePoints(i, points[i]);
            }
            double result = voting.GetStylePointsSum();
            Assert.AreEqual(17.5 * 3, result, 0.001, "Siehe Angabe");
        }

        [TestMethod()]
        public void T23_CalculateStylePointsSumTest_Mixed()
        {
            double[] points = { 17.5, 17.5, 17.5, 19.5, 19.5 };
            Voting voting = new Voting();
            for (int i = 0; i < points.Length; i++)
            {
                voting.SetStylePoints(i, points[i]);
            }
            double result = voting.GetStylePointsSum();
            Assert.AreEqual(17.5 * 2 + 19.5, result, 0.001, "Siehe Angabe");
        }

        [TestMethod()]
        public void T31_GetTotalPoints()
        {
            double[] points = { 17.5, 18.5, 19.0, 18.5, 19.0 };
            Voting voting = new Voting();
            voting.SetLength(125);
            for (int i = 0; i < points.Length; i++)
            {
                voting.SetStylePoints(i, points[i]);
            }
            double result = voting.GetTotalPoints();
            Assert.AreEqual(125, result, 0.001, "Siehe Angabe");
        }
    }
}