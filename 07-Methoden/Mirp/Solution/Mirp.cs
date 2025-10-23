/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Mirp
*--------------------------------------------------------------
*/

using System;

bool IsPrim(int number)
{
    if (number < 2 || number % 2 == 0)
    {
        return false;
    }

    if (number == 2)
    {
        return true;
    }

    for (int i = 3; i < number; i += 2)
    {
        if (number % i == 0)
            return false;
    }

    return true;
}

int Reverse(int number)
{
    int reverseNumber = 0;

    while (number > 0)
    {
        int digit = number % 10;
        number = number / 10;

        reverseNumber = reverseNumber * 10 + digit;
    }

    return reverseNumber;
}

bool IsMirp(int number)
{
    int reverseNumber = Reverse(number);

    return number != reverseNumber && IsPrim(number) && IsPrim(reverseNumber);
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

Console.WriteLine("Find Mirp Numbers ");
Console.WriteLine("****************************");

int count = 0;

for (int i = 10; i <= 1000; i++)
{
    if (IsMirp(i))
    {
        PrintNumber(i, count, 10);
        count++;
    }
}