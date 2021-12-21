using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExamples.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_SingleLowerCaseChar()
        {
            string text = "x";
            string expected = "x";
            int position = 0;
            int length = 1;
            string actual = Program.ExtractLowerCaseCharacters(text, position, length);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T02_MixedStringSingleLowerCaseChar()
        {
            string text = "Hello";
            string expected = "l";
            int position = 2;
            int length = 1;
            string actual = Program.ExtractLowerCaseCharacters(text, position, length);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T03_MixedStringMultipleLowerCaseChars()
        {
            string text = "Hello";
            string expected = "llo";
            int position = 2;
            int length = 3;
            string actual = Program.ExtractLowerCaseCharacters(text, position, length);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T04_MixedStringTooMuchLowerCaseChars()
        {
            string text = "Hello";
            string expected = "llo";
            int position = 2;
            int length = 6;
            string actual = Program.ExtractLowerCaseCharacters(text, position, length);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T05_MixedStringTooMuchMixedCaseChars()
        {
            string text = "HeLLo";
            string expected = "eo";
            int position = 1;
            int length = 3;
            string actual = Program.ExtractLowerCaseCharacters(text, position, length);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void T06_OnlyUpperCaseText()
        {
            string text = "HELLO";
            string expected = "";
            int position = 1;
            int length = 3;
            string actual = Program.ExtractLowerCaseCharacters(text, position, length);
            Assert.AreEqual(expected, actual);
        }

    }


}