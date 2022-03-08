/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CountDifferentDigits UnitTest
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using CountDifferentDigits;
    using Xunit;

    public class ProgramTests
    {
        [Fact]
        public void T01_SingleDigit()
        {
            int[] digits = {3};
            Program.GetUniqueDigitsString(digits).Should().Be("3");
        }

        [Fact]
        public void T02_MultipleDifferentDigitsInOrder()
        {
            int[] digits = {3, 6, 7};
            Program.GetUniqueDigitsString(digits).Should().Be("367");
        }

        [Fact]
        public void T03_MultipleDifferentDigitsNotInOrder()
        {
            int[] digits = {7, 3, 6};
            Program.GetUniqueDigitsString(digits).Should().Be("367");
        }

        [Fact]
        public void T04_MultipleDifferentDigitsNotInOrderWithDoubles()
        {
            int[] digits = {7, 3, 6, 5, 3, 9, 7};
            Program.GetUniqueDigitsString(digits).Should().Be("35679");
        }
    }
}