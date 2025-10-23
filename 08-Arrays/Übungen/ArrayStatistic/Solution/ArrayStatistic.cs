/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ArrayStatistic
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Array Statistic");
Console.WriteLine("**********************");

Console.Write("Please enter the count of numbers: ");

int countOfNumbers = int.Parse(Console.ReadLine());
int[] intNumbers = new int[countOfNumbers];

for (int i = 0; i < countOfNumbers; i++)
{
    Console.Write($"Please enter {i + 1}. number: ");
    intNumbers[i] = int.Parse(Console.ReadLine());
}


Console.Write("Please enter lower bound: ");
int minBound = int.Parse(Console.ReadLine());

Console.Write("Please enter upper bound: ");
int maxBound = int.Parse(Console.ReadLine());

int countInRange = 0;

for (int i = 0; i < countOfNumbers; i++)
{
    if (intNumbers[i] >= minBound && intNumbers[i] <= maxBound)
    {
        countInRange++;
    }
}

if (countInRange > 0)
{
    Console.WriteLine($"{countInRange} numbers are in the range of [{minBound}..{maxBound}]");
}
else
{
    Console.WriteLine($"No number is in the range of [{minBound}..{maxBound}]");
}
