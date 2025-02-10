/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: TextJustify UnitTests
 *--------------------------------------------------------------
 */

using FluentAssertions;

using Xunit;

using StringMethodsEx;

namespace UnitTest
{
    public class StringMethodsTests
    {
        [Theory]
        [InlineData("Hallo Welt - hello world", "ll", 0,  2)]
        [InlineData("Hallo Welt - hello world", "ll", 2,  2)]
        [InlineData("Hallo Welt - hello world", "ll", 3,  15)]
        [InlineData("Hallo Welt - hello world", "ll", 15, 15)]
        [InlineData("Hallo Welt - hello world", "ll", 16, -1)]
        [InlineData("Hallo Welt - hello world", "ll", 25, -1)]
        [InlineData("Hallo Welt - hello world", "",   0,  -1)]
        [InlineData("Hallo Welt - hello world", "",   25, -1)]
        [InlineData("Hallo Welt - hello world", "ll", -1, -1)]
        [InlineData("ll",                       "ll", 0,  0)]
        [InlineData("ll",                       "ll", 1,  -1)]
        public void T01_IndexOf(string text, string searchString, int startIdx, int expected)
        {
            StringMethods.IndexOf(text, searchString, startIdx).Should().Be(expected);
        }

        [Theory]
        [InlineData("Hallo Welt - hello world", "ll", 25, -1)]
        [InlineData("Hallo Welt - hello world", "ll", 23, 15)]
        [InlineData("Hallo Welt - hello world", "ll", 15, 15)]
        [InlineData("Hallo Welt - hello world", "ll", 14, 2)]
        [InlineData("Hallo Welt - hello world", "ll", 2,  2)]
        [InlineData("Hallo Welt - hello world", "ll", 1,  -1)]
        [InlineData("Hallo Welt - hello world", "",   0,  -1)]
        [InlineData("Hallo Welt - hello world", "",   25, -1)]
        [InlineData("Hallo Welt - hello world", "ll", -1, -1)]
        [InlineData("ll",                       "ll", 1,  0)]
        [InlineData("ll",                       "ll", 0,  0)]
        public void T02_LastIndexOf(string text, string searchString, int startIdx, int expected)
        {
            StringMethods.LastIndexOf(text, searchString, startIdx).Should().Be(expected);
        }

        [Theory]
        [InlineData("NothingToReplace", "ll", "XXX", "NothingToReplace")]
        [InlineData("llToReplacell",    "ll", "XXX", "XXXToReplaceXXX")]
        [InlineData("llllToReplacell",  "ll", "XXX", "XXXXXXToReplaceXXX")]
        [InlineData("ll",               "ll", "XXX", "XXX")]
        [InlineData("llll",             "ll", "XXX", "XXXXXX")]
        [InlineData("lllll",            "ll", "XXX", "XXXXXXl")]
        [InlineData("lllll",            "ll", "",    "l")]
        [InlineData("llll",             "ll", "",    "")]
        [InlineData("llll",             "", "X",    "llll")]
        public void T03_Replace(string text, string searchString, string replaceWith, string expected)
        {
            StringMethods.Replace(text, searchString, replaceWith).Should().Be(expected);
        }

        [Theory]
        [InlineData("Hallo", 2, 2,     "ll")]
        [InlineData("Hallo", 2, 3,     "llo")]
        [InlineData("Hallo", 2, 4,     "llo")]
        [InlineData("Hallo", 0, 10000, "Hallo")]
        [InlineData("Hallo", -1, 4, "")]
        public void T04_SubString(string text, int startIdx, int count, string expected)
        {
            StringMethods.SubString(text, startIdx, count).Should().Be(expected);
        }

    }
}