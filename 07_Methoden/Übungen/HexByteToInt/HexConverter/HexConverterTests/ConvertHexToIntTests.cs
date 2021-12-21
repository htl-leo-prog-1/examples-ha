using Microsoft.VisualStudio.TestTools.UnitTesting;
using HexConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexConverter.Tests
{
    [TestClass()]
    public class ConvertHexToIntTests
    {

        [TestMethod()]
        public void T01_ConvertHexChar_Ok()
        {
            Assert.AreEqual(0, HexToInt.HexCharToInt('0'));
            Assert.AreEqual(9, HexToInt.HexCharToInt('9'));
            Assert.AreEqual(10, HexToInt.HexCharToInt('a'));
            Assert.AreEqual(10, HexToInt.HexCharToInt('A'));
            Assert.AreEqual(12, HexToInt.HexCharToInt('c'));
            Assert.AreEqual(12, HexToInt.HexCharToInt('C'));
            Assert.AreEqual(15, HexToInt.HexCharToInt('f'));
            Assert.AreEqual(15, HexToInt.HexCharToInt('F'));          
        }

        [TestMethod()]
        public void T02_ConvertHexChar_Failure()
        {
            Assert.AreEqual(-1, HexToInt.HexCharToInt('x'));
            Assert.AreEqual(-1, HexToInt.HexCharToInt('H'));
            Assert.AreEqual(-1, HexToInt.HexCharToInt(' '));
        }

        [TestMethod()]
        public void T03_ConvertHexByte_Ok()
        {
            Assert.AreEqual(10, HexToInt.HexByteToInt("0A"));
            Assert.AreEqual(16, HexToInt.HexByteToInt("10"));
            Assert.AreEqual(255, HexToInt.HexByteToInt("ff"));
            Assert.AreEqual(8 * 16 + 8, HexToInt.HexByteToInt("88"));
        }

        [TestMethod()]
        public void T04_ConvertHexByte_Failure()
        {
            Assert.AreEqual(-1, HexToInt.HexByteToInt("ax"));
            Assert.AreEqual(-1, HexToInt.HexByteToInt("aaa"));
            Assert.AreEqual(-1, HexToInt.HexByteToInt("xa"));
        }
    }
}