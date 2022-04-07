using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindDuplicates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDuplicates.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        static string[] names = { "Hugo", "Susi", "Hugo", "Sissi", "Hugo", "Sarah", "Susi", "Theo", "Gregor", "Hannah" };

        [TestMethod()]
        public void T01_CountNames()
        {
            int actual = Program.Count(names, "");
            Assert.AreEqual(0, actual, "Leerstring kommt nicht vor");
            Assert.AreEqual(1, Program.Count(names, "Theo"));
            Assert.AreEqual(3, Program.Count(names, "Hugo"));
        }
    }
}