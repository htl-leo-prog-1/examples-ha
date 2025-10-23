/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: FilterVocals UnitTests
*--------------------------------------------------------------
*/

using FluentAssertions;
using Xunit;
using FilterVocals;

namespace UnitTest
{
    public class ProgramTests
    {
        [Fact]
        public void T01_Simple_OneVocal()
        {
            string text = "a";
            string expected = "a";
            Program.FilterVocals(text).Should().Be(expected, "a ==> a");
        }

        [Fact]
        public void T02_Simple_WithoutVocals()
        {
            string text = "x";
            string expected = "";
            Program.FilterVocals(text).Should().Be(expected, "x ==> ");
        }

        [Fact]
        public void T03_Simple_MultipleVocals()
        {
            string text = "Hello";
            string expected = "eo";
            Program.FilterVocals(text).Should().Be(expected, "Hello ==> eo");
        }

        [Fact]
        public void T04_Normal_UpperAndLower()
        {
            string text = "Upper and Low";
            string expected = "Ueao";
            Program.FilterVocals(text).Should().Be(expected, "Upper and Low ==> Ueao");
        }

        [Fact]
        public void T05_Normal_Doubles()
        {
            string text = "Hello World";
            string expected = "eo";
            Program.FilterVocals(text).Should().Be(expected, "Hello World ==> eo");
        }

        [Fact]
        public void T06_Normal_DoublesUpperLower()
        {
            string text = "HellO World";
            string expected = "eO";
            Program.FilterVocals(text).Should().Be(expected, "HellO World ==> eO");
        }

        [Fact]
        public void T07_Normal_Empty()
        {
            string text = "";
            string expected = "";
            Program.FilterVocals(text)
                .Should().Be(expected, "empty ==> \"\"");
        }
    }
}