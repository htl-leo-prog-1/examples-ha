/*-----------------------------------------------------------------------------
 *				HTBLA-Leonding / Class: <your class name here>
 *-----------------------------------------------------------------------------
 * Exercise Number: n/a
 * File:			IsLeapYear.cs
 * Author(s):		Peter Bauer
 * Due Date:		n/a
 *-----------------------------------------------------------------------------
 * Description:
 * Checks whether a given year is a leap year
 *-----------------------------------------------------------------------------
*/

using System;

Console.WriteLine("Please enter a year");
int year = Convert.ToInt32(Console.ReadLine());

bool isDividableBy4   = year % 4 == 0;
bool isDividableBy100 = year % 100 == 0;
bool isDividableBy400 = year % 400 == 0;

bool isLeapYear = isDividableBy4 && (!isDividableBy100 || isDividableBy400);

if (isLeapYear)
{
    Console.WriteLine("Leap Year");
}
else
{
    Console.WriteLine("No Leap Year");
}