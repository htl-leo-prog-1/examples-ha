/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* FizzBuzz
* Zahl durch 3 teilbar => Fizz
* Zahl durch 5 teilbar => Buzz
* Zahl durch 3 & 5 teilbar
*--------------------------------------------------------------
*/

using System;

const int COUNTPERLINE = 10;

Console.WriteLine("FizzBuzz");
Console.WriteLine("=================");
Console.WriteLine();

int startValue;
int endValue;

bool isOk;
do
{
    Console.Write("Please enter start value [1..int]: ");
    isOk = int.TryParse(Console.ReadLine(), out startValue) && startValue >= 1;
} while (!isOk);

do
{
    Console.Write($"Please enter end value [{startValue + 1}..int]: ");
    isOk = int.TryParse(Console.ReadLine(), out endValue) && endValue > startValue;
} while (!isOk);

Console.WriteLine("***************************************************************************************************");

int countPerLine = 0;

for (int current = startValue; current <= endValue; current++)
{
    var isDiv3 = current % 3 == 0;
    var isDiv5 = current % 5 == 0;

    if (isDiv3 && isDiv5)
    {
        Console.Write("FizzBuzz");
    }
    else if (isDiv3)
    {
        Console.Write("    Fizz");
    }
    else if (isDiv5)
    {
        Console.Write("    Buzz");
    }
    else
    {
        Console.Write($"{current,8}");
    }

    bool isLast = current == endValue;

    if (isLast)
    {
        Console.WriteLine();
    }
    else
    {
        Console.Write(", ");

        countPerLine++;

        if (countPerLine >= COUNTPERLINE)
        {
            Console.WriteLine();
            countPerLine = 0;
        }
    }
}

Console.WriteLine("***************************************************************************************************");
