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
        [Fact]
        public void T00_Default()
        {
            var rational = new RationalNumber();
            rational.Numerator.Should().Be(0);
            rational.Denominator.Should().Be(1);
        }

        [Theory]
        [InlineData(1,   1,  1,   1)]
        [InlineData(2,   2,  1,   1)]
        [InlineData(10,  2,  5,   1)]
        [InlineData(13,  17, 13,  17)]
        [InlineData(-13, 17, -13, 17)]
        [InlineData(-2,  -2, 1,   1)]
        [InlineData(2,   -2, -1,  1)]
        public void T01_Normalize(int numerator, int denominator, int expectNumerator, int expectDenominator)
        {
            var rational = (new RationalNumber(numerator, denominator)).Normalize();
            rational.Numerator.Should().Be(expectNumerator);
            rational.Denominator.Should().Be(expectDenominator);
        }

        [Theory]
        [InlineData(1,   1,  0,  1)]
        [InlineData(2,   2,  1,  1)]
        [InlineData(10,  2,  1,  1)]
        [InlineData(13,  17, 2,  2)]
        [InlineData(-13, 17, -2, 2)]
        public void T02_Add(int n1, int d1, int n2, int d2)
        {
            var r1     = new RationalNumber(n1, d1);
            var r2     = new RationalNumber(n2, d2);
            var result = r1.Add(r2);
            result.Numerator.Should().Be(n1 * d2 + n2 * d1);
            result.Denominator.Should().Be(d1 * d2);
        }

        [Theory]
        [InlineData(1,   1,  0,  1)]
        [InlineData(2,   2,  1,  1)]
        [InlineData(10,  2,  1,  1)]
        [InlineData(13,  17, 2,  2)]
        [InlineData(-13, 17, -2, 2)]
        public void T03_AddNormalized(int n1, int d1, int n2, int d2)
        {
            var r1     = new RationalNumber(n1, d1);
            var r2     = new RationalNumber(n2, d2);
            var result = r1.Add(r2).Normalize();
            var expect = new RationalNumber(n1 * d2 + n2 * d1, d1 * d2).Normalize();
            result.Numerator.Should().Be(expect.Numerator);
            result.Denominator.Should().Be(expect.Denominator);
        }

        [Theory]
        [InlineData(1,   1,  0,  1)]
        [InlineData(2,   2,  1,  1)]
        [InlineData(10,  2,  1,  1)]
        [InlineData(13,  17, 2,  2)]
        [InlineData(-13, 17, -2, 2)]
        public void T04_SubNormalized(int n1, int d1, int n2, int d2)
        {
            var r1     = new RationalNumber(n1, d1);
            var r2     = new RationalNumber(n2, d2);
            var result = r1.Sub(r2).Normalize();
            var expect = new RationalNumber(n1 * d2 - n2 * d1, d1 * d2).Normalize();
            result.Numerator.Should().Be(expect.Numerator);
            result.Denominator.Should().Be(expect.Denominator);
        }

        [Theory]
        [InlineData(1,   1,  0,  1)]
        [InlineData(2,   2,  1,  1)]
        [InlineData(10,  2,  1,  1)]
        [InlineData(13,  17, 2,  2)]
        [InlineData(-13, 17, -2, 2)]
        public void T05_MulNormalized(int n1, int d1, int n2, int d2)
        {
            var r1     = new RationalNumber(n1, d1);
            var r2     = new RationalNumber(n2, d2);
            var result = r1.Mult(r2).Normalize();
            var expect = new RationalNumber(n1 * n2, d1 * d2).Normalize();
            result.Numerator.Should().Be(expect.Numerator);
            result.Denominator.Should().Be(expect.Denominator);
        }

        [Theory]
        [InlineData(1,   1,  2,  1)]
        [InlineData(2,   2,  1,  1)]
        [InlineData(10,  2,  1,  1)]
        [InlineData(13,  17, 2,  2)]
        [InlineData(-13, 17, -2, 2)]
        public void T06_DivNormalized(int n1, int d1, int n2, int d2)
        {
            var r1     = new RationalNumber(n1, d1);
            var r2     = new RationalNumber(n2, d2);
            var result = r1.Div(r2).Normalize();
            var expect = new RationalNumber(n1 * d2, d1 * n2).Normalize();
            result.Numerator.Should().Be(expect.Numerator);
            result.Denominator.Should().Be(expect.Denominator);
        }

        [Theory]
        [InlineData(1,   1)]
        [InlineData(2,   2)]
        [InlineData(10,  2)]
        [InlineData(13,  17)]
        [InlineData(-13, 17)]
        public void T07_Reciprocal(int n1, int d1)
        {
            var r1     = new RationalNumber(n1, d1);
            var result = r1.Reciprocal();
            result.Numerator.Should().Be(d1);
            result.Denominator.Should().Be(n1);
        }

        [Theory]
        [InlineData(1,   1)]
        [InlineData(2,   2)]
        [InlineData(10,  2)]
        [InlineData(13,  17)]
        [InlineData(-13, 17)]
        public void T08_Inverse(int n1, int d1)
        {
            var r1     = new RationalNumber(n1, d1);
            var result = r1.Inverse();
            result.Numerator.Should().Be(-n1);
            result.Denominator.Should().Be(d1);
        }

        [Theory]
        [InlineData(1,   1)]
        [InlineData(2,   2)]
        [InlineData(10,  2)]
        [InlineData(13,  17)]
        [InlineData(-13, 17)]
        public void T09_Value(int n1, int d1)
        {
            var r1 = new RationalNumber(n1, d1);
            r1.Value.Should().Be((double)n1 / (double)d1);
        }
    }
}