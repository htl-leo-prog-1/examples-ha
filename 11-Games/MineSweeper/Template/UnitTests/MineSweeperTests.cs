/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MineSweeper - UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;

using Xunit;

using MineSweeper;

public class MineSweeperTests
{
    [Fact]
    public void T01_CountMinesOnBoard_3()
    {
        bool[,] minesBoard =
        {
            { true, false, true },
            { false, false, true },
            { false, false, true }
        };

        MineSweeper.CountMinesOnBoard(minesBoard).Should().Be(4);
    }

    [Fact]
    public void T02_CountMinesOnBoard_0()
    {
        bool[,] minesBoard =
        {
            { false, false },
            { false, false }
        };
        MineSweeper.CountMinesOnBoard(minesBoard).Should().Be(0);
    }

    [Fact]
    public void T03_HideMines_10_in_25()
    {
        var minesBoard = MineSweeper.CreateMineField(10, 5, 5);
        MineSweeper.CountMinesOnBoard(minesBoard).Should().Be(10, "keine 10 Minen im Feld");
    }

    [Fact]
    public void T04_HideMines_25_in_25()
    {
        var minesBoard = MineSweeper.CreateMineField(25, 5, 5);
        MineSweeper.CountMinesOnBoard(minesBoard).Should().Be(25, "keine 25 Minen im Feld");
    }

    [Fact]
    public void T05_HideMines_0_in_25()
    {
        var minesBoard = MineSweeper.CreateMineField(0, 5, 5);
        MineSweeper.CountMinesOnBoard(minesBoard).Should().Be(0, "keine 0 Minen im Feld");
    }

    [Fact]
    public void T06_CountMinesAround_Corner()
    {
        bool[,] minesBoard =
        {
            { true, false, true },
            { false, false, true },
            { false, false, true }
        };
        MineSweeper.CountMinesAround(minesBoard, 0, 0).Should().Be(0, "0/0 hat keinen Nachbarn");
    }

    [Fact]
    public void T07_CountMinesAround_Center()
    {
        bool[,] minesBoard =
        {
            { true, false, true },
            { false, false, true },
            { false, false, true }
        };
        MineSweeper.CountMinesAround(minesBoard, 1, 1).Should().Be(4, "1/1 hat 4 Nachbarn");
    }

    [Fact]
    public void T08_CountMinesAround_LowerCorner()
    {
        bool[,] minesBoard =
        {
            { true, false, true },
            { false, false, true },
            { false, false, true }
        };
        MineSweeper.CountMinesAround(minesBoard, 2, 2).Should().Be(1, "2/2 hat 1 Nachbarn");
    }

    [Fact]
    public void T09_CountMinesAround_LastRow()
    {
        bool[,] minesBoard =
        {
            { true, false, true },
            { false, false, true },
            { false, false, true }
        };
        MineSweeper.CountMinesAround(minesBoard, 2, 1).Should().Be(2, "2/1 hat 2 Nachbarn");
    }
}