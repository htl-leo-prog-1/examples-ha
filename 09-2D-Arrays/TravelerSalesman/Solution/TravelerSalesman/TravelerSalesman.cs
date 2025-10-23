/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Traveler Salesman problem
* see: https://de.wikipedia.org/wiki/Problem_des_Handlungsreisenden
*--------------------------------------------------------------
*/

namespace TravelerSalesman;

using System;
using System.Collections.Generic;

public class TravelerSalesman
{
    public static double[,] CreateDistanceTable(double[,] locations)
    {
        int locationCount = locations.GetLength(0);
        var distanceTable = new double[locationCount, locationCount];

        for (int row = 0; row < locationCount; row++)
        {
            for (int col = 0; col < locationCount; col++)
            {
                if (row != col)
                {
                    double x = locations[row, 0] - locations[col, 0];
                    double y = locations[row, 1] - locations[col, 1];
                    distanceTable[row, col] = Math.Sqrt(x * x + y * y);
                }
            }
        }

        return distanceTable;
    }

    public static int[][] CreatePermutations(int value)
    {
        void Exhaust(int idx, int[] permutation, bool[] used, List<int[]> result)
        {
            if (idx >= used.Length)
            {
                result.Add(permutation.Clone() as int[]);
            }
            else
            {
                for (int i = 0; i < used.Length; i++)
                {
                    if (!used[i])
                    {
                        permutation[idx] = i;
                        used[i] = true;
                        Exhaust(idx + 1, permutation, used, result);
                        used[i] = false;
                    }
                }
            }
        }

        var permutations = new List<int[]>();
        if (value > 0)
        {
            var used = new bool[value];
            var permutation = new int[value];

            used[0] = true;
            permutation[0] = 0;
            Exhaust(1, permutation, used, permutations);
        }

        return permutations.ToArray();
    }

    public static double CalculateDistance(double[,] distanceTable, int[] travel)
    {
        double sumDistance = distanceTable[travel[0], travel[^ 1]];

        for (int i = 1; i < travel.Length; i++)
        {
            sumDistance += distanceTable[travel[i - 1], travel[i]];
        }

        return sumDistance;
    }

    public static int[] FindMinTravelSequence(double[,] locations, out double minDistance)
    {
        var distanceTable = CreateDistanceTable(locations);
        var possibleTravels = CreatePermutations(locations.GetLength(0));

        minDistance = double.MaxValue;
        int[] minTravel = null;

        foreach (var travel in possibleTravels)
        {
            double thisDistance = CalculateDistance(distanceTable, travel);
            if (thisDistance < minDistance)
            {
                minTravel = travel;
                minDistance = thisDistance;
            }
        }

        return minTravel;
    }
}