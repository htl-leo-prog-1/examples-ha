/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Check HTL Leonding Number 
*--------------------------------------------------------------
*/

using System;

bool IsHtlLeondingNumber(int number)
{
    int sumOfDigit = SumOfDigit(number);
    if (number %2 == 0 || sumOfDigit <= 10)
    {
        return false;
    }

    bool isHtlNumber = false;

    for (int compareNumber = 1; compareNumber < number && !isHtlNumber; compareNumber++)
    {
        if (sumOfDigit == SumOfDigit(compareNumber))
        {
            int ggt = GGT(number, compareNumber);
            isHtlNumber = IsPrim(ggt);
        }
    }

    return isHtlNumber;

}

int SumOfDigit(int number)
{
    int sumOfDigit = 0;

    while (number > 0)
    {
        sumOfDigit += number % 10;
        number /= 10;
    }

    return sumOfDigit;
}

int GGT(int a, int b)
{
    if (b != 0)
    {
        int c;
        do
        {
            c = a % b;
            a = b;
            b = c;
        } while (c != 0);
    }
    return a;
}

bool IsPrim(int number)
{
    bool isPrim = number > 1;

    for (int i = 2; i <= number/2 && isPrim; i++)
    {
        isPrim = number % i != 0;
    }

    return isPrim;
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

Console.WriteLine("Find HTL Leonding Number Numbers ");
Console.WriteLine("****************************");

Console.Write("Calculate until:  ");
int calculateUntil = int.Parse(Console.ReadLine());
Console.WriteLine("****************************");

int count = 0;

for (int i = 1; i < calculateUntil; i++)
{
    if (IsHtlLeondingNumber(i))
    {
        PrintNumber(i, count, 10);
        count++;
    }
}

Console.WriteLine();
Console.WriteLine("****************************");