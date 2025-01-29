/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Check IsEvenOddNumber Number 
*--------------------------------------------------------------
*/

using System;

bool IsEvenOddNumber(int number)
{
    int sumOfDigitEven = SumOfDigitEven(number);
    int sumOfDigitOdd = SumOfDigitOdd(number);

    return number > 0 && sumOfDigitEven == sumOfDigitOdd;
}

int SumOfDigitEven(int number)
{
    return SumOfDigit(number, 0);
}

int SumOfDigitOdd(int number)
{
    return SumOfDigit(number, 1);
}

int SumOfDigit(int number, int remainder)
{
    int sumOfDigit = 0;
    number = Math.Abs(number);

    while (number > 0)
    {
        int digit = number % 10;
        if (digit % 2 == remainder)
        {
            sumOfDigit += digit;
        }

        number /= 10;
    }

    return sumOfDigit;
}

static int ReadNumber(string message, int max, int min)
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

Console.WriteLine("Find Even/Odd Number Numbers ");
Console.WriteLine("****************************");

int calculateFrom = ReadNumber("Calculate from",int.MaxValue, int.MinValue);
int calculateTo = ReadNumber("Calculate to", int.MaxValue, calculateFrom);

Console.WriteLine("****************************");

int count = 0;

for (int i = calculateFrom; i <= calculateTo; i++)
{
    if (IsEvenOddNumber(i))
    {
        if (count != 0)
        {
            Console.Write(",");
        }

        if (count != 0 && count % 10 == 0)
        {
            Console.WriteLine();
        }

        Console.Write(i);

        count++;
    }
}

Console.WriteLine();
Console.WriteLine("****************************");
Console.WriteLine($"They are {count} numbers in the range of [{calculateFrom}..{calculateTo}]");
Console.WriteLine("****************************");
