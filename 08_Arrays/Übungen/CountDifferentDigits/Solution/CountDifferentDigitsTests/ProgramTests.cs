using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountDifferentDigits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDifferentDigits.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_SingleDigit()
        {
            int[] digits = { 3 };
            string expected = "3";
            string actual = Program.GetUniqueDigitsString(digits);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T02_MultipleDifferentDigitsInOrder()
        {
            int[] digits = { 3, 6, 7 };
            string expected = "367";
            string actual = Program.GetUniqueDigitsString(digits);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T03_MultipleDifferentDigitsNotInOrder()
        {
            int[] digits = { 7, 3, 6 };
            string expected = "367";
            string actual = Program.GetUniqueDigitsString(digits);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T04_MultipleDifferentDigitsNotInOrderWithDoubles()
        {
            int[] digits = { 7, 3, 6, 5, 3, 9, 7 };
            string expected = "35679";
            string actual = Program.GetUniqueDigitsString(digits);
            Assert.AreEqual(expected, actual);
        }
    }
}