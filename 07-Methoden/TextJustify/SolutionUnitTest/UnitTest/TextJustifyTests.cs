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

using TextJustify;

namespace UnitTest
{
    public class TextJustifyTests
    {
        [Theory]
        [InlineData(20, "One Two Three",             "One     Two    Three")]
        [InlineData(20, "  One    Two     Three   ", "One     Two    Three")]
        [InlineData(12, "  One    Two     Three   ", "One Two Three")]
        [InlineData(13, "  One    Two     Three   ", "One Two Three")]
        [InlineData(14, "  One    Two     Three   ", "One  Two Three")]
        [InlineData(15, "  One    Two     Three   ", "One  Two  Three")]
        [InlineData(15, "",                          "")]
        [InlineData(15, "HalloWelt",                 "HalloWelt")]
        [InlineData(5,  "HalloWelt",                 "HalloWelt")]
        public void T01_Justify(int size, string text, string expected)
        {
            TextJustifyTools.TextJustify(text, size).Should().Be(expected);
        }
    }
}