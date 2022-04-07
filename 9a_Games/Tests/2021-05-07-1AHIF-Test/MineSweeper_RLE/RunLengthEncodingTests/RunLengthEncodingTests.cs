using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RLE.Tests
{
    [TestClass()]
    public class RunLengthEncodingTests
    {
        [TestMethod()]
        public void T01_RleEncodeTest_Simple()
        {
            string text = "AA";
            Assert.AreEqual("2A", RunLengthEncoding.RleEncode(text));
        }

        [TestMethod()]
        public void T02_RleEncodeTest_DifferentCharacters()
        {
            string text = "AABBBBBCDDD";
            Assert.AreEqual("2A5B1C3D", RunLengthEncoding.RleEncode(text));
        }

        [TestMethod()]
        public void T03_RleEncodeTest_MoreThan10Characters()
        {
            string text = "AA............CDDD";
            Assert.AreEqual("2A0.2.1C3D", RunLengthEncoding.RleEncode(text));
        }

        [TestMethod()]
        public void T04_RleDecodeTest_Simple()
        {
            string text = "2A";
            Assert.AreEqual("AA", RunLengthEncoding.RleDecode(text));
        }

        [TestMethod()]
        public void T05_RleDecodeTest_MoreCharacters()
        {
            string text = "2A5B1C3D";
            Assert.AreEqual("AABBBBBCDDD", RunLengthEncoding.RleDecode(text));
        }

        [TestMethod()]
        public void T06_RleDecodeTest_MoreThan10Characters()
        {
            string text = "2A0.2.1C3D";
            Assert.AreEqual("AA............CDDD", RunLengthEncoding.RleDecode(text));
        }
    }
}