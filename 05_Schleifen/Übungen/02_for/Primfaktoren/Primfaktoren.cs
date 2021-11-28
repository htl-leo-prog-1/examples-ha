/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: PrimfaktorenZerlegung
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Get Prime factors");
Console.WriteLine("==========================");
Console.WriteLine();

uint number;
bool isOk;

do
{
    Console.Write($"Please enter number [1..]: ");
    isOk = uint.TryParse(Console.ReadLine(), out number);
} while (!isOk || number < 1);


if (number == 1)
{
    Console.WriteLine($": 1 = {number}");
}
else
{
    while (number % 2 == 0)
    {
        number = number / 2;
        Console.WriteLine($": 2 = {number}");
    }

    for (uint i = 3; i <= number; i = i + 2)
    {
        while (number % i == 0)
        {
            number = number / i;
            Console.WriteLine($": {i} = {number}");
        }
    }
}