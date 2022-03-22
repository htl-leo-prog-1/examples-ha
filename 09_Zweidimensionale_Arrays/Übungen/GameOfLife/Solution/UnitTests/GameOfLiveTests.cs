/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: GameOfLife
* see: https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
*--------------------------------------------------------------
*/

namespace UnitTests
{
    using FluentAssertions;
    using GameOfLife;
    using Xunit;

    public class GameOfLifeTests
    {
        private bool[,] World() => new bool[,]
        {
            {false, false, false, true},
            {false, false, false, true},
            {true, true, true, true},
            {true, true, false, false}
        };

        [Theory]
        [InlineData(1, 1, 3)]
        [InlineData(1, 2, 5)]
        [InlineData(2, 1, 4)]
        [InlineData(2, 2, 4)]
        public void T01_CountNeighboursTestMiddle(int row, int col, int expected)
        {
            GameOfLife.CountNeighbours(World(),row,col).Should().Be(expected); ;
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 3, 1)]
        [InlineData(3, 0, 3)]
        [InlineData(3, 3, 2)]
        public void T02_CountNeighboursTestCorner(int row, int col, int expected)
        {
            GameOfLife.CountNeighbours(World(), row, col).Should().Be(expected); ;
        }

        [Theory]
        [InlineData(0, 2, 2)]
        [InlineData(2, 0, 3)]
        [InlineData(3, 2, 4)]
        [InlineData(2, 3, 2)]
        public void T03_CountNeighboursTestBorder(int row, int col, int expected)
        {
            GameOfLife.CountNeighbours(World(), row, col).Should().Be(expected); ;
        }

        [Fact]
        public void T04_NextGeneration()
        {
            var world = World();
            var expect = new[,]
            {
                {false, false, false, false},
                {false, true, false, true},
                {true, false, false, true},
                {true, false, false, false}
            };

            GameOfLife.CalculateNextGeneration(world).Should().BeEquivalentTo(expect,
                options => options.ComparingByValue<bool>());
        }
    }
}