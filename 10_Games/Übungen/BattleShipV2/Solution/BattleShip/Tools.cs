/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: BattleShip
*--------------------------------------------------------------
*/

using System;

namespace BattleShip;

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