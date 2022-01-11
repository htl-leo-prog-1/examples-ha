/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Unittests
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;
using Xunit;
using StringTools;

public class TestQuizMethods
{
    [Fact]
    public void T01_PrintCharacters()
    {
        StringTools.PrintCharacters('=', 5).Should().Be("=====");
        StringTools.PrintCharacters('a', 1).Should().Be("a");
        StringTools.PrintCharacters(' ', 1).Should().Be(" ");
        StringTools.PrintCharacters('=', 0).Should().Be("");
        StringTools.PrintCharacters('a', -1).Should().Be("");
    }

    [Fact]
    public void T02_CountCharacters()
    {
        StringTools.CountCharacters('e', "Eskimo").Should().Be(1);
        StringTools.CountCharacters('n', "Eskimo").Should().Be(0);
        StringTools.CountCharacters('L', "Halllo").Should().Be(3);
    }

    [Fact]
    public void T03_Encrypt()
    {
        StringTools.Encrypt("ab", 1).Should().Be("bc");
        StringTools.Encrypt("bc", -1).Should().Be("ab");
        StringTools.Encrypt("Eskimo", 3).Should().Be("Hvnlpr");
        StringTools.Encrypt("Hvnlpr", -3).Should().Be("Eskimo");
    }

    [Fact]
    public void T04_ConvertBinaryToDecimal()
    {
        StringTools.BinaryToDecimal("1111").Should().Be(15);
        StringTools.BinaryToDecimal("0001").Should().Be(1);
        StringTools.BinaryToDecimal("0000000000000").Should().Be(0);
        StringTools.BinaryToDecimal("101").Should().Be(5);
        StringTools.BinaryToDecimal("1010").Should().Be(10);
        StringTools.BinaryToDecimal("a001").Should().Be(-1);
    }

    [Fact]
    public void T05_UniqueCharacters()
    {
        StringTools.GetUniqueCharacters("aabbccdd").Should().Be("abcd");
        StringTools.GetUniqueCharacters("abcdeabcde").Should().Be("abcde");
        StringTools.GetUniqueCharacters("abcd").Should().Be("abcd");
        StringTools.GetUniqueCharacters("                       ").Should().Be(" ");
    }
}