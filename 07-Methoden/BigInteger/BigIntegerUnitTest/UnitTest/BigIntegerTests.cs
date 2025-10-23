/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: IsEvenOddNumber UnitTests
 *--------------------------------------------------------------
 */

using FluentAssertions;

using Xunit;

using System.Linq;

using BigInteger;

namespace UnitTest
{
    using BigInteger = BigInteger.BigInteger;

    public class BigIntegerTests
    {
        #region IsValid

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("01")]
        [InlineData("00")]
        [InlineData("1234567890")]
        [InlineData("1234567890123456789012345678901234567890")]
        public void T01_IsValidBigInteger(string bigInt)
        {
            BigInteger.IsValidBigInteger(bigInt).Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("1.0")]
        [InlineData("0.")]
        [InlineData("0,0")]
        [InlineData("1234567890a")]
        [InlineData("0x1234567890")]
        [InlineData("!1234567890123456789012345678901234567890")]
        [InlineData("-1234567890123456789012345678901234567890")]
        [InlineData("+123456789")]
        [InlineData("1*2")]
        public void T02_IsNotValidBigInteger(string bigInt)
        {
            BigInteger.IsValidBigInteger(bigInt).Should().BeFalse();
        }

        #endregion

        #region AddTest

        [Fact]
        public void T11_AddOnDigit()
        {
            BigInteger.AddBigIntegers("1", "2").Should().Be("3");
        }

        [Fact]
        public void T12_AddOnDigitWithCarry()
        {
            BigInteger.AddBigIntegers("1", "9").Should().Be("10");
        }

        [Fact]
        public void T13_AddOnDifferentLength()
        {
            BigInteger.AddBigIntegers("100", "2").Should().Be("102");
        }

        [Fact]
        public void T14_AddOnDifferentLengthWithCarry()
        {
            BigInteger.AddBigIntegers("999", "1").Should().Be("1000");
        }

        [Fact]
        public void T15_AddOnDifferentLengthWithCarry()
        {
            BigInteger.AddBigIntegers("109", "1").Should().Be("110");
        }

        #endregion

        #region MultipyWithDigit

        [Theory]
        [InlineData("0",                                        1, "0")]
        [InlineData("0",                                        0, "0")]
        [InlineData("123",                                      0, "0")]
        [InlineData("123",                                      1, "123")]
        [InlineData("999",                                      9, "8991")]
        [InlineData("999",                                      2, "1998")]
        [InlineData("1234567890123456789012345678901234567890", 9, "11111111011111111101111111110111111111010")]
        public void T21_MultiplyWithDigit(string bigInteger, int digit, string expected)
        {
            BigInteger.MultiplyBigIntegerWithDigit(bigInteger, digit).Should().Be(expected);
        }

        #endregion

        #region Multipy

        [Theory]
        [InlineData("0",                                        "1",          "0")]
        [InlineData("0",                                        "0",          "0")]
        [InlineData("123",                                      "0",          "0")]
        [InlineData("123",                                      "1",          "123")]
        [InlineData("999",                                      "9",          "8991")]
        [InlineData("999",                                      "2",          "1998")]
        [InlineData("1234567890123456789012345678901234567890", "9",          "11111111011111111101111111110111111111010")]
        [InlineData("10",                                       "10",         "100")]
        [InlineData("99",                                       "98",         "9702")]
        [InlineData("9876543210",                               "1234567890", "12193263111263526900")]
        public void T31_MultiplyWithDigit(string bigInteger, string mult, string expected)
        {
            BigInteger.MultiplyBigIntegers(bigInteger, mult).Should().Be(expected);
        }

        #endregion
    }
}