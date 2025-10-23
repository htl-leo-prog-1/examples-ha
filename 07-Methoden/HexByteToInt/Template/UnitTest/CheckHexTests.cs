/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: HexToInt UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using HexConverter;
    using Xunit;

    public class CheckHexTests
    {
        [Fact]
        public void T01_IsHexCharTest_Digits()
        {
            HexToInt.IsHexChar('a').Should().BeTrue();
            HexToInt.IsHexChar('A').Should().BeTrue();
            HexToInt.IsHexChar('f').Should().BeTrue();
            HexToInt.IsHexChar('F').Should().BeTrue();
            for (char c = '0'; c <= '9'; c++)
            {
                HexToInt.IsHexChar(c).Should().BeTrue();
            }
        }

        [Fact]
        public void T02_IsHexCharTest_Letters_Small()
        {
            for (char c = 'a'; c <= 'f'; c++)
            {
                HexToInt.IsHexChar(c).Should().BeTrue();
            }
        }

        [Fact]
        public void T03_IsHexCharTest_Letters_Capital()
        {
            for (char c = 'A'; c <= 'F'; c++)
            {
                HexToInt.IsHexChar(c).Should().BeTrue();
            }
        }

        [Fact]
        public void T04_IsHexCharTest_InvalidChars()
        {
            // random
            HexToInt.IsHexChar(' ').Should().BeFalse();
            HexToInt.IsHexChar('%').Should().BeFalse();

            // Zeichen vor und nach Kleinbuchstaben
            HexToInt.IsHexChar('`').Should().BeFalse();
            HexToInt.IsHexChar('g').Should().BeFalse();

            // Zeichen vor und nach Großbuchstaben
            HexToInt.IsHexChar('@').Should().BeFalse();
            HexToInt.IsHexChar('G').Should().BeFalse();

            // Zeichen vor und nach Ziffen
            HexToInt.IsHexChar('/').Should().BeFalse();
            HexToInt.IsHexChar(':').Should().BeFalse();
        }

        [Fact]
        public void T05_IsHexByteTest_LengthFailure()
        {
            HexToInt.IsHexByteString("0").Should().BeFalse();
            HexToInt.IsHexByteString("").Should().BeFalse();
            HexToInt.IsHexByteString("123").Should().BeFalse();
        }

        [Fact]
        public void T06_IsHexByteTest_IllegalChar()
        {
            HexToInt.IsHexByteString("OA").Should().BeFalse();
            HexToInt.IsHexByteString("9 ").Should().BeFalse();
            HexToInt.IsHexByteString("AX").Should().BeFalse();
        }
    }
}