/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: GameOfLife
 * see: https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
 *--------------------------------------------------------------
 */

namespace UnitTest;

using FluentAssertions;

using Xunit;

public class GameOfLifeTests
{
    private bool[,] Field() => new bool[,]
    {
        { false, false, false, false, false },
        { false, false, true, false, false },
        { false, false, false, false, false },
        { true, false, false, false, false }
    };

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(0, 1, false)]
    [InlineData(1, 0, true)]
    [InlineData(2, 0, false)]
    [InlineData(3, 4, true)]
    [InlineData(3, 0, false)]
    [InlineData(0, 4, true)]
    public void T01_CanSetShip(int row, int col, bool expected)
    {
        BattleShip.BattleShip.CanSetShip(Field(), row, col).Should().Be(expected);
    }

    [Fact]
    public void T02_LoadSaveTest()
    {
        var field1 = new[,]
        {
            { false, false, false, false, false },
            { false, false, true, false, false },
            { false, false, false, false, false },
            { true, false, false, false, false },
            { false, false, false, false, false },
        };

        BattleShip.BattleShip.SaveField(field1, "SavedField.csv");
        var loadedField = BattleShip.BattleShip.LoadField(field1.GetLength(0), "SavedField.csv");

        loadedField.Should().BeEquivalentTo(field1);
    }

    [Fact]
    public void T03_LoadSaveFailTest()
    {
        var field1 = new[,]
        {
            { false, false, false, false, false },
            { false, false, true, false, false },
            { false, false, false, false, false },
            { true, false, false, false, false },
            { false, false, false, true, true },
        };

        // illegal ship at 4:3 && 4:4 

        BattleShip.BattleShip.SaveField(field1, "SavedField.csv");
        var loadedField = BattleShip.BattleShip.LoadField(field1.GetLength(0), "SavedField.csv");

        loadedField.Should().BeNull();
    }

    [Fact]
    public void T04_ShipCount()
    {
        var field1 = new[,]
        {
            { false, false, true, true },
            { false, true, false, false },
            { false, false, false, false },
            { false, false, false, false }
        };

        var field2 = new[,]
        {
            { false, false, true, false },
            { false, false, true, false },
            { false, false, false, false },
            { false, false, false, false }
        };

        BattleShip.BattleShip.GetShipCount(field1).Should().Be(3);
        BattleShip.BattleShip.GetShipCount(field2).Should().Be(2);
    }
}