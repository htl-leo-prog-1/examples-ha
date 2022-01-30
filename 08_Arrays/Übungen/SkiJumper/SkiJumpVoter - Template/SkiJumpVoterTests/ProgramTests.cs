using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiJumpVoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiJumpVoter.Program;

namespace SkiJumpVoter.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void T01_ArePointsValid_Simple()
        {
            Assert.IsTrue(ArePointsValid(19), "Ganze Zahlen sind zulässig");
            Assert.IsTrue(ArePointsValid(19.5), "Halbe Punkte sind zulässig");
        }

        [TestMethod()]
        public void T02_ArePointsValid_Range()
        {
            Assert.IsFalse(ArePointsValid(20.01), "Zu hoch");
            Assert.IsFalse(ArePointsValid(-0.1), "Zu niedrig");
        }

        [TestMethod()]
        public void T03_ArePointsValid_Value()
        {
            Assert.IsFalse(ArePointsValid(19.1), "Nur ganze und halbe erlaubt");
            Assert.IsFalse(ArePointsValid(1.6), "Nur ganze und halbe erlaubt");
        }

        [TestMethod()]
        public void T11_CalculateLengthPointsTest_Simple()
        {
            Assert.AreEqual(69, CalculateLengthPoints(125), "125 Meter ergibt 69 Weitenpunkte");
        }
        [TestMethod()]
        public void T12_CalculateLengthPointsTest_Minimum()
        {
            Assert.AreEqual(-66, CalculateLengthPoints(50), "50 Meter ergibt -66 Weitenpunkte");
        }

        [TestMethod()]
        public void T21_CalculateStylePointsSumTest_Simple()
        {
            double[] points = { 17.5, 18.5, 19, 18.5, 19 };
            double result = CalculateStylePointsSum(points);
            Assert.AreEqual(56, result, 0.001, "Siehe Angabe");
        }

        [TestMethod()]
        public void T22_CalculateStylePointsSumTest_Same()
        {
            double[] points = { 17.5, 17.5, 17.5, 17.5, 17.5 };
            double result = CalculateStylePointsSum(points);
            Assert.AreEqual(17.5 * 3, result, 0.001, "Siehe Angabe");
        }

        [TestMethod()]
        public void T23_CalculateStylePointsSumTest_Mixed()
        {
            double[] points = { 17.5, 17.5, 17.5, 19.5, 19.5 };
            double result = CalculateStylePointsSum(points);
            Assert.AreEqual(17.5 * 2 + 19.5, result, 0.001, "Siehe Angabe");
        }
    }
}