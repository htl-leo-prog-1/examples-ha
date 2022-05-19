/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Gomoku
*--------------------------------------------------------------
*/

namespace UnitTests;

using System.Collections.Generic;

using FluentAssertions;
using Gomoku;
using Xunit;

public sealed class GomokuTests
{
    [Theory]
    [MemberData(nameof(CheckWinnerData))]
    public void CheckWinner(int[][] fieldsToSet, int expectedIndex)
    {
        InitBoard(fieldsToSet);

        int winnerIdx = Gomoku.CheckWinner();

        winnerIdx.Should().Be(expectedIndex);
    }

    [Fact]
    public void GetFieldValues()
    {
        string e = string.Empty;
        string[,] expected =
        {
            { e, "O", e },
            { "O", e, e },
            { e, e, "X" }
        };
        InitBoard();

        string[,] fieldValues = Gomoku.GetFieldValues();

        fieldValues.Should()
            .BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(0, 1, 0)]
    [InlineData(0, 0, -1)]
    [InlineData(2, 1, -1)]
    [InlineData(2, 2, 1)]
    [InlineData(1, 0, 0)]
    public void GetPlayerIndexFromCell(int row, int col, int expectedIndex)
    {
        InitBoard();

        int playerIndex = Gomoku.GetPlayerIndexFromCell(row, col);

        playerIndex.Should().Be(expectedIndex);
    }

    [Theory]
    [InlineData(9, 0, 2)]
    [InlineData(5, 1, 1)]
    [InlineData(1, 2, 0)]
    [InlineData(-1, 2, -1)]
    [InlineData(1, 3, -1)]
    [InlineData(1, -1, -1)]
    public void GetColFromPosition(int position, int row, int expectedCol)
    {
        int column = Gomoku.GetColFromPosition(position, row);

        column.Should().Be(expectedCol);
    }

    [Theory]
    [InlineData(7, 0)]
    [InlineData(5, 1)]
    [InlineData(3, 2)]
    [InlineData(10, -1)]
    public void GetRowFromPosition(int position, int expectedRow)
    {
        int row = Gomoku.GetRowFromPosition(position);

        row.Should().Be(expectedRow);
    }

    [Theory]
    [InlineData(-1, false)]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(3, true)]
    [InlineData(5, true)]
    [InlineData(7, true)]
    [InlineData(9, true)]
    [InlineData(10, false)]
    public void CheckPositionValid(int position, bool expected)
    {
        bool isValid = Gomoku.CheckPositionValid(position);

        isValid.Should().Be(expected);
    }

    [Fact]
    public void InitPositions()
    {
        Board.Init(3, 3, string.Empty);
        Gomoku.InitPositions();

        int[,] numbers =
        {
            { 7, 8, 9 },
            { 4, 5, 6 },
            { 1, 2, 3 }
        };
        for (int row = 0; row < numbers.GetLength(0); row++)
        {
            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                Board.GetText(row, col).Should().BeEquivalentTo(numbers[row, col].ToString());
            }
        }
    }

    [Theory]
    [InlineData(3, true)]
    [InlineData(1, true)]
    [InlineData(7, true)]
    [InlineData(5, true)]
    [InlineData(0, false)]
    [InlineData(10, false)]
    [InlineData(11, false)]
    [InlineData(-3, false)]
    public void GetPosition_Range(int position, bool expected)
    {
        bool posValid = Gomoku.CheckPosition(position);

        posValid.Should().Be(expected);
    }

    [Theory]
    [InlineData(3, true)]
    [InlineData(1, true)]
    public void GetPosition_Free(int position, bool expected)
    {
        Board.Init(3,3,string.Empty);

        bool isFree = Gomoku.CheckPosition(position);

        isFree.Should().Be(expected);
    }

    [Theory]
    [InlineData(3, false)]
    [InlineData(5, true)]
    [InlineData(7, true)]
    [InlineData(8, false)]
    [InlineData(4, false)]
    [InlineData(6, true)]
    public void GetPosition_Mixed(int position, bool expected)
    {
        Board.Init(3, 3, string.Empty);
        int[,] fieldsToSet =
        {
            { 0, 1 },
            { 2, 2 },
            { 1, 0 }
        };
        for (int i = 0; i < fieldsToSet.GetLength(0); i++)
        {
            Board.SetText(fieldsToSet[i,0], fieldsToSet[i,1], "X", "Red");
        }

        bool isFree = Gomoku.CheckPosition(position);

        isFree.Should().Be(expected);
    }

    public static IEnumerable<object[]> CheckWinnerData => new[]
    {
        new object[]
        {
        new []
            {
                new[] { 0, 0, 1 },
                new[] { 1, 1, 1 },
                new[] { 2, 2, 1 }
            },
            1
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 2, 1 },
                new[] { 1, 1, 1 },
                new[] { 2, 0, 1 }
            },
            1
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 2, 0 },
                new[] { 1, 1, 0 },
                new[] { 2, 0, 0 }
            },
            0
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 0, 0 },
                new[] { 1, 1, 0 },
                new[] { 2, 2, 0 }
            },
            0
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 0, 1 },
                new[] { 1, 0, 1 },
                new[] { 2, 0, 1 }
            },
            1
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 2, 0 },
                new[] { 1, 2, 0 },
                new[] { 2, 2, 0 }
            },
            0
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 0, 1 },
                new[] { 0, 1, 1 },
                new[] { 0, 2, 1 }
            },
            1
        },
        new object[]
        {
            new[]
            {
                new[] { 2, 0, 0 },
                new[] { 2, 1, 0 },
                new[] { 2, 2, 0 }
            },
            0
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 0, 1 },
                new[] { 1, 1, 1 },
                new[] { 2, 0, 1 }
            },
            -1
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 2, 0 },
                new[] { 1, 1, 0 },
                new[] { 2, 2, 0 }
            },
            -1
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 2, 0 },
                new[] { 1, 1, 0 },
                new[] { 2, 2, 0 }
            },
            -1
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 1, 0 },
                new[] { 1, 0, 1 },
                new[] { 1, 1, 0 },
                new[] { 2, 2, 1 },
                new[] { 2, 1, 0 },
                new[] { 0, 2, 1 }
            },
            0
        },
        new object[]
        {
            new[]
            {
                new[] { 0, 1, 0 },
                new[] { 1, 0, 1 },
                new[] { 1, 2, 0 },
                new[] { 2, 2, 1 },
                new[] { 2, 1, 0 },
                new[] { 0, 2, 1 }
            },
            -1
        }
    };

    private static void InitBoard(int[][] fieldsToSet = null)
    {
        Board.Init(3, 3, string.Empty);
        fieldsToSet ??= new[]
        {
            new[] { 0, 1, 0 },
            new[] { 2, 2, 1 },
            new[] { 1, 0, 0 }
        };
        foreach (int[] cellDef in fieldsToSet)
        {
            Board.SetText(cellDef[0], cellDef[1],
                cellDef[2] == 0 ? "O" : "X", "Red");
        }
    }
}