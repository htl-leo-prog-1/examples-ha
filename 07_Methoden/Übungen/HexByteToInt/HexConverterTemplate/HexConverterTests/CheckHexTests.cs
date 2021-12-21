using Microsoft.VisualStudio.TestTools.UnitTesting;
using HexConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexConverter.Tests
{
    [TestClass()]
    public class CheckHexTests
    {
        [TestMethod()]
        public void T01_IsHexCharTest_Digits()
        {
            Assert.IsTrue(HexToInt.IsHexChar('a'));
            Assert.IsTrue(HexToInt.IsHexChar('A'));
            Assert.IsTrue(HexToInt.IsHexChar('f'));
            Assert.IsTrue(HexToInt.IsHexChar('F'));
            for (char c = '0'; c <= '9'; c++)
            {
                Assert.IsTrue(HexToInt.IsHexChar(c));
            }
        }

        [TestMethod()]
        public void T02_IsHexCharTest_Letters_Small()
        {
            for (char c = 'a'; c <= 'f'; c++)
            {
                Assert.IsTrue(HexToInt.IsHexChar(c));
            }
        }

        [TestMethod()]
        public void T03_IsHexCharTest_Letters_Capital()
        {
            for (char c = 'A'; c <= 'F'; c++)
            {
                Assert.IsTrue(HexToInt.IsHexChar(c));
            }
        }

        [TestMethod()]
        public void T04_IsHexCharTest_InvalidChars()
        {
            // random
            Assert.IsFalse(HexToInt.IsHexChar(' '));
            Assert.IsFalse(HexToInt.IsHexChar('%'));

            // Zeichen vor und nach Kleinbuchstaben
            Assert.IsFalse(HexToInt.IsHexChar('`'));
            Assert.IsFalse(HexToInt.IsHexChar('g'));

            // Zeichen vor und nach Großbuchstaben
            Assert.IsFalse(HexToInt.IsHexChar('@'));
            Assert.IsFalse(HexToInt.IsHexChar('G'));

            // Zeichen vor und nach Ziffern
            Assert.IsFalse(HexToInt.IsHexChar('/'));
            Assert.IsFalse(HexToInt.IsHexChar(':'));
        }

        [TestMethod()]
        public void T05_IsHexByteTest_LengthFailure()
        {
            Assert.IsFalse(HexToInt.IsHexByteString("0"));
            Assert.IsFalse(HexToInt.IsHexByteString(""));
            Assert.IsFalse(HexToInt.IsHexByteString("123"));
        }

        [TestMethod()]
        public void T06_IsHexByteTest_IllegalChar()
        {
            Assert.IsFalse(HexToInt.IsHexByteString("OA"));
            Assert.IsFalse(HexToInt.IsHexByteString("9 "));
            Assert.IsFalse(HexToInt.IsHexByteString("AX"));
        }
    }
}