/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ChessGame
*--------------------------------------------------------------
*/

using System;

namespace Chess;

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
    
    public static bool IsMax(int[] ar1, int[] ar2)
    {
        if (ar1.Length != ar2.Length)
        {
            return false;
        }

        for (int i = 0; i < ar1.Length; i++)
        {
            if (ar1[i] > ar2[i])
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

    public static int ReadNumber(string message)
    {
        int  number;
        bool isOk;
        do
        {
            Console.Write(message);
            isOk = int.TryParse(Console.ReadLine(), out number);
        } while (!isOk);

        return number;
    }

    public static bool TryParse(string input, out int value, int max, int min)
    {
        input = input.Trim(' ');
        return int.TryParse(input, out value) && value >= min && value <= max;
    }

    public static bool InRange(int value, int max, int min)
    {
        return value >= min && value <= max;
    }
}