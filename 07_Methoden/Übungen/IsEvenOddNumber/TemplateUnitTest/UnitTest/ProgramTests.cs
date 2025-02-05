/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: IsEvenOddNumber UnitTests
 *--------------------------------------------------------------
 */

using FluentAssertions;

using Xunit;

using System.Linq;

using IsEvenOddNumber;

namespace UnitTest
{
    public class ProgramTests
    {
        [Fact]
        public void T01_TestOk9887()
        {
            Program.IsEvenOddNumber(9887).Should().BeTrue();
        }

        [Fact]
        public void T02_TestErrorMinus9887()
        {
            Program.IsEvenOddNumber(-9887).Should().BeFalse();
        }

        readonly int[] _evenOdds0To1000 = new[]
        {
            112, 121, 134, 143, 156, 165, 178, 187, 211, 314,
            336, 341, 358, 363, 385, 413, 431, 516, 538, 561,
            583, 615, 633, 651, 718, 781, 817, 835, 853, 871
        };

        [Fact]
        public void T03_TestOk0To1000()
        {
            foreach (var number in _evenOdds0To1000)
            {
                Program.IsEvenOddNumber(number).Should().BeTrue();
            }
        }

        [Fact]
        public void T04_TestError0To1000()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                if (!_evenOdds0To1000.Contains(i))
                {
                    Program.IsEvenOddNumber(i).Should().BeFalse();
                }
            }
        }
    }
}