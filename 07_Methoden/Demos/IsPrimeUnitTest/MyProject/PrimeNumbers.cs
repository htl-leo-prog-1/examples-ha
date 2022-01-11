/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MyTemplate
*--------------------------------------------------------------
*/

namespace MyProject;

public static class PrimeNumbers
{
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

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}