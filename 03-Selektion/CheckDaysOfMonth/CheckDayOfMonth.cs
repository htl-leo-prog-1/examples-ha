/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *                Musterlösung - HA
 *--------------------------------------------------------------
 * Description:
 * Check, if a specified day is valid.
 *--------------------------------------------------------------
*/

using System;

int month;
int day;
bool isLeapYear;

int daysInMonth;


Console.WriteLine("Check Day Of Year");
Console.WriteLine("-----------------------");

Console.Write("Please enter month [1..12]: ");
month = int.Parse(Console.ReadLine());

Console.Write("Please enter day [1..31]:   ");
day = int.Parse(Console.ReadLine());

Console.Write("Is Leap-Year [y/n]:         ");
isLeapYear = Console.ReadLine().ToUpper()=="Y";

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
        daysInMonth = isLeapYear ? 29 : 28;
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
        Console.WriteLine($"The date {day}.{month} is valid");
    }
    else
    {
        Console.WriteLine($"Invalid day: Month {month} should be: 1 <= {day} <= {daysInMonth}");
    }
}