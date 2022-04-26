/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Rectangle
*--------------------------------------------------------------
*/

namespace RectangleTest
{
    using FluentAssertions;
    using MyRectangle;
    using Xunit;

    public class RectangleUnitTest
    {
        [Fact]
        public void Test01_DefaultRectangle()
        {
            var rect = new Rectangle();
            rect.Width.Should().Be(1);
            rect.Length.Should().Be(1);
            rect.Area.Should().Be(1);
            rect.Perimeter.Should().Be(4);
        }

        [Fact]
        public void Test02_SpecialRectangle()
        {
            var rect = new Rectangle(5, 9);
            rect.Width.Should().Be(5);
            rect.Length.Should().Be(9);
            rect.Area.Should().Be(45);
            rect.Perimeter.Should().Be(28);
        }

        [Fact]
        public void Test03_RectangleComparison()
        {
            var rect1 = new Rectangle(5, 9);
            var rect2 = new Rectangle();
            var rect3 = new Rectangle();

            rect1.CompareTo(rect2).Should().Be(1);
            rect2.CompareTo(rect1).Should().Be(-1);
            rect1.CompareTo(rect1).Should().Be(0);
            rect2.CompareTo(rect3).Should().Be(0);
        }

        [Fact]
        public void Test04_Scale()
        {
            var rect = new Rectangle(5, 9);
            rect.Scale(2);
            rect.Width.Should().Be(10);
            rect.Length.Should().Be(18);
        }

        [Fact]
        public void Test05_Rotate()
        {
            var rect = new Rectangle(5, 9);
            rect.Rotate();
            rect.Width.Should().Be(9);
            rect.Length.Should().Be(5);
        }
    }
}