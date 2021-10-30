/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 *              Birgit Schröder
 *--------------------------------------------------------------
 * Description:
 * Sample solution for checking a date for correctness.
 *--------------------------------------------------------------
 */

using System;

Console.WriteLine("******************************************");
Console.WriteLine("    DateChecker checks your date          ");
Console.WriteLine("******************************************");
Console.WriteLine();

Console.WriteLine("Please enter a date!");
Console.Write("Year:  ");
int year = Convert.ToInt32(Console.ReadLine());
Console.Write("Month: ");
int month = Convert.ToInt32(Console.ReadLine());
Console.Write("Day:   ");
int day = Convert.ToInt32(Console.ReadLine());

bool isLeapYear = (year % 4 == 0) &&
                  (!(year % 100 == 0) || (year % 400 == 0));

int maxNrOfDays = 31;
switch (month)
{
    case 4:
    case 6:
    case 9:
    case 11:
        maxNrOfDays = 30;
        break;

    case 2:
        if (isLeapYear)
        {
            maxNrOfDays = 29;
        }
        else
        {
            maxNrOfDays = 28;
        }

        break;

    default:
        break;
}

bool dateIsOk = (year >= 0) &&
                (month >= 1 && month <= 12) &&
                (day >= 1 && day <= maxNrOfDays);
if (dateIsOk)
{
    Console.WriteLine("Date is ok");
}
else
{
    Console.WriteLine("Date is not ok");
}