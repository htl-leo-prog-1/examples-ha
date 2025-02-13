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
        [InlineData("HaLlo Welt - heLlo world", "Ll", 0,  2)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 2,  2)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 3,  15)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 15, 15)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 16, -1)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 25, -1)]
        [InlineData("HaLlo Welt - heLlo world", "",   0,  -1)]
        [InlineData("HaLlo Welt - heLlo world", "",   25, -1)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", -1, -1)]
        [InlineData("Ll",                       "Ll", 0,  0)]
        [InlineData("Ll",                       "Ll", 1,  -1)]
        public void T01_IndexOf(string text, string searchString, int startIdx, int expected)
        {
            StringMethods.IndexOf(text, searchString, startIdx).Should().Be(expected);
        }

        [Theory]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 25, -1)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 23, 15)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 17, 15)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 16, 15)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 15, 2)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 14, 2)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 4,  2)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 3,  2)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 2,  -1)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", 1,  -1)]
        [InlineData("HaLlo Welt - heLlo world", "",   0,  -1)]
        [InlineData("HaLlo Welt - heLlo world", "",   25, -1)]
        [InlineData("HaLlo Welt - heLlo world", "Ll", -1, -1)]
        [InlineData("Ll",                       "Ll", 2,  0)]
        [InlineData("Ll",                       "Ll", 1,  0)]
        [InlineData("Ll",                       "Ll", 0,  -1)]
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
        [InlineData("HaLlo", 2, 2,     "Ll")]
        [InlineData("HaLlo", 2, 3,     "Llo")]
        [InlineData("HaLlo", 2, 4,     "Llo")]
        [InlineData("HaLlo", 0, 10000, "HaLlo")]
        [InlineData("HaLlo", -1, 4, "")]
        public void T04_SubString(string text, int startIdx, int count, string expected)
        {
            StringMethods.SubString(text, startIdx, count).Should().Be(expected);
        }

    }
}