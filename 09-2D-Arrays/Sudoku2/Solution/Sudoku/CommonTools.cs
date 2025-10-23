/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sudoku
*--------------------------------------------------------------
*/

namespace Sudoku;

public static class CommonTools
{
    public static int[] Intersect(int[] numbersA, int[] numbersB)
    {
        var result = new int[numbersA.Length];
        int count = 0;

        for (int i = 0; i < numbersA.Length; i++)
        {
            if (!Contains(numbersA, numbersA[i], i) && Contains(numbersB, numbersA[i]))
            {
                result[count] = numbersA[i];
                count++;
            }
        }

        return CopyArray(result, count);
    }

    public static bool Contains(int[] ar, int value)
    {
        foreach (var val in ar)
        {
            if (value == val)
            {
                return true;
            }
        }

        return false;
    }

    public static bool Contains(int[] ar, int value, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (value == ar[i])
            {
                return true;
            }
        }

        return false;
    }

    public static int[] Except(int[] from, int[] except)
    {
        var result = new int[from.Length];
        int count = 0;

        foreach (var val in from)
        {
            if (!Contains(except, val))
            {
                result[count] = val;
                count++;
            }
        }

        return CopyArray(result, count);
    }

    public static int[] CopyArray(int[] ar, int length)
    {
        var result = new int[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = ar[i];
        }

        return result;
    }
}