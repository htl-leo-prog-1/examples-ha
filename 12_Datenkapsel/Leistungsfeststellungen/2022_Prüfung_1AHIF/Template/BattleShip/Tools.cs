/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: BattleShip
*--------------------------------------------------------------
*/

namespace BattleShip;

public static class Tools
{
    public static bool IsEqual(int[] ar1, int[] ar2)
    {
        if (ar1.Length != ar2.Length)
        {
            return false;
        }

        for (int i = 0; i < ar1.Length; i++)
        {
            if (ar1[i] != ar2[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool Contains(int[] ar, int value)
    {
        foreach (var v in ar)
        {
            if (v == value)
            {
                return true;
            }
        }

        return false;
    }

    public static bool InRange(int value, int max, int min)
    {
        return value >= min && value <= max;
    }
}