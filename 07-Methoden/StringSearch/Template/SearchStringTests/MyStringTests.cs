using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchString;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchString.Tests
{
    [TestClass()]
    public class MyStringTests
    {
        [TestMethod()]
        public void T01_SearchStringTest_OneCharacter_Found()
        {
            Assert.AreEqual(0, MyString.SearchString("Hallo", "H"));
            Assert.AreEqual(1, MyString.SearchString("Hallo", "a"));
            Assert.AreEqual(2, MyString.SearchString("Hallo", "l"));
            Assert.AreEqual(4, MyString.SearchString("Hallo", "o"));
        }

        [TestMethod()]
        public void T02_SearchStringTest_OneCharacter_NotFound()
        {
            Assert.AreEqual(-1, MyString.SearchString("Hallo", "h"));
            Assert.AreEqual(-1, MyString.SearchString("Hallo", "A"));
            Assert.AreEqual(-1, MyString.SearchString("Hallo", " "));
            Assert.AreEqual(-1, MyString.SearchString("Hallo", "8"));
        }

        [TestMethod()]
        public void T03_SearchStringTest_MultipleCharacters_Found()
        {
            Assert.AreEqual(0, MyString.SearchString("Hallo", "Ha"));
            Assert.AreEqual(0, MyString.SearchString("HaHa", "Ha"));
            Assert.AreEqual(1, MyString.SearchString("Hallo", "all"));
            Assert.AreEqual(3, MyString.SearchString("Hallo", "lo"));
            Assert.AreEqual(0, MyString.SearchString("Hallo", "Hallo"));
        }

        [TestMethod()]
        public void T04_SearchStringTest_MultipleCharacters_NotFound()
        {
            Assert.AreEqual(-1, MyString.SearchString("Hallo", "zu"));
            Assert.AreEqual(-1, MyString.SearchString("Hallo", "lll"));
            Assert.AreEqual(-1, MyString.SearchString("Hallo", "allo "));
            Assert.AreEqual(-1, MyString.SearchString("Hallo", "oho"));
        }
    }
}