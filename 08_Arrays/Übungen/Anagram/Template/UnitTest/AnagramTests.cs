/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Anagram UnitTest
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;
using Anagram;
using Xunit;

public class AnagramTests
{
    [Theory]
    [InlineData("Tom", "moT")]
    [InlineData("Otto", "Toto")]
    [InlineData("Voldemort", "Tomrodlev")]
    [InlineData("Ehrensenf", "Fernsehen")]
    [InlineData("Angstbude", "Bundestag")]
    [InlineData("Schachspielen", "Schnapsleiche")]
    [InlineData("erst", "Rest")]
    [InlineData("Brei", "Bier")]
    [InlineData("Lampe", "Ampel")]
    [InlineData("Ampel", "Palme")]
    [InlineData("Lager", "Regal")]
    public void T01_IsAnagram(string text, string compareWith)
    {
        Anagram.IsAnagram(text, compareWith).Should().BeTrue();
    }

    [Theory]
    [InlineData("Tom", "Rom")]
    [InlineData("", "")]
    [InlineData("Tom", "")]
    [InlineData("", "Tom")]
    [InlineData("OTTO", "OTTO")]
    [InlineData("OTTO", "otto")]
    [InlineData("#Otto#", "##Otto")]
    [InlineData("Xrst", "Rest")]
    [InlineData("Xrei", "Bier")]
    [InlineData("Xampe", "Ampel")]
    [InlineData("Xmpel", "Palme")]
    [InlineData("Xager", "Regal")]
    [InlineData("OTTT", "ooot")]
    public void T02_IsNoAnagram(string text, string compareWith)
    {
        Anagram.IsAnagram(text, compareWith).Should().BeFalse();
    }

    [Theory]
    [InlineData("Tom", "moT", new[] {2, 1, 0})]
    [InlineData("Otto", "Toto", new[] {1, 0, 2, 3})]
    [InlineData("Voldemort", "Tomrodlev", new[] {8, 1, 6, 5, 7, 2, 4, 3, 0})]
    [InlineData("Ehrensenf", "Fernsehen", new[] {1, 6, 2, 5, 3, 4, 7, 8, 0})]
    [InlineData("Angstbude", "Bundestag", new[] {7, 2, 8, 5, 6, 0, 1, 3, 4})]
    [InlineData("Schachspielen", "Schnapsleiche", new[] {0, 1, 2, 4, 10, 11, 6, 5, 9, 8, 7, 12, 3})]
    [InlineData("erst", "Rest", new[] {1, 0, 2, 3})]
    [InlineData("Brei", "Bier", new[] {0, 3, 2, 1})]
    [InlineData("Lampe", "Ampel", new[] {4, 0, 1, 2, 3})]
    [InlineData("Ampel", "Palme", new[] {1, 3, 0, 4, 2})]
    [InlineData("Lager", "Regal", new[] {4, 3, 2, 1, 0})]
    public void T03_GetConvert(string text, string compareWith, int[] expected)
    {
        Anagram.GetAnagramConversion(text, compareWith).Should().Equal(expected);
    }

    [Theory]
    [InlineData("Xager", "Regal")]
    [InlineData("", "")]
    public void T04_GetConvertFailed(string text, string compareWith)
    {
        Anagram.GetAnagramConversion(text, compareWith).Should().BeNull();
    }

    [Theory]
    [InlineData("Tom", new[] {2, 1, 0}, "moT")]
    [InlineData("Otto", new[] {1, 0, 2, 3}, "Toto")]
    [InlineData("Voldemort", new[] {8, 1, 6, 5, 7, 2, 4, 3, 0}, "Tomrodlev")]
    [InlineData("Ehrensenf", new[] {1, 6, 2, 5, 3, 4, 7, 8, 0}, "Fernsehen")]
    [InlineData("Angstbude", new[] {7, 2, 8, 5, 6, 0, 1, 3, 4}, "Bundestag")]
    [InlineData("Schachspielen", new[] {0, 1, 2, 4, 10, 11, 6, 5, 9, 8, 7, 12, 3}, "Schnapsleiche")]
    [InlineData("erst", new[] {1, 0, 2, 3}, "Rest")]
    [InlineData("Brei", new[] {0, 3, 2, 1}, "Bier")]
    [InlineData("Lampe", new[] {4, 0, 1, 2, 3}, "Ampel")]
    [InlineData("Ampel", new[] {1, 3, 0, 4, 2}, "Palme")]
    [InlineData("Lager", new[] {4, 3, 2, 1, 0}, "Regal")]
    public void T05_Convert(string text, int[] convert, string expected)
    {
        Anagram.ConvertAnagram(text, convert).Should().BeEquivalentTo(expected);
    }
}