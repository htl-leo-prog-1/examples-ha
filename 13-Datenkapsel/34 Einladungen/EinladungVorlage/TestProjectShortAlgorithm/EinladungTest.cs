using Einladung;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProjectShortAlgorithm
{
    
    
    /// <summary>
    ///This is a test class for EinladungTest and is intended
    ///to contain all EinladungTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EinladungTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void T01_CalcTimeSpanTest_OnlySeconds()
        {
            string actual = Einladung.Einladung.CalcTimeSpan(37);
            Assert.AreEqual("37", actual);
            actual = Einladung.Einladung.CalcTimeSpan(0);
            Assert.AreEqual("00", actual);
        }

        [TestMethod()]
        public void T02_CalcTimeSpanTest_MinutesAndSeconds()
        {
            string actual = Einladung.Einladung.CalcTimeSpan(43 * 60 + 17);
            Assert.AreEqual("43:17", actual);
            actual = Einladung.Einladung.CalcTimeSpan(44 * 60 + 0);
            Assert.AreEqual("44:00", actual);
        }

        [TestMethod()]
        public void T03_CalcTimeSpanTest_AllSimple()
        {
            string actual = Einladung.Einladung.CalcTimeSpan(12 * 3600 + 43 * 60 + 17);
            Assert.AreEqual("12:43:17", actual);
        }

        [TestMethod()]
        public void T04_CalcTimeSpanTest_AllSpecial()
        {
            string actual = Einladung.Einladung.CalcTimeSpan(12 * 3600 + 0 * 60 + 17);
            Assert.AreEqual("12:00:17", actual);
            actual = Einladung.Einladung.CalcTimeSpan(12 * 3600 + 13 * 60 + 0);
            Assert.AreEqual("12:13:00", actual);
            actual = Einladung.Einladung.CalcTimeSpan(12 * 3600 + 0 * 60 + 0);
            Assert.AreEqual("12:00:00", actual);
            actual = Einladung.Einladung.CalcTimeSpan(int.MaxValue);
            Assert.AreEqual("596523:14:07", actual);
        }
    }
}
