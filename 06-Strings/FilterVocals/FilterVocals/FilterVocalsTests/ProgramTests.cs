using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilterVocals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterVocals.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_Simple_OneVocal()
        {
            string text = "a";
            string expected = "a";
            string actual = Program.FilterVocals(text);
            Assert.AreEqual(expected,actual, "a ==> a");
        }

        [TestMethod()]
        public void T02_Simple_WithoutVocals()
        {
            string text = "x";
            string expected = "";
            string actual = Program.FilterVocals(text);
            Assert.AreEqual(expected, actual, "x ==> ");
        }

        [TestMethod()]
        public void T03_Simple_MultipleVocals()
        {
            string text = "Hello";
            string expected = "eo";
            string actual = Program.FilterVocals(text);
            Assert.AreEqual(expected, actual, "Hello ==> eo");
        }

        [TestMethod()]
        public void T04_Normal_UpperAndLower()
        {
            string text = "Upper and Low";
            string expected = "Ueao";
            string actual = Program.FilterVocals(text);
            Assert.AreEqual(expected, actual, "Upper and Low ==> Ueao");
        }

        [TestMethod()]
        public void T05_Normal_Doubles()
        {
            string text = "Hello World";
            string expected = "eo";
            string actual = Program.FilterVocals(text);
            Assert.AreEqual(expected, actual, "Hello World ==> eo");
        }

        [TestMethod()]
        public void T06_Normal_DoublesUpperLower()
        {
            string text = "HellO World";
            string expected = "eO";
            string actual = Program.FilterVocals(text);
            Assert.AreEqual(expected, actual, "HellO World ==> eO");
        }

        [TestMethod()]
        public void T07_Normal_Empty()
        {
            string text = "";
            string expected = "";
            string actual = Program.FilterVocals(text);
            Assert.AreEqual(expected, actual, "empty ==> \"\"");
        }

    }
}