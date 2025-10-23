/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Traveler Salesman problem UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;
using TravelerSalesman;
using Xunit;
using System;

public class PermutationTests
{
    [Fact]
    public void T11_CreatePermutationSize0()
    {
        var permutations = TravelerSalesman.CreatePermutations(0);

        permutations.Should().HaveCount(0);
    }

    [Fact]
    public void T12_CreatePermutationSize1()
    {
        var permutations = TravelerSalesman.CreatePermutations(1);

        permutations.Should().HaveCount(1);
        permutations.Should().ContainEquivalentOf(new[] {0});
    }

    [Fact]
    public void T13_CreatePermutationSize2()
    {
        var permutations = TravelerSalesman.CreatePermutations(2);

        permutations.Should().HaveCount(1);

        permutations.Should().ContainEquivalentOf(new[] {0, 1});
    }

    [Fact]
    public void T14_CreatePermutationSize3()
    {
        var permutations = TravelerSalesman.CreatePermutations(3);

        permutations.Should().HaveCount(2);

        permutations.Should().ContainEquivalentOf(new[] {0, 1, 2});
        permutations.Should().ContainEquivalentOf(new[] {0, 2, 1});
    }

    [Fact]
    public void T15_CreatePermutationSize4()
    {
        var permutations = TravelerSalesman.CreatePermutations(4);

        permutations.Should().HaveCount(6);

        permutations.Should().ContainEquivalentOf(new[] {0, 1, 2, 3});
        permutations.Should().ContainEquivalentOf(new[] {0, 1, 3, 2});
        permutations.Should().ContainEquivalentOf(new[] {0, 2, 1, 3});
        permutations.Should().ContainEquivalentOf(new[] {0, 2, 3, 1});
        permutations.Should().ContainEquivalentOf(new[] {0, 3, 1, 2});
        permutations.Should().ContainEquivalentOf(new[] {0, 3, 2, 1});
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 6)]
    [InlineData(5, 24)]
    [InlineData(6, 120)]
    [InlineData(7, 720)]
    [InlineData(8, 5040)]
    [InlineData(9, 40320)]
    public void T16_CreatePermutationSizeX(int size, int expected)
    {
        int Fact(int n) => n > 1 ? n * Fact(n - 1) : 1;
        expected.Should().Be(Fact(size - 1));

        var permutations = TravelerSalesman.CreatePermutations(size);
        permutations.Should().HaveCount(expected);
    }
}