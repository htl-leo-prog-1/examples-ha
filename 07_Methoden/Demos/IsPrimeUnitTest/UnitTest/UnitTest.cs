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
using MyProject;

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
}