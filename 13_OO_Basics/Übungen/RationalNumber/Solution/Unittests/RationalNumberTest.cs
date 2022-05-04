/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: RationalNumber Unittests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;

    using Xunit;

    using RationalNumber;


    public class RationalNumberTest
    {
        [Theory]
        [InlineData(1,  1,  1,  1)]
        [InlineData(2,  2,  1,  1)]
        [InlineData(10, 2,  5,  1)]
        [InlineData(13, 17, 13, 17)]
        [InlineData(-13, 17, -13, 17)]
        public void T01_Normalize(int numerator, int denominator, int expectNumerator, int expectDenominator)
        {
            var rational          = (new RationalNumber(numerator, denominator)).Normalize();
            rational.Numerator.Should().Be(expectNumerator);
            rational.Denominator.Should().Be(expectDenominator);
        }
    }
}