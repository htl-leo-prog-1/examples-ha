using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRectangle;

namespace RectangleTest
{
    [TestClass]
    public class RectangleUnitTest
    {
        [TestMethod]
        public void Test01_DefaultRectangle()
        {
            Rectangle rect = new Rectangle();
            Assert.IsTrue(rect.GetWidth() == 1);
            Assert.IsTrue(rect.GetLength() == 1);
            Assert.IsTrue(rect.GetArea() == 1);
            Assert.IsTrue(rect.GetPerimeter() == 4);
        }

        [TestMethod]
        public void Test02_SpecialRectangle()
        {
            Rectangle rect = new Rectangle(5, 9);
            Assert.IsTrue(rect.GetWidth() == 5);
            Assert.IsTrue(rect.GetLength() == 9);
            Assert.IsTrue(rect.GetArea() == 45);
            Assert.IsTrue(rect.GetPerimeter() == 28);
        }

        [TestMethod]
        public void Test03_RectangleComparison()
        {
            Rectangle rect1 = new Rectangle(5, 9);
            Rectangle rect2 = new Rectangle();
            int comparisonResult = rect1.CompareTo(rect2);
            Assert.IsTrue(comparisonResult == 1);
            comparisonResult = rect2.CompareTo(rect1);
            Assert.IsTrue(comparisonResult == -1);
            comparisonResult = rect1.CompareTo(rect1);
            Assert.IsTrue(comparisonResult == 0);
            Rectangle rect3 = new Rectangle();
            comparisonResult = rect2.CompareTo(rect3);
            Assert.IsTrue(comparisonResult == 0);
        }

        [TestMethod]
        public void Test04_Scale()
        {
            Rectangle rect = new Rectangle(5, 9);
            rect.Scale(2);
            Assert.IsTrue(rect.GetWidth() == 10);
            Assert.IsTrue(rect.GetLength() == 18);
        }

        [TestMethod]
        public void Test05_Rotate()
        {
            Rectangle rect = new Rectangle(5, 9);
            rect.Rotate();
            Assert.IsTrue(rect.GetWidth() == 9);
            Assert.IsTrue(rect.GetLength() == 5);
        }
    }
}
