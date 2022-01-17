/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Parameterübergabe
*--------------------------------------------------------------
*/

using System;

bool IsLeapYear(int year)
{
    return (year % 4 == 0) &&
           (!(year % 100 == 0) || (year % 400 == 0));
}

int DaysInMonth(int year, int month)
{
    switch (month)
    {
        case 4:
        case 6:
        case 9:
        case 11: return 30;

        case 2: return IsLeapYear(year) ? 29 : 28;
    }

    return 31;
}

int ReadNumber(string message, int max, int min)
{
    int number;
    bool isOk;
    do
    {
        Console.Write($"{message} [{min}..{max}]: ");
        isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
    } while (!isOk);

    return number;
}

int year = ReadNumber("Please enter year", 2999, 1);
int month = ReadNumber("Please enter month", 12, 1);
int day = ReadNumber("Please enter day", DaysInMonth(year,month), 1);

Console.WriteLine($"Date: {year}.{month}.{day}");
if (IsLeapYear(year))
{
    Console.WriteLine($"The {year} is a leap year");
}