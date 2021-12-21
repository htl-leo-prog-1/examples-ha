using Microsoft.VisualStudio.TestTools.UnitTesting;
using MethodsQuizA;

namespace UnitTestProject
{
    [TestClass]
    public class TestQuizMethods
    {
        [TestMethod]
        public void T01_PrintCharacters()
        {
            Assert.AreEqual("=====", Program.PrintCharacters('=', 5));
            Assert.AreEqual("a", Program.PrintCharacters('a', 1));
            Assert.AreEqual(" ", Program.PrintCharacters(' ', 1));
            Assert.AreEqual("", Program.PrintCharacters('=', 0));
            Assert.AreEqual("", Program.PrintCharacters('a', -1));
        }

        [TestMethod]
        public void T02_CountCharacters()
        {
            Assert.AreEqual(1, Program.CountCharacters('e', "Eskimo"));
            Assert.AreEqual(0, Program.CountCharacters('n', "Eskimo"));
            Assert.AreEqual(3, Program.CountCharacters('L', "Halllo"));
        }

        [TestMethod]
        public void T03_Encrypt()
        {
            Assert.AreEqual("bc", Program.Encrypt("ab", 1));
            Assert.AreEqual("ab", Program.Encrypt("bc", -1));
            Assert.AreEqual("Hvnlpr", Program.Encrypt("Eskimo", 3));
            Assert.AreEqual("Eskimo", Program.Encrypt("Hvnlpr", -3));
        }

        [TestMethod]
        public void T04_ConvertBinaryToDecimal()
        {
            Assert.AreEqual(15, Program.BinaryToDecimal("1111"));
            Assert.AreEqual(1, Program.BinaryToDecimal("0001"));
            Assert.AreEqual(0, Program.BinaryToDecimal("0000000000000"));
            Assert.AreEqual(5, Program.BinaryToDecimal("101"));
            Assert.AreEqual(10, Program.BinaryToDecimal("1010"));
            Assert.AreEqual(-1, Program.BinaryToDecimal("a001"));
        }

        [TestMethod]
        public void T05_UniqueCharacters()
        {
            Assert.AreEqual("abcd", Program.GetUniqueCharacters("aabbccdd"));
            Assert.AreEqual("abcde", Program.GetUniqueCharacters("abcdeabcde"));
            Assert.AreEqual("abcd", Program.GetUniqueCharacters("abcd"));
            Assert.AreEqual(" ", Program.GetUniqueCharacters("                       "));
        }

    }
}
