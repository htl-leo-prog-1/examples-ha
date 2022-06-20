/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: ChessGame
*--------------------------------------------------------------
*/

namespace UnitTests;

using System.Linq;

using FluentAssertions;

using Chess;

using Xunit;

public sealed class ChessTests
{
    [Fact]
    public void ReadCsvTest()
    {
        var chessPieces = Chess.ReadFromCsv("ValidchessPieces.csv");

        chessPieces.Should().HaveCount(12);

        chessPieces.GroupBy(s => s.chessPiecesize).Should().HaveCount(5);
        chessPieces.Single(s => s.chessPiecesize == 5).Should().BeEquivalentTo(
            new ChessPiece()
            {
                chessPiecesize   = 5,
                Col        = 5,
                Row        = 9,
                IsVertical = false
            });

        chessPieces.Single(s => s.chessPiecesize == 4 && s.Col == 0).Should().BeEquivalentTo(
            new ChessPiece()
            {
                chessPiecesize   = 4,
                Col        = 0,
                Row        = 2,
                IsVertical = true
            });
    }

    private string ToString(bool[,] field, int row)
    {
        string result = "";
        for (int col = 0; col < field.GetLength(1); col++)
        {
            result += field[row, col] ? "1" : "0";
        }

        return result;
    }

    [Fact]
    public void CreateFieldOk()
    {
        var chessPieces = Chess.ReadFromCsv("ValidchessPieces.csv");
        var field = Chess.CreateField(chessPieces);

        field.Should().NotBeNull();
        field.GetLength(0).Should().Be(10);
        field.GetLength(1).Should().Be(10);

        string[] expected =
        {
            "1101001111",
            "0001000000",
            "1001011101",
            "1000000001",
            "1000000000",
            "1000010101",
            "0000010001",
            "1100000001",
            "0000000000",
            "0010011111"
        };

        for (int row = 0; row < field.GetLength(0); row++)
        {
            ToString(field, row).Should().Be(expected[row]);
        }
    }

    [Fact]
    public void CreateFieldAmount()
    {
        var chessPieces = Chess.ReadFromCsv("InValidchessPiecesAmount.csv");
        var field = Chess.CreateField(chessPieces);

        field.Should().BeNull();
    }

    [Fact]
    public void CreateFieldInvalidPosition()
    {
        var chessPieces = Chess.ReadFromCsv("InValidchessPiecesPosition.csv");
        var field = Chess.CreateField(chessPieces);

        field.Should().BeNull();
    }

    [Theory]
    [InlineData(2, 2, 1, true,  "hit other ship")]
    [InlineData(1, 1, 1, true,  "ship is diagonal below")]
    [InlineData(2, 1, 1, true,  "ship is right")]
    [InlineData(2, 3, 1, true,  "ship is left")]
    [InlineData(1, 2, 1, true,  "ship is below")]
    [InlineData(1, 3, 1, true,  "ship is diagonal below")]
    [InlineData(0, 9, 2, false, "boarder right")]
    [InlineData(9, 2, 2, true,  "boarder bottom")]
    [InlineData(9, 9, 2, true,  "boarder right/bottom")]
    [InlineData(9, 9, 2, false,  "boarder right/bottom")]
    public void PlaceShipInvalidTest(int row, int col, int size, bool isVertical, string reason)
    {
        var shipOnField = new ChessPiece() { Row = 2, Col   = 2, chessPiecesize   = 5, IsVertical    = true };
        var ship        = new ChessPiece() { Row = row, Col = col, chessPiecesize = size, IsVertical = isVertical };
        var field       = new bool[10, 10];
        
        Chess.ArrangeChessPiece(field, shipOnField).Should().BeTrue();

        Chess.ArrangeChessPiece(field, ship).Should().BeFalse(reason);
    }
}