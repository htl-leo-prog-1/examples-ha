/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: RomanNumerals UnitTest
*--------------------------------------------------------------
*/

namespace UnitTests;

using System;

using FluentAssertions;

using Xunit;

public sealed class RomanTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(4000)]
    public void ConvertToTestError(int number)
    {
        Assert.Throws<ArgumentException>(() => Roman.RomanNumerals.ConvertToRomanLiteral(number));
    }

    [Theory]
    [InlineData(1,    "I")]
    [InlineData(2,    "II")]
    [InlineData(3,    "III")]
    [InlineData(4,    "IV")]
    [InlineData(5,    "V")]
    [InlineData(6,    "VI")]
    [InlineData(7,    "VII")]
    [InlineData(8,    "VIII")]
    [InlineData(9,    "IX")]
    [InlineData(10,   "X")]
    [InlineData(99,   "XCIX")]
    [InlineData(444,  "CDXLIV")]
    [InlineData(999,  "CMXCIX")]
    [InlineData(1999, "MCMXCIX")]
    [InlineData(3999, "MMMCMXCIX")]

    public void ConvertToTest(int number, string expected)
    {
        Roman.RomanNumerals.ConvertToRomanLiteral(number).Should().Be(expected);
    }

    [Theory]
    [InlineData(1,    "I")]
    [InlineData(2,    "II")]
    [InlineData(3,    "III")]
    [InlineData(4,    "IV")]
    [InlineData(5,    "V")]
    [InlineData(6,    "VI")]
    [InlineData(7,    "VII")]
    [InlineData(8,    "VIII")]
    [InlineData(9,    "IX")]
    [InlineData(10,   "X")]
    [InlineData(99,   "XCIX")]
    [InlineData(444,  "CDXLIV")]
    [InlineData(999,  "CMXCIX")]
    [InlineData(1999, "MCMXCIX")]
    public void ConvertFromTest(int expected, string roman)
    {
        Roman.RomanNumerals.ConvertFromRomanLiteral(roman).Should().Be(expected);
    }

    [Fact]
    public void ConvertFromTo()
    {
        for (int i = 1; i < 4000; i++)
        {
            var roman = Roman.RomanNumerals.ConvertToRomanLiteral(i);
            roman.Should().NotBeNull();
            Roman.RomanNumerals.ConvertFromRomanLiteral(roman!).Should().Be(i);
            Console.WriteLine($"{i} => {roman}");
        }
    }
}