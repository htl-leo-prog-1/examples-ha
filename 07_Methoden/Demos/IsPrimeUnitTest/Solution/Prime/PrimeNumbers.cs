/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MyTemplate
*--------------------------------------------------------------
*/

namespace Prime;

using System;

public static class PrimeNumbers
{
    /// <summary>
    /// Test, if a number is a prime number.
    /// </summary>
    /// <param name="number">The number to be tested.</param>
    /// <returns>true if the number is a prime number.</returns>
    public static bool IsPrime(int number)
    {
        
        if (number < 0)
        {
            number = -number;
        }
    
        if (number < 2)
        {
            return false;
        }

        if (number % 2 == 0)
        {
            return number==2;
        }

        int maxCheck = (int)(Math.Sqrt(number));
        for (int i = 3; i <= maxCheck; i+=2)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static int NextPrime(int number)
    {
        do
        {
            number ++;
        } while (!IsPrime(number));

        return number;
    }

    public static int PrevPrime(int number)
    {
        do
        {
            number--;
        } while (!IsPrime(number));

        return number;
    }
}