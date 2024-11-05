/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sum Of Digits calculation
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Sum of digits calculation");
Console.WriteLine("=========================");

bool calculateNext = true;

while (calculateNext)
{
    Console.Write("Please enter a number [1..in.Max]: ");

    int number = int.Parse(Console.ReadLine());
    int sumOfDigits = 0;

    while (number != 0)
    {
        int digit = number % 10;
        sumOfDigits += digit;
        number = number / 10;
    }

    Console.WriteLine($"Sum of digits = { sumOfDigits }");

    Console.Write("Continue (yes/no): ");
    calculateNext = Console.ReadLine() == "yes";
}

