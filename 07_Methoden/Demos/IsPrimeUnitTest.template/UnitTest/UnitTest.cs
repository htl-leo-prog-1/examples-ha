/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Unittests
*--------------------------------------------------------------
*/

namespace UnitTest;

using System.Linq;
using FluentAssertions;
using Xunit;
using Prime;

public class UnitTest
{
    [Fact]
    public void Prime1Test()
    {
        PrimeNumbers.IsPrime(1).Should().BeFalse("1 is not prime");
    }

    [Fact]
    public void Prime0Test()
    {
        PrimeNumbers.IsPrime(0).Should().BeFalse("we define 0 as no prime");
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(991)]
    public void PrimeTest(int number)
    {
        PrimeNumbers.IsPrime(number).Should().BeTrue($"{number} is prime");
        PrimeNumbers.IsPrime(-number).Should().BeTrue($"{-number} is prime");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(1000)]
    public void NotPrimeTest(int number)
    {
        PrimeNumbers.IsPrime(number).Should().BeFalse($"{number} is not a prime");
        PrimeNumbers.IsPrime(-number).Should().BeFalse($"{-number} is not a prime");
    }

    [Fact]
    public void AllPrimeTest()
    {
        var allPrimes = Enumerable.Range(1, 1000).Select(n => new {Number = n, IsPrime = PrimeNumbers.IsPrime(n)})
            .ToList();
        allPrimes.Should().Contain(new {Number = 1, IsPrime = false});
        allPrimes.Should().Contain(new {Number = 2, IsPrime = true});
        allPrimes.Should().HaveCount(1000);
        // between 1..1000 we have 168 prime
        allPrimes.Where(x => x.IsPrime).Should().HaveCount(168);
    }

    [Fact]
    public void GetNextFromNegative()
    {
        PrimeNumbers.NextPrime(-1).Should().Be(2);
    }

    [Theory]
    [InlineData(-7, -5)]
    [InlineData(-3, -2)]
    [InlineData(-2, 2)]
    [InlineData(-1, 2)]
    [InlineData(0, 2)]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 5)]
    [InlineData(4, 5)]
    public void NextPrimeTest(int number, int expected)
    {
        PrimeNumbers.NextPrime(number).Should().Be(expected);
    }

    [Theory]
    [InlineData(-5, -7)]
    [InlineData(-2, -3)]
    [InlineData(-1, -2)]
    [InlineData(0, -2)]
    [InlineData(1, -2)]
    [InlineData(2, -2)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 3)]
    [InlineData(16, 13)]
    public void PrevPrimeTest(int number, int expected)
    {
        PrimeNumbers.PrevPrime(number).Should().Be(expected);
    }

}