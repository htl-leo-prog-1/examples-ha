/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *                Musterlösung - HA
 *--------------------------------------------------------------
 * Description:
 * Calculation of "DayOfYear" (without leap year)
 *--------------------------------------------------------------
*/

using System;

Console.WriteLine("Day of year calculation");
Console.WriteLine("-----------------------");

Console.Write("Please enter month [1..12]");
var month = Convert.ToInt32(Console.ReadLine());

Console.Write("Please enter day [1..31]");
var day = Convert.ToInt32(Console.ReadLine());

int daysInMonth;

if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
{
    daysInMonth = 31;
}
else if (month == 4 || month == 6 || month == 9 || month == 11)
{
    daysInMonth = 30;
}
else if (month == 2)
{
    daysInMonth = 28;
}
else
{
    daysInMonth = 0;
    Console.WriteLine($"Invalid month {month}");
}

if (daysInMonth > 0)
{
    if (day >= 1 && day <= daysInMonth)
    {
        var dayOfYear = day;

        if (month == 2)
        {
            dayOfYear += 31;
        }
        else if (month == 3)
        {
            dayOfYear += 31 + 28;
        }
        else if (month == 4)
        {
            dayOfYear += 31 + 28 + 31;
        }
        else if (month == 5)
        {
            dayOfYear += 31 + 28 + 31 + 30;
        }
        else if (month == 6)
        {
            dayOfYear += 31 + 28 + 31 + 30 + 31;
        }
        else if (month == 7)
        {
            dayOfYear += 31 + 28 + 31 + 30 + 31 + 30;
        }
        else if (month == 8)
        {
            dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31;
        }
        else if (month == 9)
        {
            dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31;
        }
        else if (month == 10)
        {
            dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30;
        }
        else if (month == 11)
        {
            dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31;
        }
        else if (month == 12)
        {
            dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30;
        }

        Console.WriteLine($"Day of the year {month}:{day} = {dayOfYear}");
    }
    else
    {
        Console.WriteLine($"Invalid day: in month {month} should be: 1 <= {day} <= {daysInMonth}");
    }
}