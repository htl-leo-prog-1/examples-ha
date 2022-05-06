/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: RationalNumber
*--------------------------------------------------------------
*/

namespace RationalNumber;

using System;

class Program
{
    public static void Main()
    {
        var bestPi = CalcBestPiApproximation(1000);

        Console.WriteLine($"Best Pi approximation: {bestPi.ToString()}={bestPi.Value} (Diff:) {DiffToPi(bestPi)}");
    }

    private static RationalNumber CalcBestPiApproximation(int max)
    {
        var bestPi     = new RationalNumber(3, 1);
        var bestPiDiff = DiffToPi(bestPi);

        for (int numerator = 3; numerator < max; numerator++)
        {
            for (int denominator = 1; denominator < max; denominator++)
            {
                var thisPi     = new RationalNumber(numerator, denominator);
                var thisPiDiff = DiffToPi(thisPi);

                if (thisPiDiff < bestPiDiff)
                {
                    bestPi     = thisPi;
                    bestPiDiff = thisPiDiff;
                }
            }
        }

        return bestPi;
    }

    private static double DiffToPi(RationalNumber r)
    {
        return Math.Abs(Math.PI - r.Value);
    }
}

