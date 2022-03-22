using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary;


namespace BookLibrary.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void T01_CheckIsbn_CorrectLength_ShouldReturnTrue()
        {
            Assert.IsTrue(Program.CheckIsbn("3760778739"));
        }

        [TestMethod()]
        public void T02_CheckIsbn_TooShort_ShouldReturnFalse()
        {
            Assert.IsFalse(Program.CheckIsbn("376077879"));
        }

        [TestMethod()]
        public void T03_CheckIsbn_TooLong_ShouldReturnFalse()
        {
            Assert.IsFalse(Program.CheckIsbn("37607787390"));
        }


        [TestMethod()]
        public void T04_CheckIsbn_IllegalChar_ShouldReturnFalse()
        {
            Assert.IsFalse(Program.CheckIsbn("3760A78739"));
        }

        [TestMethod()]
        public void T05_CheckIsbn_XAtEnd_ShouldReturnTrue()
        {
            Assert.IsTrue(Program.CheckIsbn("355151710X"));
        }

        [TestMethod()]
        public void T06_CheckIsbn_XInTheMiddle_ShouldReturnFalse()
        {
            Assert.IsFalse(Program.CheckIsbn("355X151710"));
        }

        [TestMethod()]
        public void T07_CheckIsbn_CheckSum_ShouldReturnTrue()
        {
            Assert.IsTrue(Program.CheckIsbn("3866801920"));
            Assert.IsTrue(Program.CheckIsbn("3680087837"));
        }

        [TestMethod()]
        public void T08_CheckIsbn_WrongCheckSum_ShouldReturnFalse()
        {
            Assert.IsFalse(Program.CheckIsbn("355150710X"));
        }
    }
}