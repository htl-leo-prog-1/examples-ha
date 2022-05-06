/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ConnectFour - UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using ConnectFour;
    using FluentAssertions;
    using Xunit;

    public class ProgramTests
    {
        [Fact]
        public void T01_GetFreeRow_AllCellsFree()
        {
            int[,] allocation =
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };
            ConnectFour.GetFreeRow(allocation, 0).Should().Be(4);
        }

        [Fact]
        public void T02_GetFReeRow_Middle()
        {
            int[,] allocation =
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 2, 0, 0},
                {0, 0, 1, 0, 0}
            };

            ConnectFour.GetFreeRow(allocation, 2).Should().Be(1);
        }

        [Fact]
        public void T03_GetFReeRow_Full()
        {
            int[,] allocation =
            {
                {0, 0, 1, 0, 0},
                {0, 0, 2, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 2, 0, 0},
                {0, 0, 1, 0, 0}
            };

            ConnectFour.GetFreeRow(allocation, 2).Should().Be(-1);
        }

        [Fact]
        public void T04_IsWinner_No()
        {
            int[,] allocation =
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0}
            };
            ConnectFour.IsWinner(allocation, 4, 2).Should().Be(0);
        }

        [Fact]
        public void T05_IsWinner_Vertical()
        {
            int[,] allocation =
            {
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0}
            };
            ConnectFour.IsWinner(allocation, 1, 2).Should().Be(1);
        }

        [Fact]
        public void T06_IsWinner_Horizontal()
        {
            int[,] allocation =
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 2, 0},
                {0, 1, 1, 1, 1},
                {0, 2, 1, 2, 2}
            };
            ConnectFour.IsWinner(allocation, 3, 4).Should().Be(1);
        }

        [Fact]
        public void T07_IsWinner_Diagonal1()
        {
            int[,] allocation =
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0},
                {0, 0, 1, 2, 0},
                {0, 1, 1, 1, 0},
                {1, 2, 1, 2, 2}
            };
            ConnectFour.IsWinner(allocation, 1, 3).Should().Be(1);
        }

        [Fact]
        public void T08_IsWinner_Diagonal2()
        {
            int[,] allocation =
            {
                {0, 2, 0, 0, 0},
                {0, 2, 2, 0, 0},
                {0, 1, 1, 2, 0},
                {0, 1, 1, 1, 2},
                {1, 2, 1, 2, 2}
            };
            ConnectFour.IsWinner(allocation, 0, 1).Should().Be(2);
        }
    }
}