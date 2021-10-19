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

Console.Write("Please enter month [1..12] ");
var month = Convert.ToInt32(Console.ReadLine());

Console.Write("Please enter day [1..31] ");
var day = Convert.ToInt32(Console.ReadLine());

int daysInMonth;

switch (month)
{
    case 1:
    case 3:
    case 5:
    case 7:
    case 8:
    case 10:
    case 12:
        daysInMonth = 31;
        break;
    case 4:
    case 6:
    case 9:
    case 11:
        daysInMonth = 30;
        break;
    case 2:
        daysInMonth = 28;
        break;
    default:
        daysInMonth = 0;
        Console.WriteLine($"Invalid month {month}");
        break;
}

if (daysInMonth > 0)
{
    if (day >= 1 && day <= daysInMonth)
    {
        var dayOfYear = day;

        switch (month)
        {
            default:
                break;
            case 2:
                dayOfYear += 31;
                break;
            case 3:
                dayOfYear += 31 + 28;
                break;
            case 4:
                dayOfYear += 31 + 28 + 31;
                break;
            case 5:
                dayOfYear += 31 + 28 + 31 + 30;
                break;
            case 6:
                dayOfYear += 31 + 28 + 31 + 30 + 31;
                break;
            case 7:
                dayOfYear += 31 + 28 + 31 + 30 + 31 + 30;
                break;
            case 8:
                dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31;
                break;
            case 9:
                dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31;
                break;
            case 10:
                dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30;
                break;
            case 11:
                dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31;
                break;
            case 12:
                dayOfYear += 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30;
                break;
        }

        Console.WriteLine($"Day of the year {month}:{day} = {dayOfYear}");
    }
    else
    {
        Console.WriteLine($"Invalid day: in month {month} should be: 1 <= {day} <= {daysInMonth}");
    }
}