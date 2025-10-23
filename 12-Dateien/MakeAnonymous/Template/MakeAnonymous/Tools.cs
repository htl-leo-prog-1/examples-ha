/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MakeAnonymous
*--------------------------------------------------------------
*/

namespace MakeAnonymous;

using System;

public static class Tools
{
    public static int ReadNumber(string message, int min, int max)
    {
        int number;
        bool isOk;
        do
        {
            Console.Write($"{message} [{min}..{max}]: ");
            isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
            if (!isOk)
            {
                Console.WriteLine("Ungültige Eingabe");
            }
        } while (!isOk);

        return number;
    }

    public static bool Contains(string[] ar, string value)
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
    
    public static int IndexOf(string[] ar, int length, string value)
    {
        for (int i=0;i<Math.Min(ar.Length,length);i++)
        {
            if (ar[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

    public static string[] Copy(string[] src, int count)
    {
        var dest = new string[count];
        for (int i = 0; i < Math.Min(src.Length,count); i++)
        {
            dest[i] = src[i];
        }

        return dest;
    }
    public static int ReadNumber(string message)
    {
        int number;
        bool isOk;
        do
        {
            Console.Write(message);
            isOk = int.TryParse(Console.ReadLine(), out number);
            if (!isOk)
            {
                Console.WriteLine("Ungültige Eingabe");
            }
        } while (!isOk);

        return number;
    }

    public static bool TryParse(string input, out int value, int min, int max)
    {
        input = input.Trim(' ');
        return int.TryParse(input, out value) && value >= min && value <= max;
    }

    public static bool InRange(int value, int min, int max)
    {
        return value >= min && value <= max;
    }
}