/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Harshad Numbers
*--------------------------------------------------------------
*/

using System;

bool HarshadNumbers(int number)
{
    int sumOfDigit = SumOfDigit(number);

    return number % sumOfDigit == 0;
}

int SumOfDigit(int number)
{
    int sumOfDigit = 0;

    while (number > 0)
    {
        int digit = number % 10;
        number = number / 10;

        sumOfDigit += digit;
    }

    return sumOfDigit;
}

void PrintNumber(int number, int count, int countPerLine)
{
    if (count != 0)
    {
        Console.Write(",");
    }

    if (count != 0 && count % countPerLine == 0)
    {
        Console.WriteLine();
    }

    Console.Write(number);
}

Console.WriteLine("Find Harshad Numbers ");
Console.WriteLine("****************************");

int count = 0;

for (int i = 1; i < 500; i++)
{
    if (HarshadNumbers(i))
    {
        PrintNumber(i, count, 10);
        count++;
    }
}

Console.WriteLine();
Console.WriteLine("****************************");

int harshadCount = 0;
int findFrom = 1;
int findTo = 1000000;

for (int i = findFrom; i < findTo; i++)
{
    if (HarshadNumbers(i))
    {
        harshadCount++;
    }
}

Console.WriteLine($"Found {harshadCount} Harshad numbers in the range of [{findFrom}..{findTo}]");
Console.WriteLine("****************************");
