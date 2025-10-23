using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResults.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_ParseTimeTest_OnlySeconds()
        {
            string timeString = "40.70";
            double actual = Program.ParseTime(timeString);
            double expected = 40.7;
            Assert.AreEqual(expected, actual, 0.00001, $"Der String {timeString} sollte den Double-Wert {expected} ergeben.");
        }

        [TestMethod()]
        public void T02_ParseTimeTest_MinutesAndSeconds()
        {
            string timeString = "1:40.70";
            double actual = Program.ParseTime(timeString);
            double expected = 100.7;
            Assert.AreEqual(expected, actual, 0.00001, $"Der String {timeString} sollte den Double-Wert {expected} ergeben.");
        }
    }
}