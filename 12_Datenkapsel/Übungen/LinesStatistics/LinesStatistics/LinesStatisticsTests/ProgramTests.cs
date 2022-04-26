using Microsoft.VisualStudio.TestTools.UnitTesting;
using  LinesStatistics;

namespace LinesStatistics.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_CountLineWordsSimplest()
        {
            string line = "Hallo";
            Assert.AreEqual(1, LinesStatistics.CountLineWords(line), "Ein Wort");
        }

        [TestMethod()]
        public void T02_CountLineWordsSimplest2()
        {
            string line = "Hallo ";
            Assert.AreEqual(1, LinesStatistics.CountLineWords(line), "Ein Wort mit Leerzeichen");
        }

        [TestMethod()]
        public void T03_CountLineWordsSimple()
        {
            string line = "Hallo Welt";
            Assert.AreEqual(2, LinesStatistics.CountLineWords(line), "Zwei Wörter");
        }

        [TestMethod()]
        public void T04_CountLineWordsEmpty()
        {
            string line = "";
            Assert.AreEqual(0, LinesStatistics.CountLineWords(line), "Leerstring");
        }

        [TestMethod()]
        public void T05_CountLineWordsOtherSeperators()
        {
            string line = "Hallo(Welt)wie!ut543_gehts!";
            Assert.AreEqual(5, LinesStatistics.CountLineWords(line), "Verschiedene Trenner");
        }
    }
}