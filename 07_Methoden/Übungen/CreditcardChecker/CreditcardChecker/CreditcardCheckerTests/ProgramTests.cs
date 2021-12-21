using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditcardChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditcardChecker.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        /// <summary>
        ///A test for IsCreditCardValid
        ///</summary>
        [TestMethod()]
        public void T01_IsCreditCard_OK()
        {
            string creditCardNumber = "2718281828458567";
            bool expected = true;
            var actual = Program.IsCreditCardValid(creditCardNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T02_IsCreditCard_Checksum_NotOK()
        {
            string creditCardNumber = "2718281828458566";
            bool expected = false;
            var actual = Program.IsCreditCardValid(creditCardNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T03_IsCreditCard_Length_NotOK()
        {
            string creditCardNumber = "27182818284585666";
            bool expected = false;
            var actual = Program.IsCreditCardValid(creditCardNumber);
            Assert.AreEqual(expected, actual, "Länge stimmt nicht");
        }

        [TestMethod()]
        public void T04_IsCreditCard_Letter()
        {
            string creditCardNumber = "2718281828X58566";
            bool expected = false;
            var actual = Program.IsCreditCardValid(creditCardNumber);
            Assert.AreEqual(expected, actual, "Enthält Buchstaben");
        }

        [TestMethod()]
        public void T05_IsCreditCard_OK_Zero()
        {
            string creditCardNumber = "2418281828458560";
            bool expected = true;
            var actual = Program.IsCreditCardValid(creditCardNumber);
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        ///A test for calculateDigitSum
        ///</summary>
        [TestMethod()]
        public void T11_CalculateDigitSum()
        {
            int n = 18;
            int expected = 9;
            int actual;
            actual = Program.CalculateDigitSum(n);
            Assert.AreEqual(expected, actual, "Digitsum (18) == 9");
            Assert.AreEqual(0, Program.CalculateDigitSum(0), "0=>0");
            Assert.AreEqual(1, Program.CalculateDigitSum(10), "10=>1");
            Assert.AreEqual(9, Program.CalculateDigitSum(9), "9=>9");
            Assert.AreEqual(10, Program.CalculateDigitSum(1234));
            Assert.AreEqual(35, Program.CalculateDigitSum(98765));
        }

        /// <summary>
        ///A test for calculateCheckDigit
        ///</summary>
        [TestMethod()]
        public void T12_CalculateCheckDigit_Zero()
        {
            int oddSum = 0;
            int evenSum = 0;
            int expected = 0;
            int actual;
            actual = Program.CalculateCheckDigit(oddSum, evenSum);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for calculateCheckDigit
        ///</summary>
        [TestMethod()]
        public void T13_CalculateCheckDigitTest_Normal()
        {
            int oddSum = 49;
            int evenSum = 34;
            int expected = 7;
            int actual;
            actual = Program.CalculateCheckDigit(oddSum, evenSum);
            Assert.AreEqual(expected, actual);
        }
    }
}