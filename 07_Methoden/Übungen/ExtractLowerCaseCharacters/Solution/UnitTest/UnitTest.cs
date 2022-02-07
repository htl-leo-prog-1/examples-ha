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
using ExtractLowerCaseCharacters;

public class ProgramTests
{
    [Fact]
    public void T01_SingleLowerCaseChar()
    {
        string text = "x";
        string expected = "x";
        int position = 0;
        int length = 1;
        Program.ExtractLowerCaseCharacters(text, position, length).Should().Be(expected);
    }

    [Fact]
    public void T02_MixedStringSingleLowerCaseChar()
    {
        string text = "Hello";
        string expected = "l";
        int position = 2;
        int length = 1;
        Program.ExtractLowerCaseCharacters(text, position, length).Should().Be(expected);
    }

    [Fact]
    public void T03_MixedStringMultipleLowerCaseChars()
    {
        string text = "Hello";
        string expected = "llo";
        int position = 2;
        int length = 3;
        Program.ExtractLowerCaseCharacters(text, position, length).Should().Be(expected);
        ;
    }

    [Fact]
    public void T04_MixedStringTooMuchLowerCaseChars()
    {
        string text = "Hello";
        string expected = "llo";
        int position = 2;
        int length = 6;
        Program.ExtractLowerCaseCharacters(text, position, length).Should().Be(expected);
    }

    [Fact]
    public void T05_MixedStringTooMuchMixedCaseChars()
    {
        string text = "HeLLo";
        string expected = "eo";
        int position = 1;
        int length = 3;
        Program.ExtractLowerCaseCharacters(text, position, length).Should().Be(expected);
    }

    [Fact]
    public void T06_OnlyUpperCaseText()
    {
        string text = "HELLO";
        string expected = "";
        int position = 1;
        int length = 3;
        Program.ExtractLowerCaseCharacters(text, position, length).Should().Be(expected);
    }
}