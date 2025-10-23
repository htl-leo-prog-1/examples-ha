/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: ChessGame
*--------------------------------------------------------------
*/

namespace UnitTests;

using System;
using System.Linq;

using FluentAssertions;

using Chess;

using Xunit;

public sealed class ChessTests
{
    private static (int Row, int Col) ToPosition(string position)
    {
        if (position.Length != 2)
        {
            throw new ArgumentException();
        }

        var (row, col) = ((int)(position[1] - '1'), (int)(position[0] - 'A'));

        if (!Tools.InRange(row, 7, 0) || !Tools.InRange(col, 7, 0))
        {
            throw new ArgumentException();
        }

        return (row, col);
    }

    private static bool IsTypeChessPiece(ChessPiece chessPiece, int type, bool isBlack)
    {
        return chessPiece.Type == type && chessPiece.IsBlack == isBlack;
    }

    [Fact]
    public void ReadCsvTest()
    {
        var chessPieces = Chess.ReadFromCsv("StartGame.csv");

        chessPieces.Should().HaveCount(32);

        chessPieces.GroupBy(s => s.Type).Should().HaveCount(6); // we have 6 different ChessPieces-Types
        chessPieces.Where(s => s.IsBlack).Should().HaveCount(16);
        chessPieces.Where(s => !s.IsBlack).Should().HaveCount(16);

        chessPieces.Single(s => IsTypeChessPiece(s, ChessPiece.King, true)).Should().BeEquivalentTo(
            new ChessPiece()
            {
                Type    = ChessPiece.King,
                Row     = ToPosition("E8").Row,
                Col     = ToPosition("E8").Col,
                IsBlack = true
            });

        chessPieces.Single(s => IsTypeChessPiece(s, ChessPiece.Queen, false)).Should().BeEquivalentTo(
            new ChessPiece()
            {
                Type    = ChessPiece.Queen,
                Row     = ToPosition("D1").Row,
                Col     = ToPosition("D1").Col,
                IsBlack = false
            });

        chessPieces.Should().OnlyContain(s => Tools.InRange(s.Row, 7, 0));
        chessPieces.Should().OnlyContain(s => Tools.InRange(s.Col, 7, 0));

        chessPieces.GroupBy(s => (s.Row, s.Col)).Should().HaveCount(32);

        chessPieces.Where(s => IsTypeChessPiece(s, ChessPiece.Pawn, true)).Should().OnlyContain(s => s.Row == 6);
        chessPieces.Where(s => IsTypeChessPiece(s, ChessPiece.Pawn, false)).Should().OnlyContain(s => s.Row == 1);
    }

    [Theory]
    [InlineData("StartGame.csv")]
    [InlineData("Game1.csv")]
    public void CreateFieldOk(string fileName)
    {
        var chessPieces = Chess.ReadFromCsv(fileName);
        var field       = Chess.CreateField(chessPieces);

        field.Should().NotBeNull();
        field.GetLength(0).Should().Be(8);
        field.GetLength(1).Should().Be(8);

        foreach (var chessPiece in chessPieces)
        {
            field[chessPiece.Row, chessPiece.Col].Should().Be(chessPiece);
        }

        Chess.Print(chessPieces);
    }

    [Theory]
    [InlineData("GameInvalidPawnRowB.csv")]
    [InlineData("GameInvalidPawnRowW.csv")]
    [InlineData("GameInvalidPawnCountB.csv")]
    [InlineData("GameInvalidPawnCountW.csv")]
    [InlineData("GameInvalidPawnQueenCountW.csv")]
    [InlineData("GameInvalidPawnQueenCountB.csv")]
    [InlineData("GameInvalidPawnQueenKnightCountW.csv")] 
    public void CreateFieldFail(string fileName)
    {
        var chessPieces = Chess.ReadFromCsv(fileName);
        var field       = Chess.CreateField(chessPieces);

        field.Should().BeNull();
    }
}