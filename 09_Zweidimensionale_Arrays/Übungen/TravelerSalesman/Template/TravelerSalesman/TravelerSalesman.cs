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
    //TODO: Implement FindMinTravelSequence
    //TODO: Implement method CreateDistanceTable
    //TODO: Implement method CalculateDistance

    //TODO: if you need: implement other method 

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
}