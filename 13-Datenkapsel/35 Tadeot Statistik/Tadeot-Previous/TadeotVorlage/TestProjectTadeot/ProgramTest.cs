using Tadeot;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProjectTadeot
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
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
        public void T01_InsertLast()
        {
            string[] infoQuellen = new string[100];
            infoQuellen[0] = "A";
            infoQuellen[1] = "B";
            int count = Program.InsertInfoSourceWithoutDuplicate(infoQuellen, "C");
            Assert.AreEqual(3, count);
            Assert.AreEqual("C", infoQuellen[2]);
        }

        [TestMethod()]
        public void T02_InsertMiddle()
        {
            string[] infoQuellen = new string[100];
            infoQuellen[0] = "A";
            infoQuellen[1] = "C";
            int count = Program.InsertInfoSourceWithoutDuplicate(infoQuellen, "B");
            Assert.AreEqual(3, count);
            Assert.AreEqual("B", infoQuellen[1]);
        }

        [TestMethod()]
        public void T03_InsertFirst()
        {
            string[] infoQuellen = new string[100];
            infoQuellen[0] = "B";
            infoQuellen[1] = "C";
            int count = Program.InsertInfoSourceWithoutDuplicate(infoQuellen, "A");
            Assert.AreEqual(3, count);
            Assert.AreEqual("A", infoQuellen[0]);
            Assert.AreEqual("B", infoQuellen[1]);
        }

        [TestMethod()]
        public void T04_InsertOnEmpty()
        {
            string[] infoQuellen = new string[100];
            int count = Program.InsertInfoSourceWithoutDuplicate(infoQuellen, "A");
            Assert.AreEqual(1, count);
            Assert.AreEqual("A", infoQuellen[0]);
        }

        [TestMethod()]
        public void T05_InsertDouble()
        {
            string[] infoQuellen = new string[100];
            infoQuellen[0] = "B";
            infoQuellen[1] = "C";
            int count = Program.InsertInfoSourceWithoutDuplicate(infoQuellen, "C");
            Assert.AreEqual(2, count);
            Assert.AreEqual("B", infoQuellen[0]);
            Assert.AreEqual("C", infoQuellen[1]);
        }
    }
}
