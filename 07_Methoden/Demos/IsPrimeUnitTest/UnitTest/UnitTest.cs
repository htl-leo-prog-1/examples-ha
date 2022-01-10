/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Unittests
*--------------------------------------------------------------
*/

using System.Linq;

namespace UnitTest
{
    using FluentAssertions;
    using Xunit;
    using MyProject;

    public class UnitTest
    {
        [Fact]
        public void Prime1Test()
        {
            Program.IsPrime(1).Should().BeFalse();
        }

        [Fact]
        public void Prime0Test()
        {
            Program.IsPrime(0).Should().BeFalse("we define 0 as no prime");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(991)]
        public void PrimeTest(int number)
        {
            Program.IsPrime(number).Should().BeTrue($"{number} is prime");
            Program.IsPrime(-number).Should().BeTrue($"{-number} is prime");
        }

        [Theory]
        [InlineData(4)]
        [InlineData(1000)]
        public void NotPrimeTest(int number)
        {
            Program.IsPrime(number).Should().BeFalse($"{number} is not a prime");
            Program.IsPrime(-number).Should().BeFalse($"{-number} is not a prime");
        }

        [Fact]
        public void AllPrimeTest()
        {
            var allPrimes = Enumerable.Range(1, 1000).Select(n => new {Number = n , IsPrime = Program.IsPrime(n)}).ToList();
            allPrimes.Should().Contain(new {Number = 1, IsPrime = true});
            allPrimes.Should().HaveCount(1000);
            // between 1..1000 we have 169 prime
            allPrimes.Where(x => x.IsPrime).Should().HaveCount(169);
        }
    }
}