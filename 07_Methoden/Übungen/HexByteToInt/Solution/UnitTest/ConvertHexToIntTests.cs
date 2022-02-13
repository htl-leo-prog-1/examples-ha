/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: HexToInt UnitTests
*--------------------------------------------------------------
*/

namespace HexConverter.Tests
{
    using FluentAssertions;
    using Xunit;

    public class ConvertHexToIntTests
    {
        public void T01_ConvertHexChar_Ok()
        {
            HexToInt.HexCharToInt('0').Should().Be(0);
            HexToInt.HexCharToInt('9').Should().Be(9);
            HexToInt.HexCharToInt('a').Should().Be(10);
            HexToInt.HexCharToInt('A').Should().Be(10);
            HexToInt.HexCharToInt('c').Should().Be(12);
            HexToInt.HexCharToInt('C').Should().Be(12);
            HexToInt.HexCharToInt('f').Should().Be(15);
            HexToInt.HexCharToInt('F').Should().Be(15);
        }

        [Fact]
        public void T02_ConvertHexChar_Failure()
        {
            HexToInt.HexCharToInt('x').Should().Be(-1);
            HexToInt.HexCharToInt('H').Should().Be(-1);
            HexToInt.HexCharToInt(' ').Should().Be(-1);
        }

        [Fact]
        public void T03_ConvertHexByte_Ok()
        {
            HexToInt.HexByteToInt("0A").Should().Be(10);
            HexToInt.HexByteToInt("10").Should().Be(16);
            HexToInt.HexByteToInt("ff").Should().Be(255);
            HexToInt.HexByteToInt("88").Should().Be(8 * 16 + 8);
        }

        [Fact]
        public void T04_ConvertHexByte_Failure()
        {
            HexToInt.HexByteToInt("ax").Should().Be(-1);
            HexToInt.HexByteToInt("aaa").Should().Be(-1);
            HexToInt.HexByteToInt("xa").Should().Be(-1);
        }
    }
}