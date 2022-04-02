/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Traveler Salesman problem UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;
using TravelerSalesman;
using Xunit;

using System;

public class DistanceTabelTests
{
    [Fact]
    public void T01_CreateDistanceTable()
    {
        var locations = new double[,]
        {
            {1.0, 1.0},
            {2.0, 2.0},
            {3.0, 1.0},
        };

        var distanceTable = TravelerSalesman.CreateDistanceTable(locations);
        var sqrt2 = Math.Sqrt(2);
        distanceTable.Should().BeEquivalentTo(new[,]
        {
            {0.0, sqrt2, 2.0},
            {sqrt2, 0.0, sqrt2},
            {2.0, sqrt2, 0.0}
        });
    }

    [Fact]
    public void T02_CheckFor0()
    {
        var locations = new double[,]
        {
            {1.0, 10.0},
            {2.0, 9.0},
            {3.0, 8.0},
            {4.0, 7.0},
            {5.0, 6.0},
            {6.0, 5.0},
            {7.0, 4.0},
            {8.0, 3.0},
            {9.0, 2.0},
            {10.0, 1.0},
        };

        var rows = locations.GetLength(0);
        var distanceTable = TravelerSalesman.CreateDistanceTable(locations);

        for (int row = 0; row < rows; row++)
        {
            distanceTable[row, row].Should().Be(0);
        }
    }

    [Fact]
    public void T02_CheckForMirror()
    {
        var locations = new double[,]
        {
            {1.0, 10.0},
            {2.0, 9.0},
            {3.0, 8.0},
            {4.0, 7.0},
            {5.0, 6.0},
            {6.0, 5.0},
            {7.0, 4.0},
            {8.0, 3.0},
            {9.0, 2.0},
            {10.0, 1.0},
        };

        var rows = locations.GetLength(0);
        var distanceTable = TravelerSalesman.CreateDistanceTable(locations);

        for (int row = 0; row < rows/2; row++)
        {
            for (int col = 0; col < rows / 2; col++)
            {
                distanceTable[row, col].Should().Be(distanceTable[col,row]);
            }
        }
    }
}