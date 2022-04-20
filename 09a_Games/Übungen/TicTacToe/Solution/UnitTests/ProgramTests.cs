
namespace Games.Tests
{
    using FluentAssertions;

    using Xunit;
    using TicTacToe;

    public class ProgramTests
    {
        [Fact]
        public void T01_GetPositionRange()
        {
            Program.CheckPosition(3).Should().BeTrue();
        }
        [Fact]
        public void T02_GetPositionCellFree()
        {
            Board.Init(3,3,"TicTacToe");
            Program.CheckPosition(3).Should().BeTrue();
        }
        [Fact]
        public void T03_GetPositionCellUsed()
        {
            //Arange
            Board.Init(3, 3, "TicTacToe");
            Board.SetText(2,2,"O","Red");
            Program.CheckPosition(3).Should().BeFalse();
        }
    }

}