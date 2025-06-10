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
        RationalNumber bestPi = CalcBestPiApproximation(1000);

        Console.WriteLine($"Best Pi approximation: {bestPi.ToString()}={bestPi.Value} (Diff:) {DiffToPi(bestPi)}");
    }
    //TODO: Write CalcBestPiApproximation
    //TODO: Write DiffToPi (calculated with double)
}

