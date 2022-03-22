/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Book Library UnitTest
*--------------------------------------------------------------
*/


namespace UnitTest
{
    using FluentAssertions;
    using BookLibrary;
    using Xunit;

    public class ProgramTests
    {
        [Fact]
        public void T01_CheckIsbn_CorrectLength_ShouldReturnTrue()
        {
            Program.CheckIsbn("3760778739").Should().BeTrue();
        }

        [Fact]
        public void T02_CheckIsbn_TooShort_ShouldReturnFalse()
        {
            Program.CheckIsbn("376077879").Should().BeFalse();
        }

        [Fact]
        public void T03_CheckIsbn_TooLong_ShouldReturnFalse()
        {
            Program.CheckIsbn("37607787390").Should().BeFalse();
        }


        [Fact]
        public void T04_CheckIsbn_IllegalChar_ShouldReturnFalse()
        {
            Program.CheckIsbn("3760A78739").Should().BeFalse();
        }

        [Fact]
        public void T05_CheckIsbn_XAtEnd_ShouldReturnTrue()
        {
            Program.CheckIsbn("355151710X").Should().BeTrue();
        }

        [Fact]
        public void T06_CheckIsbn_XInTheMiddle_ShouldReturnFalse()
        {
            Program.CheckIsbn("355X151710").Should().BeFalse();
        }

        [Fact]
        public void T07_CheckIsbn_CheckSum_ShouldReturnTrue()
        {
            Program.CheckIsbn("3866801920").Should().BeTrue();
            Program.CheckIsbn("3680087837").Should().BeTrue();
        }

        [Fact]
        public void T08_CheckIsbn_WrongCheckSum_ShouldReturnFalse()
        {
            Program.CheckIsbn("355150710X");
        }
    }
}