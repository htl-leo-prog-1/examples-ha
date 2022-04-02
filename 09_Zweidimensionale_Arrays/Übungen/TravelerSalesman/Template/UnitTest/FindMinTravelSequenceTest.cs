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

public class FindMinTravelSequenceTest
{
    private static double CalcDist(double sizeX, double sizeY)
    {
        return Math.Sqrt(sizeX * sizeX + sizeY * sizeY);
    }

    [Fact]
    public void T21_MinTravelSize1()
    {
        var locations = new double[,]
        {
            {1.0, 1.0},
            {2.0, 2.0},
            {3.0, 1.0},
        };

        double minDistance;
        var travel = TravelerSalesman.FindMinTravelSequence(locations, out minDistance);

        travel.Should().Equal(new[] {0, 1, 2});
        minDistance.Should().Be(CalcDist(1, 1) + CalcDist(1, 1) + CalcDist(2, 0));
    }

    [Fact]
    public void T21_MinTravelSizeX()
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

        double minDistance;
        var travel = TravelerSalesman.FindMinTravelSequence(locations, out minDistance);

        travel.Should().Equal(new[] {0, 1, 2, 4, 5, 6, 7, 8, 9, 3});
        minDistance.Should().Be(25.45584412271571);
    }

    [Fact]
    public void T21_RotateTravel()
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

        int[] Rotate(int[] table)
        {
            var result = new int[table.Length];
            result[^1] = table[0];

            for (int i = 1; i < table.Length; i++)
            {
                result[i - 1] = table[i];
            }

            return result;
        }

        double minDistance;
        var travel = TravelerSalesman.FindMinTravelSequence(locations, out minDistance);
        var distanceTable = TravelerSalesman.CreateDistanceTable(locations);

        for (int i = 0; i < travel.Length; i++)
        {
            travel = Rotate(travel);
            TravelerSalesman.CalculateDistance(distanceTable, travel).Should()
                .BeApproximately(minDistance, 0.0000000000001);
        }
    }

    [Fact]
    public void T21_RotateLocation()
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

        double[,] Rotate(double[,] table)
        {
            var size = table.GetLength(0);
            var result = new double[size, 2];

            result[size - 1, 0] = table[0, 0];
            result[size - 1, 1] = table[0, 1];

            for (int i = 1; i < size; i++)
            {
                result[i - 1, 0] = table[i, 0];
                result[i - 1, 1] = table[i, 1];
            }

            return result;
        }

        double CalcMinDist(double[,] location)
        {
            double minDistance;
            var travel = TravelerSalesman.FindMinTravelSequence(location, out minDistance);
            return minDistance;
        }

        var minDistance = CalcMinDist(locations);

        var size = locations.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            locations = Rotate(locations);
            CalcMinDist(locations).Should().BeApproximately(minDistance, 0.0000000000001);
        }
    }
}